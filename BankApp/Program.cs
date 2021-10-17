using System;

namespace BankApp.cli
{
    class Program
    {
        static void Main(string[] args)
        {
            StandardMessages.Welcome();
            CreateService createService = new CreateService();
            InputValidator inputValidator = new InputValidator();
            OperationsService operationService = new OperationsService();

            while (true)
            {
                StandardMessages.ChoiceDisplay();
                Choice choice = (Choice)Convert.ToInt32(Console.ReadLine());

                string bankname = "";
                string username = "";
                if (choice != Choice.Create && choice != Choice.Quit)
                {
                    StandardMessages.EnterBankName();
                    bankname = Console.ReadLine();
                    while (true)
                    {
                        bool result = inputValidator.CheckBank(bankname, createService);
                        if (result == true)
                        {
                            break;
                        }
                        Console.WriteLine("Please, enter the correct bankname");
                    }
                    username = "@";
                    bool res = false;
                    while (true)
                    {
                        StandardMessages.EnterName();
                        username = Console.ReadLine();
                        res = inputValidator.UsernameCheck(bankname, username, createService);
                        if (res == true)
                        {
                            break;
                        }
                        Console.WriteLine("username is not matched");
                    }


                    while (true)
                    {
                        StandardMessages.EnterPassword();
                        string password = Console.ReadLine();
                        res = inputValidator.PasswordCheck(bankname, username, password, createService);
                        if (res == true)
                        {
                            break;
                        }
                        Console.WriteLine("Please enter the correct password");
                    }
                }

                if (choice == Choice.Create)
                {
                    StandardMessages.EnterBankName();
                    string name = Console.ReadLine();
                    string bankName = createService.CreateBank(name);
                    bool res = false;
                    string userName = "@";
                    while (true)
                    {
                        StandardMessages.EnterName();
                        userName = Console.ReadLine();
                        //if username is unique then that method return false otherwise true
                        res = inputValidator.UsernameCheck(bankName, userName, createService);
                        if (res == false)
                        {
                            break;
                        }
                    }

                    StandardMessages.EnterPassword();
                    string password = Console.ReadLine();
                    createService.CreateAccount(bankName, userName, password);
                    Console.WriteLine("Account with the username " + userName + " is successfully created");
                }
                else if (choice == Choice.Deposit)
                {
                    StandardMessages.EnterAmount();
                    int amount = Convert.ToInt32(Console.ReadLine());
                    operationService.Deposit(bankname, username, amount, createService);
                }
                else if (choice == Choice.Withdraw)
                {
                    StandardMessages.EnterAmount();
                    int amount = Convert.ToInt32(Console.ReadLine());
                    operationService.WithDraw(bankname, username, amount, createService);
                }
                else if (choice == Choice.Transfer)
                {
                    Console.WriteLine("Enter the account you want to transfer");
                    string transferUsername = "";
                    bool res = false;
                    while (true)
                    {
                        transferUsername = Console.ReadLine();
                        res = inputValidator.UsernameCheck(bankname, transferUsername, createService);
                        if (res == true)
                        {
                            break;
                        }
                        Console.WriteLine("username is not matched");
                    }

                    int amount = Convert.ToInt32(Console.ReadLine());
                    operationService.Transfer(bankname, username, transferUsername, createService, amount);

                }
                else if (choice == Choice.TransactionHistory)
                {
                    operationService.TransactionHistory(bankname, username, createService);
                }
                else if (choice == Choice.Quit)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter the correct choice");
                }
            }

        }
    }
}
