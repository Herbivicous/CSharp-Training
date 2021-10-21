using System;

namespace TP.Utils
{
    public class MoneyUtils
    {
        public static double EuroToDollar(double euroAmount)
        {
            return 1.16 * euroAmount;
        }
        public static double DollarToEuro(double dollarAmount)
        {
            return (1/1.16) * dollarAmount;
        }
    }
}
