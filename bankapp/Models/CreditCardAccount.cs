using Models;

public class CreditCardAccount: BankAccount{
    
    private const decimal INTEREST_RATE = 0.05M;

    public CreditCardAccount(string owner, decimal initialBalance) : base(owner, initialBalance){}

    public override void Makewithdrawal(decimal amount, DateTime date, string note){
        var withdrawal = new Transaction(-amount, date, note, Number!.ToString());
        transactions.Add(withdrawal);
    }

    public override void PerformMonthlyOperation(){
        decimal interestLost = Balance * INTEREST_RATE;
        if(Balance < 0){
            Makewithdrawal(-interestLost, DateTime.Now.AddDays(30), "Monthly withdrawal due to debts");
        }
    }
}