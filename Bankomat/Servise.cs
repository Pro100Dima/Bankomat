using KKB.Bank.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratorName;

namespace Bankomat
{
    public class Servise
    {
        private static Random r = new Random();
        public static void createClient(ref Client client)
        {
            Generator gen = new Generator();
            client.FullName = gen.GenerateDefault(Gender.woman);
            client.IIN = "123321123321";
            client.PhoneNum = "+77078911213";
            client.DOB = DateTime.Now;

            for (int i = 0; i < r.Next(1,8); i++)
            {
                client.ListAccount.Add(createAccount());
            }
        }
        public static Account createAccount()
        {
            Account acc = new Account();
            acc.AccountNumber = "KZ"+r.Next(111111, 999999);
            acc.CreateDate  = DateTime.Now.AddMonths(-r.Next(1,30));
            acc.Balance = double.Parse(r.Next(1, 10000).ToString());//parse prinimaet string. poetomu, dobavili ToString
            return acc;
        }
    }
}
