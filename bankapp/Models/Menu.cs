namespace Models;

public class Menu
{

    public static void MainMenu()
    {
        Console.WriteLine("BANCO MUSCULITOS");
        Console.WriteLine("------------------------------");
    }

    public static void OptionMenu()
    {
        Console.WriteLine("SELECCIONE LA OPCION DESEADA");
        Console.WriteLine("1: CREAR CUENTA");
        Console.WriteLine("2: REALIZAR OPERACIONES");
        Console.WriteLine("3: SALIR DEL PROGRAMA");
    }

    public static void OperationMenu()
    {
        Console.WriteLine("1: AÑADIR DINERO");
        Console.WriteLine("2: SACAR DINERO");
        Console.WriteLine("3: VER ÚLTIMAS OPERACIONES");
    }

    public static void AccountOption()
    {
        Console.WriteLine("SELECIONE UNA CUENTA: ");
    }

    public static void Cuantity()
    {
        Console.WriteLine("INTRODUCE LA CANTIDAD: ");
    }

    public static void TransactionNote()
    {
        Console.WriteLine("INTRODUCE UNA NOTA");
    }

    public static BankAccount newAccount()
    {
        Console.WriteLine("INTRODUCE TU NOMBRE:");
        string? ownerName = Convert.ToString(Console.ReadLine());

        Console.WriteLine("INTRODUCE EL SALDO INICIAL DE LA CUENTA:");
        decimal accountBalance = Convert.ToDecimal(Console.ReadLine());

        BankAccount bankAccount = new BankAccount(owner: ownerName!, balance: accountBalance);
        return bankAccount;
    }

    public static void newDeposit(List<BankAccount> a)
    {
        AccountOption();
        string? accountInput = Console.ReadLine();

        Cuantity();
        decimal cuantityInput = Convert.ToDecimal(Console.ReadLine());

        TransactionNote();
        string? noteInput = Console.ReadLine();

        BankAccount accountSelected = a.FirstOrDefault((e) => e.Number!.Equals(accountInput))!;
        accountSelected.MakeDeposit(cuantityInput, DateTime.Now, noteInput!);

        Console.WriteLine("CUENTA NUMERO: " + accountSelected.Number);
        Console.WriteLine(accountSelected.GetAccountHistory());
    }

    public static void newWithDrawal(List<BankAccount> a)
    {
        AccountOption();
        string? accountInput = Console.ReadLine();

        Cuantity();
        decimal cuantityInput = Convert.ToDecimal(Console.ReadLine());

        TransactionNote();
        string? noteInput = Console.ReadLine();

        BankAccount accountSelected = a.FirstOrDefault((e) => e.Number!.Equals(accountInput))!;
        accountSelected.Makewithdrawal(cuantityInput, DateTime.Now, noteInput!);

        Console.WriteLine("CUENTA NUMERO: " + accountSelected.Number);
        Console.WriteLine(accountSelected.GetAccountHistory());
    }

    public static void PrintTransactions(List<BankAccount> a)
    {
        AccountOption();
        string? accountInput = Console.ReadLine();

        BankAccount accountSelected = a.FirstOrDefault((e) => e.Number!.Equals(accountInput))!;

        Console.WriteLine("CUENTA NUMERO: " + accountSelected.Number);
        Console.WriteLine(accountSelected.GetAccountHistory());
    }

    public static void doActions()
    {
        int selection = Convert.ToInt32(Console.ReadLine());

        // BankAccount accountExample1 = new BankAccount("Antonio", 2000);
        // BankAccount accountExample2 = new BankAccount("Aarón", 1000);
        // BankAccount accountExample3 = new BankAccount("Pablo", 3000);

        var accounts = new List<BankAccount>{/*accountExample1, accountExample2, accountExample3*/};

        while (selection != 3 && selection < 4)
        {
            switch (selection)
            {
                case 1:
                    BankAccount newBankAccount = newAccount();
                    accounts.Add(newBankAccount);
                    break;
                case 2:
                    OperationMenu();
                    int newOption = Convert.ToInt32(Console.ReadLine());
                    switch (newOption)
                    {
                        case 1:
                            newDeposit(accounts);
                            break;
                        case 2:
                            newWithDrawal(accounts);
                            break;
                        case 3:
                            PrintTransactions(accounts);
                            break;
                    }
                    break;
                case 3:
                    break;
            }

            MainMenu();
            OptionMenu();

            selection = Convert.ToInt32(Console.ReadLine());

        }
    }

}
