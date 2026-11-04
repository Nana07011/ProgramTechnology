namespace BankAccounts.Core.Withdrawals;
// Политика по умолчанию: если баланс ниже минимума - отклоняем
public sealed class StrictWithdrawalPolicy : IWithdrawalPolicy
{
    public WithdrawalDecision Evaluate(decimal currentBalance, decimal amount, decimal minimumBalance)
        => currentBalance - amount < minimumBalance ? WithdrawalDecision.Reject("Not sufficient rubls for this withdrawal") : WithdrawalDecision.Allow();
}