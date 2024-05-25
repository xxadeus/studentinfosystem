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

namespace studentinfosystem
{
    public partial class FrmShow : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapter;

        public FrmShow()
        {
            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        void ShowStudents()
        {
            conn = new SqlConnection("server= DESKTOP-8QQD2EQ; Initial Catalog=StudentAppDB; Integrated Security=True; Encrypt=True; TrustServerCertificate=True;");
            conn.Open();
            adapter = new SqlDataAdapter("SELECT S.FirstName, S.LastName, S.Class, S.Number, D.DepartmentName\r\nFROM Student S \r\nLEFT JOIN Department D ON D.ID = S.DepartmentID", conn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            conn.Close();
        }
        private void SearchStudent()
        {
            string connectionString = "server=DESKTOP-8QQD2EQ; Initial Catalog=StudentAppDB; Integrated Security=True; Encrypt=True; TrustServerCertificate=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT S.FirstName, S.LastName, S.Class, S.Number, D.DepartmentName
                         FROM Student S
                         INNER JOIN Department D ON D.ID = S.DepartmentID
                         WHERE S.Number = @Number";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Number", int.Parse(textBox1.Text));

                    try
                    {
                        conn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Assuming you have a DataGridView control named dataGridView1
                        dataGridView1.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bir hata oluştu: " + ex.Message);
                    }
                }
            }
        }

        private void FrmShow_Load(object sender, EventArgs e)
        {
            ShowStudents();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowStudents();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SearchStudent();
        }
    }
}
