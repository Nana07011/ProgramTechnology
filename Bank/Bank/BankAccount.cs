using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bank;

internal class BankAccount
{
    private List<Transaction> _allTransactions = new List<Transaction>();
    public string Owner { get; private set; }
    public string Number { get; }
    public decimal Balance 
    {
        get
        {
            decimal balance = 0;
            foreach (var transaction in _allTransactions)
            {
                balance += transaction.Amount;
            }
            return balance;
        }
    }

    private static int s_accountNumberSeed = 1000000000;
    public BankAccount(string name, decimal initialBalance)
    {

        MakeDeposite(initialBalance, DateTime.UtcNow, "initial balance");
        Owner = name;
        Number = s_accountNumberSeed.ToString();
        s_accountNumberSeed++;
    }

    public void MakeDeposite(decimal amout, DateTime date, string note)
    {
        if (amout <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amout), "Amount must be positive");
        }
        var deposite = new Transaction(amout, date, note);
        _allTransactions.Add(deposite);
    }
    public string GetAccountHistory()
    {
        var report = new StringBuilder();

        decimal balance = 0;
        report.AppendLine("Data\t\tAmount\tBalance\tNote");
        foreach (var item in _allTransactions)
        {
            balance += item.Amount;
            report.AppendLine($"" + 
                $"{item.Date.ToShortDateString()}\t" + 
                $"{item.Amount}\t{balance}\t{item.Note}");
        }
        return report.ToString();
    }
    public void MakeWithdrawal(decimal amout, DateTime date, string note)
    {
        if (amout <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amout), "Amount of withdrawal be positive");
        }
        if(Balance < amout)
        {
            throw new InvalidOperationException("Not sufficient money for this withdrawal");
        }
        var withdrawal = new Transaction(-amout, date, note);
        _allTransactions.Add(withdrawal);
    }
}

