using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.BankLib
{
    public class PositiveDouble : IEquatable<PositiveDouble>, IComparable<PositiveDouble>
    {
        private Exception NegativeNumberException = new Exception("Number cant be negative");

        public static PositiveDouble Zero { get { return new PositiveDouble(0); } }

        private double v;

        public double Value
        {
            get => v;
            set
            {
                if (value < 0)
                {
                    throw NegativeNumberException;
                }
                v = value;
            }
        }

        public PositiveDouble(double value)
        {
            if (value < 0)
            {
                throw NegativeNumberException;
            }
            Value = value;
        }

        public bool Equals(PositiveDouble other) => Value == other.Value;

        public override bool Equals(object obj) => Equals(obj as PositiveDouble);

        public override string ToString() => v.ToString();

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public int CompareTo(PositiveDouble other)
        {
            return Value.CompareTo(other.Value);
        }

        public static PositiveDouble operator *(PositiveDouble p1, PositiveDouble p2)
        {
            return new PositiveDouble(p1.Value * p2.Value);
        }

        public static PositiveDouble operator +(PositiveDouble p1, PositiveDouble p2)
        {
            return new PositiveDouble(p1.Value + p2.Value);
        }

        public static PositiveDouble operator -(PositiveDouble p1, PositiveDouble p2)
        {
            return new PositiveDouble(p1.Value - p2.Value);
        }

        public static bool operator <(PositiveDouble p1, PositiveDouble p2)
        {
            return p1.Value < p2.Value;
        }

        public static bool operator >(PositiveDouble p1, PositiveDouble p2)
        {
            return p1.Value > p2.Value;
        }

        public static bool operator >=(PositiveDouble p1, PositiveDouble p2)
        {
            return p1.Value >= p2.Value;
        }

        public static bool operator <=(PositiveDouble p1, PositiveDouble p2)
        {
            return p1.Value <= p2.Value;
        }
    }
}
