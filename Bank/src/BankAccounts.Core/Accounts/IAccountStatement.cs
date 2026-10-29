using BankAccounts.Core.Transactions;

namespace BankAccounts.Core.Accounts;
// ISP : клиенты зависят только от того что им реально нужно
internal interface IAccountStatement
{
    IReadOnlyList<Transaction> Transactions { get; }
}
