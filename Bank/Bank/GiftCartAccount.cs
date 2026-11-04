namespace Bank;
/// <summary>
/// Класс с подарочной картой, ежемесячно пополняется на определенную сумму
/// </summary>
public class GiftCartAccount:BankAccount
{
    private readonly decimal _monthlyDeposit = 0;
    //_monthlyDeposit - параметр по уммолчанию (принимает 0)
    // при создании new GiftCartAccount("Yana", 1000); => _monthlyDeposit = 0
    // new GiftCartAccount("Yana", 1000, 5000);=> _monthlyDeposit = 5000
    /// <summary>
    /// Создает подарочный счет с заданной суммой пополнения
    /// </summary>
    /// <param name="name">Имя владельца счета</param>
    /// <param name="initialBalance">Начальный баланс</param>
    /// <param name="monthlyDeposit">Сумма ежемесячного пополнения</param>
    public GiftCartAccount(string name, decimal initialBalance, decimal monthlyDeposit = 0) : base(name, initialBalance) => _monthlyDeposit = monthlyDeposit;
    /// <summary>
    /// Пополняет счет на сумму по окончанию месяца, если начисление равно 0, пополнение не выполнится
    /// </summary>
    public override void PerformMonthAndTransactions()
    {
        if (_monthlyDeposit != 0)
        {
            MakeDeposite(_monthlyDeposit, DateTime.UtcNow, "Add monthly deposit");
        }
    }
    /// <summary>
    /// Возвращает строковое представление подарочного счёта.
    /// </summary>
    /// <returns>Строка с информацией о счете и суммой пополения </returns>
    public override string ToString()
    {
        return base.ToString()+$"monthlyDeposit: {_monthlyDeposit}";
    }
}
