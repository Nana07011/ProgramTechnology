namespace BankAccounts.Core.Accounts;

internal interface IAccountOperations
{
    decimal Balance { get; }
    void Deposit(decimal amount, DateTime date, string note);
    void WithDraw(decimal amount, DateTime date, string note);
}
