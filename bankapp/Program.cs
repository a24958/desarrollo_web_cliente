using Models;

User userAdmin = new User {Name = "Alex", LastName = "Gimenez", NIF = "12313K"};
User user = new User {Name = "Aaron", LastName = "Carter"};
User userNull = new User {};

var users = new Dictionary<int, User>(){{1, userAdmin}, {2, user}, {3, new User{Name = "Toñin", LastName = "Coliseum", NIF = "Usado"}}};

Console.WriteLine(users[1].ToString());
Console.WriteLine(users[2].ToString());
Console.WriteLine(users[3].ToString());

BankAccount account = new BankAccount("Alex", 100);
var today = DateTime.Now;

account.MakeDeposit(5000, today, "Colacao");
account.MakeDeposit(2000, today, "Churros");

try{
    account.Makewithdrawal(200, today, "Bus");
} catch (ArgumentOutOfRangeException e){
    Console.WriteLine("ArgumentOutOfRangeException: " + e.ToString());
} catch (InvalidOperationException e){
    Console.WriteLine("InvalidOperationException: ", e.ToString());
}

Console.WriteLine(" ");

InterestEarningAccount bankaccMarcos = new InterestEarningAccount("Marcos", 1000);
bankaccMarcos.MakeDeposit(1000, DateTime.Now, "Cumpleaños");
bankaccMarcos.PerformMonthlyOperation();
Console.WriteLine(bankaccMarcos.GetAccountHistory());

CreditCardAccount bankaccPablo = new CreditCardAccount("Pablo", 1000);
bankaccPablo.MakeDeposit(1000, DateTime.Now, "Paga");
bankaccPablo.Makewithdrawal(3000, DateTime.Now, "LOL");
bankaccPablo.PerformMonthlyOperation();
Console.WriteLine(bankaccPablo.GetAccountHistory());