using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen
{
    internal class Dichotomie : Question
    {
        
        public bool Reponse  { get; set; }

        public Dichotomie(bool Reponse, string question, string reponse, float point, float penalite, string type) : base(question, reponse, point, penalite, type)
        {
            this.question = question;
            this.reponse = "";
            this.point = point;
            this.penalite = penalite;
            this.Reponse = Reponse;
            this.type= type;
        }
        public Dichotomie(bool Reponse, string question, float point, float penalite, string type, string reponse) : base(question, reponse, point, penalite, type)
        {
            this.question = question;
           // this.reponse = "";
            this.point = point;
            this.penalite = penalite;
            this.Reponse = Reponse;
            this.type= type;
        }
    }
}
