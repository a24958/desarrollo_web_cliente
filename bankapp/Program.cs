using Models;

Console.WriteLine("Hello, World!");

BankAccount account = new BankAccount("Alex", 100);
var stringifAccount =  account.ToString();
Console.WriteLine(stringifAccount);

BankAccount account2 = new BankAccount("Aaron");

Console.WriteLine("Bye, World!");