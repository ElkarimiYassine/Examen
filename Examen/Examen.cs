using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen
{
    class Examen
    {
        public string Intitule { get; set; }
        public int Duree { get; set; }
        public byte Statue { get; set; }
        public string Createur { get; set; }
        public Decimal Moyenne { get; set; }

        public Examen(string intitule, int duree, byte statue, string createur, Decimal moyenne)
        {
            Intitule = intitule;
            Duree = duree;
            Statue = statue;
            Createur = createur;
            Moyenne = moyenne;
        }
    }
}
