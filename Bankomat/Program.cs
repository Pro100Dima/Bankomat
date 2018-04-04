using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KKB.Bank.Module;//PODKLUCHILIS K PAPKE
using GeneratorName;

namespace Bankomat
{
    class Program
    {
        static void Main(string[] args)
        {
            string login = "";
            string password = "";
            try
            {
                Client client = new Client();
                Servise.createClient(ref client);

                client.Login = "admin";
                client.Password = "admin";


                while (!client.IsBloked)
                {
                    #region
                    Console.Clear();

                    Console.Write("vvedite login:");
                    login = Console.ReadLine();

                    Console.Write("vvedite parol:");
                    password = Console.ReadLine();

                    if (login != client.Login && password != client.Password)
                        client.WrongField++;
                    else
                    {
                        break;
                    }
                    #endregion
                }

                if (login == client.Login && password == client.Password)
                {
                    #region
                    if (client.IsBloked)
                    {
                        Console.WriteLine("zablokirivano");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("(1) spisok schetov");
                        Console.WriteLine("(2) sozdat schet");
                        Console.WriteLine("(3) popolnit balance");

                        int choise = 0;
                        Int32.TryParse(Console.ReadLine(), out choise);
                        if (choise > 2 || choise < 1)
                        {
                            throw new Exception("tolko 1 ili 2");
                        }
                        else
                        {
                            switch (choise)
                            {
                                case 1:
                                    client.printAccountInfo();
                                    break;
                                case 2:
                                    Account acc = new Account();
                                    client.ListAccount.Add(acc);
                                    Console.WriteLine("schet dobavlen");
                                    break;
                                case 3:
                                    
                                    Console.WriteLine("vvedite nomer scheta: ");
                                    string accountNumber = Console.ReadLine();
                                    Console.WriteLine("vvedite summu vvoda");
                                    break;
                            }
                        }
                    }
                #endregion
                }
                else
                {
                    Console.WriteLine("vkluchena BLOKIROVKA akkaunta");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            List<Client> ListClient = new List<Client>();

            Generator g = new Generator();

            Client Cl = new Client();
            Cl.DOB = DateTime.Now.AddYears(-60);
            Cl.FullName = g.GenerateDefault(Gender.man);
            Cl.IIN = "970131301448";
            Cl.Login = "QWE";
            Cl.Password = "123";
            Cl.PhoneNum = "87778139374";

            ListClient.Add(Cl);
        }
    }
}
