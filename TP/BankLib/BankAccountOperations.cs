using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.BankLib.model;

namespace TP.BankLib
{
	public class BankAccountOperations : AbstractBankAccountOperations, IBankAccountOperations
	{

		private IBankAccountInfo _bankAccount;

		public override IBankAccountInfo BankAccount { get { return _bankAccount; } }

		public BankAccountOperations(IBankAccountInfo bankAccount)
		{
			_bankAccount = bankAccount;
		}

		public override bool Crediter(DateTime now, PositiveDouble amount)
		{
			_bankAccount.Solde += amount;
			return true;
		}

		public override bool Debiter(DateTime now, PositiveDouble amount)
		{
			if (_bankAccount.Solde.Value < amount.Value)
			{
				return false;
			}

			_bankAccount.Solde -= amount;
			return true;
		}
	}
}
