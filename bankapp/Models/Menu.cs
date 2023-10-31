namespace Models;

public class Menu{
    BankAccount nuevaCuenta = newAccount();

    public static void MainMenu(){
        Console.WriteLine("BANCO MUSCULITOS");
        Console.WriteLine("------------------------------");
    }

    public static void OptionMenu(){
        Console.WriteLine("SELECCIONE LA OPCION DESEADA");
        Console.WriteLine("1: CREAR CUENTA"); 
        Console.WriteLine("2: REALIZAR OPERACIONES"); 
    }

    public static void OperationMenu(){
        Console.WriteLine("1: AÑADIR DINERO");
        Console.WriteLine("2: SACAR DINERO");
        Console.WriteLine("3: VER ÚLTIMAS OPERACIONES");
    }

    public static int OptionSelected(){
        return Convert.ToInt32(Console.ReadLine());
    }

    public static BankAccount newAccount(){
        Console.WriteLine("INTRODUCE TU NOMBRE:");
        string? ownerName = Convert.ToString(Console.ReadLine());

        Console.WriteLine("INTRODUCE EL SALDO INICIAL DE LA CUENTA:");
        decimal accountBalance = Convert.ToDecimal(Console.ReadLine());

        BankAccount bankAccount = new BankAccount(owner: ownerName!, balance: accountBalance);
        return bankAccount;
    }

    public static decimal transactionAmmount(){
        Console.WriteLine("INTRODUCE LA CANTIDAD DE DINERO A INGRESAR:");
        decimal ammountDeposit = Convert.ToDecimal(Console.ReadLine());
        return ammountDeposit;
    }

    public static string transactionDescription(){
        Console.WriteLine("INTRODUCE LA DESCRIPCION DEL INGRESO:");
        string? ammountDescription = Convert.ToString(Console.ReadLine()) ?? " ";
        return ammountDescription;
    }

}


