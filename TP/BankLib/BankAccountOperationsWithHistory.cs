using System;
using TP.BankLib.model;

namespace TP.BankLib
{
    public class BankAccountOperationsWithHistory : AbstractBankAccountOperations, IBankAccountOperations
    {

        private IBankAccountOperations _operations;
        private TransactionHistory _history;

        public override IBankAccountInfo BankAccount { get { return _operations.BankAccount; } }

        public BankAccountOperationsWithHistory(IBankAccountOperations operations, TransactionHistory history)
        {
            _operations = operations;
            _history = history;
        }

        public override bool Crediter(DateTime now, PositiveDouble amount)
        {
            bool success = _operations.Crediter(now, amount);
            if (success)
            {
                _history.AddTransaction(new Transaction(Transaction.Type.Credit, now, amount));
            }
            return success;
        }

        public override bool Debiter(DateTime now, PositiveDouble amount)
        {
            bool success = _operations.Debiter(now, amount);
            if (success)
            {
                _history.AddTransaction(new Transaction(Transaction.Type.Debit, now, amount));
            }
            return success;
        }
    }
}
