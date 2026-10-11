using System.Text;

namespace Bank;
/// <summary>
/// Статус клиента банка. Определяет условие ежемесячного обслуживания счета
/// </summary>
public enum ClientStatus
{
    Regular, Premium, VIP
}
/// <summary>
/// Банковский счет, хранящий историю транзакций и баланс
/// </summary>
// BankAccount - потомок класса object
public class BankAccount
{
    private readonly decimal _minimumBalance;
    private List<Transaction> _allTransactions = new List<Transaction>();
    /// <summary>
    /// Владелец счета
    /// </summary>
    public string Owner { get; private set; }
    /// <summary>
    /// Уникальный номер счета владельца
    /// </summary>
    public string Number { get; }
    /// <summary>
    /// Текущий баланс, вычисляемый как сумма транзакций
    /// </summary>
    public decimal Balance 
    {
        get
        {
            decimal balance = 0;
            foreach (var transaction in _allTransactions)
            {
                balance += transaction.Amount;
            }
            return balance;
        }
    }
    /// <summary>
    /// Статус клиента банка. Определяет условия ежемесячного обслуживания.
    /// </summary>
    public ClientStatus Status { get; private set;  }
    private static int s_accountNumberSeed = 1000000000;
    /// <summary>
    /// Конструктор класса. Создаёт счёт с нулевым минимальным балансом.
    /// </summary>
    /// <param name="name">Имя владельца</param>
    /// <param name="initialBalance">Начальный баланс</param>
    public BankAccount(string name, decimal initialBalance):this(name, initialBalance, 0, ClientStatus.Regular)
    {
    }
    /// <summary>
    /// Конструктор класса. Создаёт счёт с заданным минимальным балансом и статусом Regular.
    /// </summary>
    /// <param name="name">Имя владельца</param>
    /// <param name="initialBalance">Начальный баланс</param>
    /// <param name="minimumBalance">Минимальный баланс</param>
    public BankAccount(string name, decimal initialBalance, decimal minimumBalance) : this(name, initialBalance, minimumBalance, ClientStatus.Regular)
    {
    }
    /// <summary>
    /// Конструктор класса. Создаёт счёт с заданным минимальным балансом и заданным статусом клиента.
    /// </summary>
    /// <param name="name">Имя владельца</param>
    /// <param name="initialBalance">Начальный баланс</param>
    /// <param name="minimumBalance">Минимальный баланс</param>
    /// <param name="status">Статус клиента банка</param>
    public BankAccount(string name, decimal initialBalance, decimal minimumBalance, ClientStatus status)
    {
        Owner = name;

        Number = s_accountNumberSeed.ToString();
        s_accountNumberSeed++;

        _minimumBalance = minimumBalance;
        Status = status;
        if (initialBalance > 0)
            MakeDeposite(initialBalance, DateTime.UtcNow, "initial balance");
    }
    /// <summary>
    /// Метод, который меняет статус клиента
    /// </summary>
    /// <param name="status">Новый статус клиента</param>
    public void ChangeStatus(ClientStatus status)
    {
        Status = status;
    }

    /// <summary>
    /// Метод, который пополняет счёт на указанную сумму.
    /// </summary>
    /// <param name="amount">Сумма пополнения</param>
    /// <param name="date">Дата пополнения</param>
    /// <param name="note">Комментарий к операции</param>
    /// <exception cref="ArgumentOutOfRangeException">Исключение, если сумма пополнения отрицательная</exception>
    public void MakeDeposite(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be positive");
        }
        var deposite = new Transaction(amount, date, note);
        _allTransactions.Add(deposite);
    }
    /// <summary>
    /// Метод, который формирует отчет-историю по всем транзакциям счёта.
    /// </summary>
    /// <returns>Строка с историей операций и накоплением баланса.</returns>
    public string GetAccountHistory()
    {
        var report = new StringBuilder();

        decimal balance = 0;
        report.AppendLine("Data\t\tAmount\tBalance\tNote");
        foreach (var item in _allTransactions)
        {
            balance += item.Amount;
            report.AppendLine($"" + 
                $"{item.Date.ToShortDateString()}\t" + 
                $"{item.Amount}\t{balance}\t{item.Note}");
        }
        return report.ToString();
    }
    // Ключевое слово virtual позволяет в дочернем классе предоставить другую реализацию метода PerformMonthAndTransactions
    /// <summary>
    /// Метод, который выполняет операции по окончании месяца согласно статусу клиента.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">Исключение бросается, если статус клиента неизвестен.</exception>
    public virtual void PerformMonthAndTransactions()
    {
        DateTime date = DateTime.UtcNow;
        switch (Status)
        {
            case ClientStatus.Regular:
                MakeWithdrawal(50m, date, "monthly service fee");
                break;
            case ClientStatus.Premium:
                if (Balance > 10000m)
                {
                    decimal interest = (Balance - 10000m) * 0.01m;
                    MakeDeposite(interest, date, "Premium interest");
                }
                break;
            case ClientStatus.VIP:
                if (Balance > 10000m)
                {
                    decimal interest = (Balance - 10000m) * 0.03m;
                    MakeDeposite(interest, date, "VIP interest");
                }
                decimal cashback = GetMonthlyWithdrawalsSum(date) * 0.05m;
                if (cashback > 0) MakeDeposite(cashback, date, "VIP cashback");
                break;
            default: throw new ArgumentOutOfRangeException(nameof(Status), $"Unknown status: {Status}");
        }
    }
    private decimal GetMonthlyWithdrawalsSum(DateTime date)
    {
        decimal sum = 0;
        foreach (var t in _allTransactions)
        {
            if (t.Amount < 0 && t.Date.Year == date.Year && t.Date.Month == date.Month)
                sum += -t.Amount;
        }
        return sum;
    }
    //Переопределяем метод базового класса - класса object
    // ToString - возвращает строку с информацией об объекте
    /// <summary>
    /// Возвращает строковое представление счёта.
    /// </summary>
    /// <returns>Строка с именем владельца, номером счёта и типом счёта.</returns>
    public override string ToString()
    {
        return $"Owner: {Owner}\taccount number: {Number} (тип счета {GetType()})";
    }
    /// <summary>
    /// Метод, который снимает со счёта указанную сумму.
    /// </summary>
    /// <param name="amount">Сумма снятия</param>
    /// <param name="date">Дата операции</param>
    /// <param name="note">Комментарий к операции</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Бросается, если <paramref name="amount"/> меньше или равен нулю.
    /// </exception>
    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);
        Transaction? overdraftTransaction = CheckWithDrawalLimit(Balance - amount < _minimumBalance);
        Transaction? withdrawal = new(-amount, date, note);

        _allTransactions.Add(withdrawal);
        if (overdraftTransaction is not null)
            _allTransactions.Add(overdraftTransaction);
        //    if (amount <= 0)
        //{
        //    throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal be positive");
        //}
        //if (Balance - amount < _minimumBalance)
        //{
        //    throw new InvalidOperationException("Not sufficient money for this withdrawal");
        //}
        //var withdrawal = new Transaction(-amount, date, note);
        //_allTransactions.Add(withdrawal);
    }
    //protected - модификатор доступа который означает , что этот метод можно вызывать только из текущего класса и дочернего класса
    //клиент внешний код) данный метод вызвать не может
    /// <summary>
    /// Метод, который проверяет допустимо ли превышение лимита снятия
    /// </summary>
    /// <param name="IsOverdrawn">Признак, того что баланс выходит за границу</param>
    /// <returns>Если нет превышения возвращает null</returns>
    /// <exception cref="InvalidOperationException">Исключение, если снятие выводит баланс за допустимый минимум.</exception>
    protected virtual Transaction? CheckWithDrawalLimit(bool IsOverdrawn)
    {
        if(IsOverdrawn)
        { 
            throw new InvalidOperationException("Not sufficient rubls for this withdrawal"); 
        }
        else
        {
            // default - содержит значение по умолчанию , так как тип возвращаемого значения - ссылочный, то эта переменная равняется default = null
            return default; //== return null;
        }
    }
}

