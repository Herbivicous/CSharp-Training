using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.Client
{
    public interface IPerson
    {
        public string Nom { get; }

        public string Prenom { get; }

        public DateTime Naissance { get; }

        public int GetAge();

        public int GetAge(DateTime now);
    }
}
