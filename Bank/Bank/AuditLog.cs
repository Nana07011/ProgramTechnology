namespace Bank;
/// <summary>
/// Журнал аудита банковских операций.Хранит записи о пополнениях, списаниях и начислениях процентов.
/// </summary>
public class AuditLog
{
    /// <summary>
    /// Одна запись журнала
    /// </summary>
    /// <param name="AccountNumber">Номер счета</param>
    /// <param name="Type">Тип операции</param>
    /// <param name="Amount">Сумма операции</param>
    /// <param name="Date">Дата операции</param>
    public record Entry(string AccountNumber, string Type, decimal Amount, DateTime Date);
    private readonly List<Entry> _entries = new List<Entry>();
    /// <summary>
    /// Добавляет запись в журнал аудита.
    /// </summary>
    /// <param name="accountNumber">Номер счета</param>
    /// <param name="type">Тип операции</param>
    /// <param name="amount">Сумма операции</param>
    /// <param name="date">Дата операции</param>
    public void Log(string accountNumber, string type, decimal amount, DateTime date)
    {
        var entry = new Entry(accountNumber, type, amount, date);
        _entries.Add(entry);
    }
    /// <summary>
    /// Возвращает все записи журнала аудита.
    /// </summary>
    /// <returns>Список записей только для чтения, в порядке добавления.</returns>
    public IReadOnlyList<Entry> GetEntries() 
    { 
        return _entries; 
    }
    /// <summary>
    /// Формирует текстовый отчёт по всем записям журнала
    /// </summary>
    /// <returns>Строка с записями аудита</returns>
    public string GetReport()
    {
        string report = "Account\t\tType\tAmount\t\tDate\n";
        foreach(var e in _entries)
        {
            report += $"{e.AccountNumber}\t{e.Type}\t{e.Amount}\t{e.Date.Day}.{e.Date.Month}.{e.Date.Year}\n";
        }
        return report;
    }
}
