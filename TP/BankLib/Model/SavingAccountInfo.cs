using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Client;

namespace TP.BankLib.model
{
    public class SavingAccountInfo : ISavingAccountInfo
    {

        public string Numero {
            get { return _bankAccount.Numero; }
        }

        public IPerson Owner {
            get { return _bankAccount.Owner; }
            set { _bankAccount.Owner = value; }
        }

        public DateTime CreationDate {
            get { return _bankAccount.CreationDate; }
        }

        public PositiveDouble Solde {
            get { return _bankAccount.Solde; }
            set { _bankAccount.Solde = value; }
        }

        public PositiveDouble DailyInterestRate { get; set; }

        public DateTime LastInterest {get; set;}

        public TimeSpan DebitLockedDuration {get; set;}

        private BankAccountInfo _bankAccount;

        public SavingAccountInfo(BankAccountInfo bankAccount, PositiveDouble dailyInterestRate, TimeSpan debitLocked)
        {
            _bankAccount = bankAccount;
            DailyInterestRate = dailyInterestRate;
            DebitLockedDuration = debitLocked;
            LastInterest = _bankAccount.CreationDate;
        }

        public override string ToString()
        {
            return _bankAccount.ToString();
        }

        public async Task<PositiveDouble> GetSoldeAsync() => await _bankAccount.GetSoldeAsync();
    }
}
