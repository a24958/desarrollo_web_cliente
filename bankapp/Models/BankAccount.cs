namespace Models;

public class BankAccount {
    public string? Number {get;}
    public string? Owner {get; set;}
    public decimal Balance {get;}

    private static int accountNumber_seed = 1;

    public BankAccount(string owner){
        this.Owner = owner;
        this.Balance = 0;
        this.Number = accountNumber_seed.ToString();
        accountNumber_seed++;
    }

    public BankAccount(string owner, decimal balance){
        this.Owner = owner;
        this.Balance =  balance;
        this.Number = accountNumber_seed.ToString();
        accountNumber_seed++;
    }

    public void MakeDeposit(decimal ammount, DateTime date, string note) {
        
    }

    public void Makewithdrawal(decimal ammount, DateTime date, string note) {

    }

    public override string ToString(){
        return this.Owner ?? "Null Owner";
    }

}