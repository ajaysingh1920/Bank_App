using BankApp.Services;
using System;

namespace BankApp.cli
{
    class  Program
    {
        static void Main(string[] args)
        {
            DataStorage dataStorage = new();

            ConsoleOutput.WelcomeDisplay();

            while (true)
            {
                //Ask Whether you are a Customer or Staff
                ConsoleOutput.MainMenuDisplay();
                MainMenu MainMenu = (MainMenu)(Convert.ToInt32(Console.ReadLine())-1);

                //if the user is Customer
                if (MainMenu == MainMenu.Customer)
                {
                    string Bankname;
                    Status status;
                    do
                    {
                        ConsoleOutput.EnterBankName();
                        Bankname = Console.ReadLine();
                        status = InputValidator.ValidateBankName(dataStorage, Bankname);
                        if (status == Status.BankNameInvalid)
                        {
                            Console.WriteLine("Pleae enter the Correct BankName");
                        }
                    } while (status == Status.BankNameInvalid);

                    string Username;
                    do
                    {
                        ConsoleOutput.EnterUsername();
                        Username = Console.ReadLine();
                        status = InputValidator.ValidateAccountUsername(dataStorage, Bankname, Username);

                        if (status == Status.UsernameInvalid)
                        {
                            Console.WriteLine("Please Enter the Correct Username");
                        }
                    } while (status == Status.UsernameInvalid);

                    string Password;
                    do
                    {
                        ConsoleOutput.EnterPassword();
                        Password = Console.ReadLine();
                        status = InputValidator.ValidateAccountPassword(dataStorage, Bankname, Username, Password);
                        if (status == Status.PasswordInvalid)
                        {
                            Console.WriteLine("Please Enter the Correct Password");
                        }
                    } while (status == Status.PasswordInvalid);

                    //Ask the Customer which operation he wants to perform
                    ConsoleOutput.CustomerOperationMenu();
                    CustomerOperationMenu CustomerOperationMenu = (CustomerOperationMenu)(Convert.ToInt32(Console.ReadLine()) - 1);

                    switch (CustomerOperationMenu)
                    {
                        // if the customer wants to Deposit
                        case CustomerOperationMenu.Deposit:
                            Console.WriteLine("Please enter the amount you want to deposit");
                            decimal Amount = Convert.ToInt32(Console.ReadLine());
                            CustomerService.Deposit(dataStorage,Bankname,Username,Amount);
                            break;

                        //if the customer wants to withdraw
                        case CustomerOperationMenu.Withdraw:
                            Console.Write("Please enter the amount you want to withdraw");
                            do
                            {
                                Amount = Convert.ToDecimal(Console.ReadLine());
                                status = CustomerService.Withdraw(dataStorage, Bankname, Username, Amount);

                                if (status == Status.InsufficientAmount)
                                {
                                    Console.WriteLine("You don't have enough balance,Please Enter the correct amount");
                                }
                            } while (status == Status.InsufficientAmount);

                            break;

                        //if the customer wants to transfer
                        case CustomerOperationMenu.Transfer:
                            Console.WriteLine("Please enter the sender bankname");
                            string ReceiverBankname;
                            do
                            {
                                ReceiverBankname = Console.ReadLine();
                                status = InputValidator.ValidateBankName(dataStorage, ReceiverBankname);
                                if (status == Status.BankNameInvalid)
                                {
                                    Console.WriteLine("Please enter the correct bankname");
                                }
                            } while (status == Status.BankNameInvalid);

                            string ReceiverUsername;
                            do
                            {
                                ReceiverUsername = Console.ReadLine();
                                status = InputValidator.ValidateAccountUsername(dataStorage, ReceiverBankname, ReceiverUsername);
                                if (status == Status.UsernameInvalid)
                                {
                                    Console.WriteLine("Please enter the correct Username");
                                }
                            } while (status == Status.UsernameInvalid);

                            Console.WriteLine("Please Enter the Amount you want to transfer");
                            do
                            {
                                Amount = Convert.ToDecimal(Console.ReadLine());
                                ConsoleOutput.EnterTransferMode();
                                TransferMode Mode = (TransferMode)(Convert.ToInt32(Console.ReadLine()) - 1);
                                if (Mode == TransferMode.RTGS)
                                {
                                    status = CustomerService.Transfer(dataStorage, Bankname, Username, ReceiverBankname, ReceiverUsername, Amount, "RTGS");
                                }
                                else if (Mode == TransferMode.IMPS)
                                {
                                    status = CustomerService.Transfer(dataStorage, Bankname, Username, ReceiverBankname, ReceiverUsername, Amount, "IMPS");
                                }

                                if (status == Status.InsufficientAmount)
                                {
                                    Console.WriteLine("You don't have enough balance,Please Enter the correct amount");
                                }
                            } while (status == Status.InsufficientAmount);

                            break;

                        // if the customer wants to see the transaction History
                        case CustomerOperationMenu.TransactionHistory:
                            CustomerService.TransactionHistory(dataStorage,Bankname,Username);
                            break;
                    }

                }

                //if ther user is Staff
                else if (MainMenu == MainMenu.Staff)
                {

                    //Checking the Credential of Staff Person
                    string Bankname;
                    Status status;
                    do
                    {
                        ConsoleOutput.EnterBankName();
                        Bankname = Console.ReadLine();
                        status = InputValidator.ValidateBankName(dataStorage,Bankname);
                        if (status== Status.BankNameInvalid){
                            Console.WriteLine("Pleae enter the Correct BankName");
                        }
                    } while (status==Status.BankNameInvalid);

                    string Username;
                    do
                    {
                        ConsoleOutput.EnterUsername();
                        Username = Console.ReadLine();
                        status = InputValidator.ValidateStaffUsername(dataStorage, Bankname, Username);

                        if (status == Status.UsernameInvalid)
                        {
                            Console.WriteLine("Please Enter the Correct Username");
                        }
                    } while (status == Status.UsernameInvalid);

                    string Password;
                    do
                    {
                        ConsoleOutput.EnterPassword();
                        Password = Console.ReadLine();
                        status = InputValidator.ValidateStaffPassword(dataStorage, Bankname, Username, Password);
                        if (status == Status.PasswordInvalid)
                        {
                            Console.WriteLine("Please Enter the Correct Password");
                        }
                    } while (status == Status.PasswordInvalid);

                    //Ask the Staff which Operation he want to do
                    ConsoleOutput.StaffOperationMenu();
                    StaffOperationMenu StaffOperationMenu = (StaffOperationMenu)(Convert.ToInt32(Console.ReadLine()) - 1);

                    switch (StaffOperationMenu)
                    {
                        //for create an account
                        case StaffOperationMenu.Create:
                            do
                            {
                                Console.WriteLine("Please enter the username from which you want to create an account:");
                                Username = Console.ReadLine();
                                status = InputValidator.ValidateAccountUsername(dataStorage, Bankname, Username);

                                if (status == Status.UsernameValid)
                                {
                                    Console.WriteLine("Please enter the unique username");
                                }
                            } while (status == Status.UsernameValid);

                            ConsoleOutput.EnterPassword();
                            Password = Console.ReadLine();
                            StaffService.CreateAccount(dataStorage,Bankname, Username, Password);
                            break;


                        //for delete an account
                        case StaffOperationMenu.Delete:
                            do
                            {
                                Console.WriteLine("Please enter the username of the account you want to delete ");
                                Username = Console.ReadLine();
                                status = InputValidator.ValidateAccountUsername(dataStorage, Bankname, Username);

                                if (status == Status.UsernameInvalid)
                                {
                                    Console.WriteLine("Please enter the correct username");
                                }
                            } while (status == Status.UsernameInvalid);

                            do
                            {
                                ConsoleOutput.EnterPassword();
                                Password = Console.ReadLine();
                                status = InputValidator.ValidateAccountPassword(dataStorage, Bankname, Username, Password);
                                if (status == Status.PasswordInvalid)
                                {
                                    Console.WriteLine("Please Enter the Correct Password");
                                }
                            } while (status == Status.PasswordInvalid);

                            StaffService.Delete(dataStorage, Bankname, Username);
                            break;

                        // for transaction history
                        case StaffOperationMenu.TransactionHistory:
                            do
                            {
                                ConsoleOutput.EnterUsername();
                                Username = Console.ReadLine();
                                status = InputValidator.ValidateAccountUsername(dataStorage, Bankname, Username);

                                if (status == Status.UsernameInvalid)
                                {
                                    Console.WriteLine("Please enter the correct username");
                                }
                            } while (status == Status.UsernameInvalid);

                            do
                            {
                                ConsoleOutput.EnterPassword();
                                Password = Console.ReadLine();
                                status = InputValidator.ValidateAccountPassword(dataStorage, Bankname, Username, Password);
                                if (status == Status.PasswordInvalid)
                                {
                                    Console.WriteLine("Please Enter the Correct Password");
                                }
                            } while (status == Status.PasswordInvalid);

                            StaffService.ShowTransactionHistory(dataStorage, Bankname, Username);
                            break;

                        //for revert an transaction
                        case StaffOperationMenu.RevertTransaction:
                            do
                            {
                                ConsoleOutput.EnterUsername();
                                Username = Console.ReadLine();
                                status = InputValidator.ValidateAccountUsername(dataStorage, Bankname, Username);

                                if (status == Status.UsernameInvalid)
                                {
                                    Console.WriteLine("Please enter the correct username");
                                }
                            } while (status == Status.UsernameInvalid);

                            do
                            {
                                ConsoleOutput.EnterPassword();
                                Password = Console.ReadLine();
                                status = InputValidator.ValidateAccountPassword(dataStorage, Bankname, Username, Password);
                                if (status == Status.PasswordInvalid)
                                {
                                    Console.WriteLine("Please Enter the Correct Password");
                                }
                            } while (status == Status.PasswordInvalid);

                            StaffService.RevertTransaction(dataStorage, Bankname, Username);
                            break;
                        
                        //for exchange currency
                        case StaffOperationMenu.ExchangeCurrency:
                            break;

                        default:
                            break;
                    }
                }
                else if(MainMenu==MainMenu.Quit)
                {
                    break;
                }
            }


        }
    }
}
