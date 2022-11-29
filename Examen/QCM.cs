using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Examen
{
    class QCM : Question
    {
       
        public string first_choice { get; set; }
        public string sec_choice { get; set; }
        public string third_choice { get; set; }

        public QCM(string question, string reponse, float point, float penalite, string first_choice, string sec_choice, string third_choice,string type) : base(question, reponse, point, penalite,type)
        {
            this.question = question;
            this.reponse = reponse;
            this.point = point;
            this.penalite = penalite;
            this.first_choice = first_choice;
            this.sec_choice = sec_choice;
            this.third_choice = third_choice;
            this.type=type;
        }
    }
}
