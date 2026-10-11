namespace Bank;

public class AuditLog
{
    public record Entry(string AccountNumber, string Type, decimal Amount, DateTime Date);
    private readonly List<Entry> _entries = new List<Entry>();
    public void Log(string accountNumber, string type, decimal amount, DateTime date)
    {
        var entry = new Entry(accountNumber, type, amount, date);
        _entries.Add(entry);
    }
    public IReadOnlyList<Entry> GetEntries() 
    { 
        return _entries; 
    }
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
