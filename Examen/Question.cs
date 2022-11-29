using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen
{
    class Question
    {
        public string question { get; set; }
        public string reponse { get; set; }
        public float point { get; set;}
        public float penalite { get; set; }
        public string type { get; set; }

        public Question(string question, string reponse, float point, float penalite, string type)
        {
            this.question = question;
            this.reponse = reponse;
            this.point = point;
            this.penalite = penalite;
            this.type = type;
        }
    }
}
