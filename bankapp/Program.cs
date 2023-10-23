using Models;

Console.WriteLine("Hello, World!");

BankAccount account = new BankAccount("Alex", 100);
var today = DateTime.Now;

account.MakeDeposit(5000, today, "Colacao");
account.MakeDeposit(2000, today, "Churros");

// try{
//     account.MakeDeposit(-2000, today, "Churros");
// } catch (ArgumentOutOfRangeException e){
//     Console.WriteLine("ArgumentOutOfRangeException: " + e.ToString());
// } catch (Exception e){
//     Console.WriteLine("Exception: " + e.ToString());
// }

try{
    account.Makewithdrawal(200, today, "Bus");
} catch (ArgumentOutOfRangeException e){
    Console.WriteLine("ArgumentOutOfRangeException: " + e.ToString());
} catch (InvalidOperationException e){
    Console.WriteLine("InvalidOperationException: ", e.ToString());
}

// try{
//     account.Makewithdrawal(-200, today, "Bus");
// } catch (ArgumentOutOfRangeException e){
//     Console.WriteLine("ArgumentOutOfRangeException: " + e.ToString());
// } catch (InvalidOperationException e){
//     Console.WriteLine("InvalidOperationException: ", e.ToString());
// }

var balance = account.Balance;
var stringifAccount =  account.ToString();
Console.WriteLine(stringifAccount);

var history = account.GetAccountHistory();
Console.WriteLine(history);

Console.WriteLine("Bye, World!");