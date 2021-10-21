using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.BankLib.model
{
    public interface ISavingAccountInfo : IBankAccountInfo
    {
        public PositiveDouble DailyInterestRate { get; set; }

        public DateTime LastInterest { get; set; }

        public TimeSpan DebitLockedDuration { get; set; }
    }
}
