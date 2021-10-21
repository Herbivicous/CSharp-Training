using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.BankLib.model;

namespace TP.BankLib
{
    public abstract class AbstractBankAccountOperations : IBankAccountOperations
    {
        public abstract IBankAccountInfo BankAccount { get; }

        public abstract bool Crediter(DateTime now, PositiveDouble amount);

        public abstract bool Debiter(DateTime now, PositiveDouble amount);

        public bool Operation(Transaction.Type type, PositiveDouble amount, DateTime now)
        {
            return DoOperationFromType(now, type, amount);
        }

        public bool Operation(double amount, DateTime now)
        {
            Transaction.Type transactionType = amount >= 0 ? Transaction.Type.Credit : Transaction.Type.Debit;
            PositiveDouble amountAsPositiveDouble = new PositiveDouble(System.Math.Abs(amount));
            return Operation(transactionType, amountAsPositiveDouble, now);
        }

        private bool DoOperationFromType(DateTime now, Transaction.Type type, PositiveDouble amount)
        {
            return type switch
            {
                Transaction.Type.Credit => Crediter(now, amount),
                Transaction.Type.Debit => Debiter(now, amount),
                _ => false
            };

        }
    }
}
