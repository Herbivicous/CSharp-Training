using System;

namespace TP.BankLib
{
    public interface ISavingAccountOperations : IBankAccountOperations
    {
        public PositiveDouble ComputeInterestDue(DateTime now);

        public bool CreditInterestDue(DateTime now);
    }
}