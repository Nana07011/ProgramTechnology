using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bank;
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
    /// Текущий баланс, вычисляемый ак сумма транзакций
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
    private static int s_accountNumberSeed = 1000000000;
    /// <summary>
    /// Конструктор класса. Создаёт счёт с нулевым минимальным балансом.
    /// </summary>
    /// <param name="name">Имя владельца</param>
    /// <param name="initialBalance">Начальный баланс</param>
    public BankAccount(string name, decimal initialBalance):this(name, initialBalance, 0)
    {

    }
    /// <summary>
    /// Конструктор класса. Создаёт счёт с заданным минимальным балансом.
    /// </summary>
    /// <param name="name">Имя владельца</param>
    /// <param name="initialBalance">Начальный баланс</param>
    /// <param name="minimumBBalance">Минимальный баланс</param>
    public BankAccount(string name, decimal initialBalance, decimal minimumBBalance)
    {
        Owner = name;

        Number = s_accountNumberSeed.ToString();
        s_accountNumberSeed++;

        _minimumBalance = minimumBBalance;
        if (initialBalance > 0)
            MakeDeposite(initialBalance, DateTime.UtcNow, "initial balance");
    }
    /// <summary>
    /// Метод, который пополняет счёт на указанную сумму.
    /// </summary>
    /// <param name="amout">Сумма пополнения</param>
    /// <param name="date">Дата пополнения</param>
    /// <param name="note">Комментарий к операции</param>
    /// <exception cref="ArgumentOutOfRangeException">Исключение, если сумма пополения отрицательная</exception>
    public void MakeDeposite(decimal amout, DateTime date, string note)
    {
        if (amout <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amout), "Amount must be positive");
        }
        var deposite = new Transaction(amout, date, note);
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
    /// Метод, который выполняет операции по окончании месяца.
    /// </summary>
    public virtual void PerformMonthAndTransactions()
    {

    }
    //Переопределяем метод базового класса - класаа object
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
    /// <param name="note">Комментарий к операцие</param>
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
    //protected - модификатор доступа который означает , что этот метод можно вызывть только из текущего класса и дочернего класса
    //клиент 9внешний код) данный метод вызвать не может
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
            // default - содержит значение по умолчанию , так как тип возвращаемого знаения - ссылочный, то эта переменная равняется default = null
            return default; //== return null;
        }
    }
}

