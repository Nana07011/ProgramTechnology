namespace BankAccounts.Core.Time;
// Реализация для продакшен: берет реальное время
public sealed class SystemClock : IClock
{
    public DateTime Now => DateTime.UtcNow;
}
