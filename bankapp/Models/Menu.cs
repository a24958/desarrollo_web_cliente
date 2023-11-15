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
    public static void AccountOptionError()
    {
        Console.WriteLine("CUENTA NO EXISTENTE CON ESE NÚMERO");
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
        string? ownerName = Console.ReadLine();

        decimal accountBalance;

        do
        {
            Console.WriteLine("INTRODUCE EL SALDO INICIAL DE LA CUENTA:");
        } while (!decimal.TryParse(Console.ReadLine(), out accountBalance));


        BankAccount bankAccount = new BankAccount(owner: ownerName!, balance: accountBalance);
        return bankAccount;
    }

    public static void newDeposit(List<BankAccount> a)
    {
        string? accountInput;
        bool check = false;

        do
        {
            AccountOption();
            accountInput = Console.ReadLine();

            foreach (var item in a)
            {
                if(accountInput!.Equals(item.Number)){
                    check = true;
                }
            }

            if (check == false)
            {
                AccountOptionError();
            };

        } while (check == false);

       decimal cuantityInput;

        do
        {
            Cuantity();
        } while (!decimal.TryParse(Console.ReadLine(), out cuantityInput));

        TransactionNote();
        string? noteInput = Console.ReadLine();

        BankAccount accountSelected = a.FirstOrDefault((e) => e.Number!.Equals(accountInput))!;
        accountSelected.MakeDeposit(cuantityInput, DateTime.Now, noteInput ?? " ");

    }

    public static void newWithDrawal(List<BankAccount> a)
    {
        string? accountInput;
        bool check = false;

        do
        {
            AccountOption();
            accountInput = Console.ReadLine();

            foreach (var item in a)
            {
                if(accountInput!.Equals(item.Number)){
                    check = true;
                }
            }

            if (check == false)
            {
                AccountOptionError();
            };

        } while (check == false);

        decimal cuantityInput;

        do
        {
            Cuantity();
        } while (!decimal.TryParse(Console.ReadLine(), out cuantityInput));
        

        TransactionNote();
        string? noteInput = Console.ReadLine();

        BankAccount accountSelected = a.FirstOrDefault((e) => e.Number!.Equals(accountInput))!;
        accountSelected.Makewithdrawal(cuantityInput, DateTime.Now, noteInput ?? " ");     
    }

    public static void PrintTransactions(List<BankAccount> a)
    {
        string? accountInput;
        bool check = false;

        do
        {
            AccountOption();
            accountInput = Console.ReadLine();

            foreach (var item in a)
            {
                if(accountInput!.Equals(item.Number)){
                    check = true;
                }
            }

            if (check == false)
            {
                AccountOptionError();
            };

        } while (check == false);

        BankAccount accountSelected = a.FirstOrDefault((e) => e.Number!.Equals(accountInput))!;

        Console.WriteLine("CUENTA NUMERO: " + accountSelected.Number);

        Console.WriteLine(BankAccount.ReadTransactionFromJson(accountSelected));
    }

    public static void doActions()
    {
        int selection;

        do
        {
            OptionMenu();
        } while (!int.TryParse(Console.ReadLine(), out selection));

        BankAccount accountExample1 = new BankAccount("Antonio", 2000);
        BankAccount accountExample2 = new BankAccount("Aarón", 1000);
        BankAccount accountExample3 = new BankAccount("Pablo", 3000);

        var accounts = new List<BankAccount>{accountExample1, accountExample2, accountExample3};

        while (selection != 3 && selection < 4)
        {
            BankAccount.SaveTransactionsInJSON(accounts);
            switch (selection)
            {
                case 1:
                    BankAccount newBankAccount = newAccount();
                    accounts.Add(newBankAccount);
                    break;
                case 2:
                    int newOption;

                    do
                    {
                        OperationMenu();
                    } while (!int.TryParse(Console.ReadLine(), out newOption));

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

            
            do
            {
                MainMenu();
                OptionMenu();
            } while (!int.TryParse(Console.ReadLine(), out selection));

        }
        // BankAccount.DeleteFilesJson(accounts);
    }

}
