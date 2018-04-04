using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.Bank.Module
{
    public class Client
    {
        public Client()
        {
            ListAccount = new List<Account>();
        }
        private string FullName_;
        public string FullName
        {
            get
            {
                return FullName_;
            }
            set
            {
                FullName_ = value.Replace("?<center><b><font size =7>", "")
                    .Replace(@"?<\font><\b><\center>", "");
            }
        }

        public string IIN_;
        public string IIN
        {
            get { return IIN_; }
            set
            {
                if (value.Length == 12)
                {
                    IIN_ = value;
                }
                else
                {
                    throw new Exception("nekkorektnyi IIN");
                }
            }
        }
        public DateTime DOB { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string PhoneNum { get; set; }
        public List<Account> ListAccount;
        public int WrongField_;
        public bool IsBloked { get; set; } = false;
        public int WrongField {
            get { return WrongField_; }
            set
            {
                if (value >= 3)
                {
                    IsBloked = true;//schetchik popytok
                }
                WrongField_ = value;
            }
        }

        public void ClientInfoPrint(Client cl)
        {
            Console.WriteLine(
                "{0}\n,{1}\n,{2}\n,{3}\n,{4}\n,{5}\n",
                FullName, IIN, Login, Password, PhoneNum, DOB
                );
        }

        public void printAccountInfo()
        {
            double totalBalance = 0;
            foreach (Account item in ListAccount)
            {
                Console.WriteLine("nomer akkaunta {0}", item.AccountNumber);
                Console.WriteLine("balance akkaunta {0}", item.Balance);
                Console.WriteLine("data otkrytiya akkaunta {0}", item.CreateDate);
                Console.WriteLine("data zakrytiya akkaunta {0}", item.CloseDate);

                totalBalance += item.Balance;
            }
            Console.WriteLine("itogovyi balance = {0:n0}", totalBalance);
        }
    }
}
