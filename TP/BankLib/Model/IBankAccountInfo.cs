using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Client;

namespace TP.BankLib.model
{
    public interface IBankAccountInfo
    {
        public string Numero { get; }

        public IPerson Owner { get; set; }

        public DateTime CreationDate { get; }

        public PositiveDouble Solde { get; set; }
    }
}
