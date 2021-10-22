using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.BankLib.model;

namespace TP.BankLib
{
	public class BankAccountOperationObservable : AbstractBankAccountOperations, IBankAccountOperations, IObservable<IBankAccountOperations>
	{

		private IBankAccountOperations _operations;
		private List<IObserver<IBankAccountOperations>> _observers;

		protected BankAccountOperationObservable(IBankAccountOperations operations)
		{
			_operations = operations;
			_observers = new List<IObserver<IBankAccountOperations>>();
		}

        public override IBankAccountInfo BankAccount => _operations.BankAccount;

		public override bool Crediter(DateTime now, PositiveDouble amount) => _operations.Crediter(now, amount);

		public override bool Debiter(DateTime now, PositiveDouble amount)
		{
			bool success = _operations.Debiter(now, amount);

			if (!success)
			{
				_observers.ForEach(observer => observer.OnError(new Exception("Not enough money")));
			}

			return success;
		}

        public IDisposable Subscribe(IObserver<IBankAccountOperations> observer)
        {
			if (!_observers.Contains(observer))
				_observers.Add(observer);
			return new Unsubscriber(_observers, observer);
		}
		private class Unsubscriber : IDisposable
		{
			private List<IObserver<IBankAccountOperations>> _observers;
			private IObserver<IBankAccountOperations> _observer;

			public Unsubscriber(List<IObserver<IBankAccountOperations>> observers, IObserver<IBankAccountOperations> observer)
			{
				this._observers = observers;
				this._observer = observer;
			}

			public void Dispose()
			{
				if (_observer != null && _observers.Contains(_observer))
					_observers.Remove(_observer);
			}
		}

	}
}
