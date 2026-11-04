namespace Bank;
/// <summary>
/// Класс кредитный счета. Позволяет уходить в минус в пределах кредитного лимита и начисляет проценты за пользование кредитом.
/// </summary>
public class LineOfCreditAccount: BankAccount
{
    /// <summary>
    /// Создает кредитный счет, с заданным лимитом
    /// </summary>
    /// <param name="name">Имя владельца</param>
    /// <param name="initialBalance">Начальный баланс</param>
    /// <param name="creditLimit">Кредитный лимит</param>
    public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit):base(name, initialBalance, -creditLimit)
    {
    }
    /// <summary>
    /// Начисляет проценты за пользование кредитом, если баланс отрицательный. процентная ставка 7%
    /// </summary>
    public override void PerformMonthAndTransactions()
    {
        if(Balance < 0)
        {
            decimal interest = -Balance * 0.07m;
            MakeWithdrawal(interest, DateTime.UtcNow, "Charge monthly interest");
        }
    }
    /// <summary>
    /// Проверяет допустимо ли превышене кредитного лимита
    /// </summary>
    /// <param name="IsOverdrawn">Признак, того что баланс выходит за границу</param>
    /// <returns>Штраф за превышение (-20), иначе null</returns>
    protected override Transaction? CheckWithDrawalLimit(bool IsOverdrawn)
        => IsOverdrawn ? new Transaction(-20,DateTime.UtcNow, "apply overdraft") : default;
    //protected override Transaction? CheckWithDrawalLimit(bool IsOverdrawn)
    //{return IsOverdrawn? new Transaction(-20, DateTime.UtcNow, "apply overdraft") : default;}
}
