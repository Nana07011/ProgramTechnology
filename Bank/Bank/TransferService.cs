namespace Bank;
/// <summary>
/// Сервис перевода денег между счетами.
/// </summary>
public class TransferService
{
    /// <summary>
    /// Переводит указанную сумму со счёта <paramref name="from"/> на счёт <paramref name="to"/>.
    /// </summary>
    /// <param name="from">Счёт-источник</param>
    /// <param name="to">Счёт-получатель</param>
    /// <param name="amount">Сумма перевода. Должна быть положительной.</param>
    /// <param name="date">Дата операции</param>
    /// <param name="note">Комментарий к операции</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Исключение бросается, если <paramref name="amount"/> меньше или равен нулю.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// Исключение бросается, если списание с источника невозможно.
    /// </exception>
    public void Transfer(BankAccount from, BankAccount to, decimal amount, DateTime date, string note)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);
        from.MakeWithdrawal(amount, date, $"Transfer to {to.Number}. {note}");
        try
        {
            to.MakeDeposite(amount, date, $"Transfer from {from.Number}. {note}");
        }
        catch (ArgumentOutOfRangeException)
        {
            from.MakeDeposite(amount, date, $"Rollback transfer to {to.Number}");
            throw;
        }
    }
}
