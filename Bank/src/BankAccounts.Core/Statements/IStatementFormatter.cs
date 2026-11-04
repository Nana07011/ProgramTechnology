using BankAccounts.Core.Transactions;

namespace BankAccounts.Core.Statements;
// Форматирование - отдельная ответственность.
// Можно добавить jSON/CSV без правки счета (SRP)
public interface IStatementFormatter
{
    string Format(IEnumerable<Transaction> transactions);
}
