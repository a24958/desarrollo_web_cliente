using System.Runtime.InteropServices;
using System.Text.Json;
using System.Transactions;
using System.Xml.XPath;

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
        foreach (var bankAccount in bankAccounts)
        {
            string fileName = bankAccount.Owner + bankAccount.Number + ".json";
            string jsonString = JsonSerializer.Serialize(bankAccount.transactions);
            File.WriteAllText(fileName, jsonString);  
        }
        
    }

    public static string ReadTransactionFromJson(BankAccount a){
        string path = a.Owner + a.Number + ".json";
        var stringJson = JsonSerializer.Deserialize<List<Transaction>>(File.ReadAllText(path));
        var historial = new System.Text.StringBuilder();
        decimal balance = 0;

        // foreach (var item in a.transactions)
        // {
        //     balance += item.Amount;
        // }

        historial.AppendLine("Date\t\tAmount\t\tBalance\t\tNote");
        foreach (var item in stringJson!)
        {
            balance += item.Amount;
            historial.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t\t{balance}\t\t{item.Note}");
        }

        return historial.ToString();
    }

    public static void DeleteFilesJson(List<BankAccount> bankAccounts){
        foreach (var bankAccount in bankAccounts)
        {
            string fileName = bankAccount.Owner + bankAccount.Number + ".json";
            File.Delete(fileName);  
        }
    }

    public virtual void PerformMonthlyOperation() {}
}