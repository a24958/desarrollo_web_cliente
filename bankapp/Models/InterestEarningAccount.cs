using Models;

public class InterestEarningAccount: BankAccount{

    private const decimal INTEREST_RATE = 0.05M;

    public InterestEarningAccount(string owner, decimal initialBalance) : base(owner, initialBalance){}

    public override void PerformMonthlyOperation(){
        decimal interestEarned = Balance * INTEREST_RATE;
        MakeDeposit(interestEarned, DateTime.Now.AddDays(30), "Monthly Earnings");
    }
}
