using System.Text.Json;
using System.Transactions;

namespace Models;

public class BankAccount
{
    public string? Number { get; }
    public string? Owner { get; set; }
    public decimal Balance
    {
        get
        {
            decimal balance = 0;
            foreach (Transaction item in transactions)
            {
                balance += item.Amount;
            }
            return balance;
        }
    }

    private static int accountNumber_seed = 1;

    protected List<Transaction> transactions = new List<Transaction>();

    public BankAccount(string owner)
    {
        this.Owner = owner;
        this.Number = accountNumber_seed.ToString();
        accountNumber_seed++;
    }

    public BankAccount(string owner, decimal balance)
    {
        this.Owner = owner;
        this.Number = accountNumber_seed.ToString();
        MakeDeposit(balance, DateTime.Now, "First deposit");
        accountNumber_seed++;
    }

    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "No puede añadirse un depósito negativo");
        }

        var deposit = new Transaction(amount, date, note ?? "", Number?.ToString()!);
        transactions.Add(deposit);
    }

    public virtual void Makewithdrawal(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "No puede realizar una retirada negativa");
        }

        if ((Balance - amount) < 0)
        {
            throw new InvalidOperationException("No puedes retirar dinero, porque no dispone de él");
        }

        var withdrawal = new Transaction(-amount, date, note ?? "", Number!.ToString());
        transactions.Add(withdrawal);
    }

    public string GetAccountHistory()
    {
        var history = new System.Text.StringBuilder();
        decimal balance = 0;
        history.AppendLine("Date\t\tAmount\t\tBalance\t\tNote");
        foreach (var item in transactions)
        {
            balance += item.Amount;
            history.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t\t{balance}\t\t{item.Note}");
        }
        return history.ToString();
    }

    public override string ToString()
    {
        return this.Owner ?? "Null Owner";
    }

    public static void SaveTransactionsInJSON(List<BankAccount> bankAccounts)
    {
        string fileName = "Transactions.json";

        File.AppendAllText(fileName, "[");
        foreach (var bankAccount in bankAccounts)
        {
            string jsonString = JsonSerializer.Serialize(bankAccount.transactions);
            File.AppendAllText(fileName, "\n");
            File.AppendAllText(fileName, "\t");
            File.AppendAllText(fileName, jsonString);
            if(File.ReadAllText(fileName).Last().Equals("]")){
                File.AppendAllText(fileName, ",");
                File.AppendAllText(fileName, "\n");
            } else{
                File.AppendAllText(fileName, "]");
            }
        }
       
        
    }

    public virtual void PerformMonthlyOperation() { }
}