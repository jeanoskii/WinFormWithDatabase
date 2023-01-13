using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseExample
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection("" +
                "Data Source=(LocalDB)\\MSSQLLocalDB;" +
                "AttachDbFilename=C:\\Users\\T450s\\source\\repos\\DatabaseExample\\DatabaseExample\\MyDB.mdf;" +
                "Integrated Security=True");


        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Student VALUES ('"
                + txtStudentID.Text
                + "','" + txtLastName.Text
                + "','" + txtFirstName.Text
                + "','" + txtMiddleInitial.Text
                + "','" + txtAge.Text + "')";
            cmd.ExecuteNonQuery();
            Console.WriteLine("New record added to Student table");


            conn.Close();
            LoadGridView();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadGridView();
        }

        private void LoadGridView()
        {

            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Student";
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

            conn.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Student WHERE StudentID = "
                + txtDeleteStudentId.Text;
            cmd.ExecuteNonQuery();
            Console.WriteLine("Record deleted from Student table");


            conn.Close();
            LoadGridView();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Student SET"
                + " LastName = '" + txtUpdateLastName.Text +"',"
                + " FirstName = '" + txtUpdateFirstName.Text + "', "
                + " MiddleInitial = '" + txtUpdateMiddleInitial.Text + "',"
                + " Age = '" + txtUpdateAge.Text + "'"
                + " WHERE StudentID = " + txtUpdateStudentID.Text;
            cmd.ExecuteNonQuery();
            Console.WriteLine("Record updated from Student table");


            conn.Close();
            LoadGridView();
        }
    }
}
