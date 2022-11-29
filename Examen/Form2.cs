using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Examen
{
    
    public partial class Form2 : Form
    {
        
        public Form2()
        {

            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(intitule.Text.Trim().Length == 0)
            {
                MessageBox.Show("Intitule est vide !");
                return;
            }
            if(duree.Text.Trim().Length == 0)
            {
                MessageBox.Show("Duree est vide !");
                return;
            }
            if(statue.Text.Trim().Length == 0)
            {
                MessageBox.Show("Statue est vide !");
                return;
            }
            if(createur.Text.Trim().Length == 0)
            {
                MessageBox.Show("Createur est vide !");
                return;
            }
            if(moyenne.Text.Trim().Length == 0)
            {
                MessageBox.Show("Moyenne est vide !");
                return;
            }
            int d = Convert.ToInt32(this.duree.Text.Trim());
            byte s = Convert.ToByte(this.statue.Text.Trim());
            Decimal m = Convert.ToDecimal(this.moyenne.Text.Trim());
            if (Ajouter.Text == "Ajouter")
            {
                Examen examen = new Examen(intitule.Text.Trim(), d, s, createur.Text.Trim(), m);
                Database.AddExam(examen);
                clear(); 
            }
            this.Display();
        }
        public void clear()
        {
            intitule.Clear();
            duree.Clear();
            statue.Clear();
            createur.Clear();
            moyenne.Clear();
        }

        public void Display()
        {
            Database.DisplayAndSearch("SELECT * FROM examen;", dataGridView1);
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                intitule.Text = row.Cells["Column2"].Value.ToString();
                duree.Text = row.Cells["Column3"].Value.ToString();
                statue.Text = row.Cells["Column4"].Value.ToString();
                createur.Text = row.Cells["Column5"].Value.ToString();
                moyenne.Text = row.Cells["Column6"].Value.ToString();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Display();
           
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            Database.DisplayAndSearch("SELECT id, intitule, duree, statue, createur, moyenne FROM examen WHERE intitule LIKE '%" + search.Text + "%'", dataGridView1);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Supprimer_Click(object sender, EventArgs e)
        {
            if (id.Text.Trim().Length == 0)
            {
                MessageBox.Show("ID est vide !");
                return;
            }
            Examen examen ;
            Database.DeleteExam(Convert.ToInt32(id.Text));
            clear();
            this.Display();
        }

        private void id_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void Modifier_Click(object sender, EventArgs e)
        {
            if (id.Text.Trim().Length == 0)
            {
                MessageBox.Show("ID est vide !");
                return;
            }
            if (intitule.Text.Trim().Length == 0)
            {
                MessageBox.Show("Intitule est vide !");
                return;
            }
            if (duree.Text.Trim().Length == 0)
            {
                MessageBox.Show("Duree est vide !");
                return;
            }
            if (statue.Text.Trim().Length == 0)
            {
                MessageBox.Show("Statue est vide !");
                return;
            }
            if (createur.Text.Trim().Length == 0)
            {
                MessageBox.Show("Createur est vide !");
                return;
            }
            if (moyenne.Text.Trim().Length == 0)
            {
                MessageBox.Show("Moyenne est vide !");
                return;
            }
            int d = Convert.ToInt32(this.duree.Text.Trim());
            byte s = Convert.ToByte(this.statue.Text.Trim());
            Decimal m = Convert.ToDecimal(this.moyenne.Text.Trim());
 
                Examen examen = new Examen(intitule.Text.Trim(), d, s, createur.Text.Trim(), m);
                int a = Convert.ToInt32(id.Text);
                Database.UpdateExam(examen,a);
                clear();
                this.Display();
           
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if(id.Text.Trim().Length == 0)
            {
                MessageBox.Show("ID est vide !");
                return;
            }
            Examen examen;
            Database.SelectExam(Convert.ToInt32(id.Text));
            clear();
            this.Display();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
