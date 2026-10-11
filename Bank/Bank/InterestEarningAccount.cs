namespace Bank;
/// <summary>
/// Класс, счет с начислением процентов по окончании месяца
/// </summary>
public class InterestEarningAccount: BankAccount
{
    /// <summary>
    /// Создает счет с начислением процентов
    /// </summary>
    /// <param name="name">Имя владельца</param>
    /// <param name="initialBalance">Нчальный баланс</param>
    public InterestEarningAccount(string name, decimal initialBalance):base(name, initialBalance)
    {

    }
    //override позволяет в дочернем классе определить новую реализацию метода PerformMonthAndTransactions
    /// <summary>
    /// Начисление процентов по окончании месяца, если баланс превышает 500. Процентная ставка 2%
    /// </summary>
    public override void PerformMonthAndTransactions()
    {
        if(Balance > 500m)
        {
            decimal interest = Balance * 0.02m;
            MakeDeposite(interest, DateTime.UtcNow, "Apply month interest");
            BankAccount.Audit.Log(Number, "Interest", interest, DateTime.UtcNow);
        }
    }
}
