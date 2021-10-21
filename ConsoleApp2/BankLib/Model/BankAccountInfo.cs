using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Client;
using TP.Utils;

namespace TP.BankLib.model
{
    public class BankAccountInfo : IBankAccountInfo
    {
        public string Numero { get; init; }

        public IPerson Owner { get; set; }

        public DateTime CreationDate { get; init; }

        public PositiveDouble Solde { get; set; }

        public BankAccountInfo(
            string numero,
            IPerson owner,
            DateTime creationDate,
            PositiveDouble solde
        )
        {
            Numero = numero;
            Owner = owner;
            CreationDate = creationDate;
            Solde = solde;
        }

        public BankAccountInfo(string numero, IPerson owner) : this(
            numero, owner, DateTime.Now, new PositiveDouble(0)
        )
        { }

        public override string ToString() => $"N°{Numero} ({Owner}) created on {CreationDate} : {Solde.Value}€";
    }
}
