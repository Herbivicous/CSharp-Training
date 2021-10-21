using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.BankLib
{
    public class TransactionHistory : IEnumerable<Transaction>
    {

        private Queue<Transaction> _history;
        private int _maxSize;

        public int MaxSize { get { return _maxSize; } }

        public TransactionHistory(int maxSize)
        {
            _maxSize = maxSize;
            _history = new Queue<Transaction>(maxSize);
        }

        public void AddTransaction(Transaction transaction)
        {
            if (_history.Count == _maxSize - 1)
            {
                _history.Dequeue();
            }
            _history.Enqueue(transaction);
        }

        public IEnumerable<Transaction> GetCreditsAsEnumerable()
        {
            return _history.Where(t => t.TransactionType == Transaction.Type.Credit);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"Last {MaxSize} transactions :");

            foreach (Transaction t in this)
            {
                builder.AppendLine(t.ToString());
            }
            return builder.ToString();
        }

        IEnumerator<Transaction> IEnumerable<Transaction>.GetEnumerator()
        {
            return _history.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _history.GetEnumerator();
        }
    }
}
