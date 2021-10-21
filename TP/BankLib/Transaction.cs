using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.BankLib
{
    public class Transaction : IComparable
    {
        public enum Type { Credit, Debit }

        public Type TransactionType { get; init; }

        public DateTime Date { get; init; }

        public PositiveDouble Amount { get; init; }

        public Transaction(Type type, DateTime date, PositiveDouble amount)
        {
            TransactionType = type;
            Date = date;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"{Date} : {TransactionType} ({Amount.Value})";
        }

        public int CompareTo(object obj)
        {
            if (obj is Transaction t)
            {
                return Amount.Value.CompareTo(t.Amount.Value);
            }
            return 0;
        }
    }
}
