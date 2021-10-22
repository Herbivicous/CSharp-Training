using TP.Client;
using System;
using TP.BankLib;
using System.Text;
using TP.BankLib.model;
using System.Linq;

namespace TP.Main
{
    class Program
    {

        public static void Main(string[] args)
        {
            Random r = new Random();
            Bank b = new Bank(new PositiveDouble(0.005), new TimeSpan(10 * 365, 0, 0));

            IPerson toto = new Person("Toto", "Totot", new DateTime(1990, 05, 28));
            IPerson tata = new Person("Tata", "Babab", new DateTime(1887, 08, 31));

            b.OpenBankAccount("toto1", toto, toto.Naissance, new PositiveDouble(r.Next() % 1000));
            b.OpenBankAccount("tata1", tata, tata.Naissance, new PositiveDouble(r.Next() % 1000));
            b.OpenSavingAccount("toto2", toto, toto.Naissance, PositiveDouble.Zero);
            b.OpenSavingAccount("tata2", tata, tata.Naissance, PositiveDouble.Zero);

            Console.WriteLine(b.ComputeTotalInterest(DateTime.Now));

            b.CreditInterestForAllSavingAccounts(DateTime.Now);

            Console.WriteLine(b.GetOperationForAccount("toto2").BankAccount);
            Console.WriteLine(b.GetOperationForAccount("tata2").BankAccount);

            IBankAccountOperations operations = b.GetOperationForAccount("toto1");
            for (int i = 0; i <= 40; i++)
            {
                operations.Crediter(DateTime.Now, new PositiveDouble(r.Next()%1000));
            }

            Console.WriteLine(new StringBuilder().AppendJoin('\n', b.GetHistoryForAccount("toto1").OrderBy(t => t.Amount)));
            Console.WriteLine(b.GetHistoryForAccount("tata2"));

            Console.WriteLine(b);

            Console.WriteLine(b.GetTotalSolde());
            Console.WriteLine(b.GetTotalSoldeAsync().Result);
        }
    }
}
