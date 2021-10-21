using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.BankLib.model;

namespace TP.BankLib
{
    public class SavingAccountOperations : AbstractBankAccountOperations, ISavingAccountOperations
    {

        private IBankAccountOperations _operations;
        private ISavingAccountInfo _savingAccount;

        public override IBankAccountInfo BankAccount { get { return _operations.BankAccount; } }

        public SavingAccountOperations(IBankAccountOperations operations, ISavingAccountInfo savingAccount)
        {
            _operations = operations;
            _savingAccount = savingAccount;
        }
        public override bool Debiter(DateTime now, PositiveDouble amount) {
            if (now >= _savingAccount.CreationDate + _savingAccount.DebitLockedDuration) {
                return _operations.Debiter(now, amount);
            }
            return false;
        }

        public override bool Crediter(DateTime now, PositiveDouble amount) => _operations.Crediter(now, amount);

        public PositiveDouble ComputeInterestDue(DateTime now)
        {
            PositiveDouble amount = _savingAccount.DailyInterestRate * new PositiveDouble((now - _savingAccount.LastInterest).Days);
            return amount;
        }

        public bool CreditInterestDue(DateTime now)
        {
            PositiveDouble amountDue = ComputeInterestDue(now);
            _savingAccount.LastInterest = now;
            return Crediter(now, amountDue);
        }
    }
}
