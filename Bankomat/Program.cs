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
