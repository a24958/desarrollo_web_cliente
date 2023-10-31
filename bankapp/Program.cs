using Models;

Menu.MainMenu();
Menu.OptionMenu();

var accounts = new List<BankAccount>{};
// accounts.FirstOrDefault((element) => element.Owner == Console.ReadLine());

switch (Menu.OptionSelected())
{
    case 1:
        BankAccount newBankAccount = Menu.newAccount();
        accounts.Add(newBankAccount);
        break;
    case 2:
        Menu.OperationMenu();
        switch(Menu.OptionSelected()){
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
        }
        break;
}