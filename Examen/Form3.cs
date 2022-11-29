using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        public void Display()
        {
            Database.DisplayAndSearch("SELECT * FROM question;", dataGridView1);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("ID est vide !");
                return;
            }
            Examen examen;
            Database.DeleteQuestion(Convert.ToInt32(textBox1.Text));
            this.Display();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("ID est vide !");
                return;
            }
            if (textquestion.Text.Trim().Length == 0)
            {
                MessageBox.Show("Question est vide !");
                return;
            }
            if (textreponse.Text.Trim().Length == 0)
            {
                MessageBox.Show("Reponse est vide !");
                return;
            }
            if (textpoint.Text.Trim().Length == 0)
            {
                MessageBox.Show("Point est vide !");
                return;
            }
            if (textpenalite.Text.Trim().Length == 0)
            {
                MessageBox.Show("Penalite est vide !");
                return;
            }
            string Questiontype = "Question ouverte";

            Question question = new Question(textquestion.Text.Trim(), textreponse.Text.Trim(), Convert.ToSingle(textpoint.Text.Trim()), Convert.ToSingle(this.textpenalite.Text.Trim()), Questiontype);
            Database.UpdateQuestion(question,Convert.ToInt32(textBox1.Text.Trim()));
  
        }
    }
}
