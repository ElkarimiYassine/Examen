using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (question1.Text.Trim().Length == 0)
            {
                MessageBox.Show("Question est vide !");
                return;
            }
            if (reponse1.Text.Trim().Length == 0)
            {
                MessageBox.Show("Reponse est vide !");
                return;
            }
            if (point1.Text.Trim().Length == 0)
            {
                MessageBox.Show("Point est vide !");
                return;
            }
            if (penalite1.Text.Trim().Length == 0)
            {
                MessageBox.Show("Penalite est vide !");
                return;
            }
            string Questiontype = "Question ouverte";
           
                Question question = new Question(question1.Text.Trim(), reponse1.Text.Trim(), Convert.ToSingle(point1.Text.Trim()), Convert.ToSingle(penalite1.Text.Trim()),Questiontype);
                Database.AddQuestion(question);
                clear();
        }
        public void clear()
        {
            question1.Clear();
            reponse1.Clear();
            point1.Clear();
            penalite1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (question2.Text.Trim().Length == 0)
            {
                MessageBox.Show("Question est vide !");
                return;
            }
            if (reponse2.Text.Trim().Length == 0)
            {
                MessageBox.Show("Reponse est vide !");
                return;
            }
            if (point2.Text.Trim().Length == 0)
            {
                MessageBox.Show("Point est vide !");
                return;
            }
            if (penalite2.Text.Trim().Length == 0)
            {
                MessageBox.Show("Penalite est vide !");
                return;
            }
            if (choix1.Text.Trim().Length == 0)
            {
                MessageBox.Show("choix 1 est vide !");
                return;
            }
            if (choix2.Text.Trim().Length == 0)
            {
                MessageBox.Show("choix 2 est vide !");
                return;
            }
            if (choix3.Text.Trim().Length == 0)
            {
                MessageBox.Show("choix 3 est vide !");
                return;
            }
            string Questiontype = "Question choix multiple";
            QCM qcm = new QCM(question2.Text.Trim(), reponse2.Text.Trim(), Convert.ToSingle(point2.Text.Trim()), Convert.ToSingle(penalite2.Text.Trim()), Questiontype, choix1.Text.Trim(), choix2.Text.Trim(), choix3.Text.Trim());
            Database.AddQCM(qcm);
            clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {

           /* bool r = false;
            if (question3.Text.Trim().Length == 0)
            {
                MessageBox.Show("Question est vide !");
                return;
            }
            if (! vrai.Checked && ! Faux.Checked || vrai.Checked && Faux.Checked)
            {
                MessageBox.Show("choisissez vrai ou faux !");
                return;
            }
            if (point3.Text.Trim().Length == 0)
            {
                MessageBox.Show("Point est vide !");
                return;
            }
            if (penalite3.Text.Trim().Length == 0)
            {
                MessageBox.Show("Penalite est vide !");
                return;
            }
            string Questiontype = "Question Dichotomie";
            if(vrai.Checked)
            {
                r = true;
            }else if(Faux.Checked)
            {
                r = false;
            }
            string res = "";
            Dichotomie dichotomie = new Dichotomie(r, question3.Text.Trim(), Convert.ToSingle(point3.Text.Trim()), Convert.ToSingle(penalite3.Text.Trim()), Questiontype, res);
            Database.AddDichotomie(dichotomie);
            clear();*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();
        }
    }
}
