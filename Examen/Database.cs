using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Examen
{
    class Database
    {
        public static MySqlConnection GetConnection()
        {
            string sql = "datasource=localhost;port=3306;username=root;password=;database=examen";
            MySqlConnection con= new MySqlConnection(sql);
            try
            {
                con.Open();
            }
            catch(MySqlException e)
            {
                MessageBox.Show("MySQL Connection ! \n "+ e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return con;
        }
        public static void  AddExam(Examen examen) 
        {
            string sql = "INSERT INTO examen VALUES (NULL, @intitule, @duree, @statue, @createur, @moyenne )";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@intitule", MySqlDbType.VarChar).Value = examen.Intitule;
            cmd.Parameters.Add("@duree", MySqlDbType.Int32).Value = examen.Duree;
            cmd.Parameters.Add("@statue", MySqlDbType.Bit).Value = examen.Statue;
            cmd.Parameters.Add("@createur", MySqlDbType.VarChar).Value = examen.Createur;
            cmd.Parameters.Add("@moyenne", MySqlDbType.Float).Value = examen.Moyenne;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ajouter avec succès", "Examen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException e)
            {
                MessageBox.Show("examen non inséré \n" + e.Message, "Error,", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public static void AddQuestion(Question question)
        {
            string sql = "INSERT INTO question VALUES (NULL, @question, @point, @penalite, @reponse, @type, NULL)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@question", MySqlDbType.VarChar).Value = question.question;
            cmd.Parameters.Add("@type", MySqlDbType.VarChar).Value = question.type;
            cmd.Parameters.Add("@reponse", MySqlDbType.VarChar).Value = question.reponse;
            cmd.Parameters.Add("@point", MySqlDbType.Float).Value = question.point;
            cmd.Parameters.Add("@penalite", MySqlDbType.Float).Value = question.penalite;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ajouter avec succès", "Question", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Question non inséré \n" + e.Message, "Error,", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        /*public static void AddDichotomie(Dichotomie dichotomie)
        {
            string sql = "INSERT INTO question VALUES (NULL, @question, @point, @penalite, @reponse, @type)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@question", MySqlDbType.VarChar).Value = dichotomie.question;
            cmd.Parameters.Add("@type", MySqlDbType.VarChar).Value = dichotomie.type;
            cmd.Parameters.Add("@reponse", MySqlDbType.VarChar).Value = dichotomie.Reponse;
            cmd.Parameters.Add("@point", MySqlDbType.Float).Value = dichotomie.point;
            cmd.Parameters.Add("@penalite", MySqlDbType.Float).Value = dichotomie.penalite;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ajouter avec succès", "Question", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Question non inséré \n" + e.Message, "Error,", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         con.Close();
        } */  
        public static void AddQCM(QCM qcm)
        {
            string sql = "INSERT INTO question VALUES (NULL, @question, @point, @penalite, @reponse, @type, @p_choix, @d_choix, @t_choix)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@question", MySqlDbType.VarChar).Value = qcm.question;
            cmd.Parameters.Add("@p_choix", MySqlDbType.VarChar).Value = qcm.first_choice;
            cmd.Parameters.Add("@d_choix", MySqlDbType.VarChar).Value = qcm.sec_choice;
            cmd.Parameters.Add("@t_choix", MySqlDbType.VarChar).Value = qcm.third_choice;
            cmd.Parameters.Add("@type", MySqlDbType.VarChar).Value = qcm.type;
            cmd.Parameters.Add("@reponse", MySqlDbType.VarChar).Value = qcm.reponse;
            cmd.Parameters.Add("@point", MySqlDbType.Float).Value = qcm.point;
            cmd.Parameters.Add("@penalite", MySqlDbType.Float).Value = qcm.penalite;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ajouter avec succès", "QCM", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException e)
            {
                MessageBox.Show("QCM non inséré \n" + e.Message, "Error,", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public static void UpdateExam(Examen examen , int id)
        {
            Form2 f2 = new Form2();
            string sql = "UPDATE examen SET intitule = @intitule, duree = @duree, statue = @statue, createur = @createur, moyenne = @moyenne Where id = " + id + "";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.Add("@intitule", MySqlDbType.VarChar).Value = examen.Intitule;
            cmd.Parameters.Add("@duree", MySqlDbType.Int32).Value = examen.Duree;
            cmd.Parameters.Add("@statue", MySqlDbType.Bit).Value = examen.Statue;
            cmd.Parameters.Add("@createur", MySqlDbType.VarChar).Value = examen.Createur;
            cmd.Parameters.Add("@moyenne", MySqlDbType.Float).Value = examen.Moyenne;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Modifier avec succès", "Examen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException e)
            {
                MessageBox.Show("examen non Modifier \n" + e.Message, "Error,", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public static void UpdateQuestion(Question question, int id)
        {
            Form2 f2 = new Form2();
            string sql = "UPDATE question SET question =  @question, point = @point, penalite = @penalite, reponse = @reponse Where id = " + id + "";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@question", MySqlDbType.VarChar).Value = question.question;
            cmd.Parameters.Add("@reponse", MySqlDbType.VarChar).Value = question.reponse;
            cmd.Parameters.Add("@point", MySqlDbType.Float).Value = question.point;
            cmd.Parameters.Add("@penalite", MySqlDbType.Float).Value = question.penalite;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Modifier avec succès", "Examen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException e)
            {
                MessageBox.Show("examen non Modifier \n" + e.Message, "Error,", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public static void DeleteExam(int id)
        {
            Form2 f2 = new Form2();

            string sql = "DELETE FROM examen WHERE id=" + id + "";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Supprimer avec succès", "Examen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException e)
            {
                MessageBox.Show("examen non Supprimer" + e.Message, "Error,", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public static void DeleteQuestion(int id)
        {
            Form2 f2 = new Form2();

            string sql = "DELETE FROM question WHERE id=" + id + "";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Supprimer avec succès", "Examen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException e)
            {
                MessageBox.Show("examen non Supprimer" + e.Message, "Error,", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public static void SelectExam(int id)
        {
            Form2 f2 = new Form2();

            string sql = "SELECT * FROM examen WHERE id=" + id + "";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Selectionner avec succès", "Examen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException e)
            {
                MessageBox.Show("examen non selectionné" + e.Message, "Error,", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public static void DisplayAndSearch(string q, DataGridView dgv)
        {
            string sql = q;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dgv.DataSource =tbl ;
            con.Close();

        }
    }
}
