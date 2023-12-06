using System.Text;

namespace MySuperBank;

public class BankAccount
{
    public string Number { get; }
    public string Owner { get; set; }

    public decimal Balance
    {
        get
        {
            decimal balance = 0;
            foreach (var item in _allTransactions)
            {
                balance += item.Amount;
            }

            return balance;
        }
    }

    private List<Transaction> _allTransactions = new List<Transaction>();

    private static int s_accountNumberSeed = 123456789;

    public BankAccount(string name, decimal initialBalance)
    {
        Owner = name;
        MakeDeposit(initialBalance, DateTime.Now, "Initial Deposit");
        Number = s_accountNumberSeed.ToString();
        s_accountNumberSeed++;
    }
    
    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
        }
        var deposit = new Transaction(amount, date, note);
        _allTransactions.Add(deposit);
    }

    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
        }
        if (Balance - amount < 0)
        {
            throw new InvalidOperationException("Not sufficient funds for this withdrawal");
        }
        var withdrawal = new Transaction(-amount, date, note);
        _allTransactions.Add(withdrawal);
    }
    public string GetAccountHistory()
    {
        var report = new StringBuilder();
        //HEADER
        report.AppendLine("Date\t\tAmount\tNote");
        foreach (var item in _allTransactions)
        {
         //ROWS
         report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{item.Notes}");
        }

        return report.ToString();
    }
}
