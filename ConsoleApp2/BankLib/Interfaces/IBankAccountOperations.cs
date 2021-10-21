using System;
using TP.BankLib.model;

namespace TP.BankLib
{
    public interface IBankAccountOperations
    {
        public bool Crediter(DateTime now, PositiveDouble amount);

        public bool Debiter(DateTime now, PositiveDouble amount);

        public bool Operation(Transaction.Type type, PositiveDouble amount, DateTime now);

        public bool Operation(double amount, DateTime now);

        public IBankAccountInfo BankAccount { get; }
    }
}