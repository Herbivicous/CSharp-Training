using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.Client
{
    public class Person : IPerson
    {
        public string Nom { get; init; }

        public string Prenom { get; init; }

        public DateTime Naissance { get; init; }

        public Person(string nom, string prenom, DateTime naissance)
        {
            Nom = nom;
            Prenom = prenom;
            Naissance = naissance;
        }

        public int GetAge() => this.GetAge(DateTime.Now);

        public int GetAge(DateTime now)
        {
            TimeSpan nowFromBeginingOfTheYear = now - new DateTime(now.Year, 1, 1);
            TimeSpan naissanceFromBeginingOfTheYear = Naissance - new DateTime(Naissance.Year, 1, 1);
            return now.Year - Naissance.Year - (nowFromBeginingOfTheYear < naissanceFromBeginingOfTheYear ? 1 : 0);
        }

        public override string ToString()
        {
            return $"{Nom.ToUpper()} {Prenom}";
        }
    }
}
