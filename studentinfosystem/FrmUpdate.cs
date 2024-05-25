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
    public partial class FrmUpdate : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlCommand cmd2;
        SqlDataAdapter adapter;
        public FrmUpdate()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtName.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtSurname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtClass.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtNumber.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            cbDept.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            cbCourse.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtTopic.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txtGrade.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
        }

        void SearchStudent()
        {
            string connectionString = "server=DESKTOP-8QQD2EQ; Initial Catalog=StudentAppDB; Integrated Security=True; Encrypt=True; TrustServerCertificate=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Gerekli tüm alanları içeren sorgu
                string query = @"
            SELECT 
                S.FirstName, S.LastName, S.Class, S.Number, 
                D.DepartmentName, C.CourseName, 
                A.Topic, A.AssignmentDate, A.SubmissionDate, A.Grade
            FROM Student S
            LEFT JOIN Department D ON D.ID = S.DepartmentID
            LEFT JOIN Assignment A ON A.StudentID = S.ID
            LEFT JOIN Course C ON A.CourseID = C.ID
            WHERE S.FirstName = @FirstName";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", textBox1.Text);

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


        private void button3_Click(object sender, EventArgs e)
        {
            SearchStudent();
        }

        void UpdateRec()
        {
            string connectionString = "server=DESKTOP-8QQD2EQ; Initial Catalog=StudentAppDB; Integrated Security=True; Encrypt=True; TrustServerCertificate=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string q1 = "UPDATE Student SET FirstName = @FirstName, LastName = @LastName, Class = @Class, Number = @Number, DepartmentID = @DepartmentID WHERE Number = @Number";
                string q2 = "UPDATE Assignment SET CourseID = @CourseID, Topic = @Topic, AssignmentDate = @AssignmentDate, SubmissionDate = @SubmissionDate, Grade = @Grade WHERE StudentID = (SELECT ID FROM Student WHERE Number = @Number)";
                string query3 = "SELECT ID FROM Course WHERE CourseName = @CourseName";

                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd3 = new SqlCommand(query3, conn, transaction))
                        {


                            cmd3.Parameters.AddWithValue("@CourseName", cbCourse.SelectedItem.ToString());
                            int courseID = Convert.ToInt32(cmd3.ExecuteScalar());

                            using (SqlCommand cmd = new SqlCommand(q1, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@FirstName", txtName.Text);
                                cmd.Parameters.AddWithValue("@LastName", txtSurname.Text);
                                cmd.Parameters.AddWithValue("@Class", txtClass.Text);
                                cmd.Parameters.AddWithValue("@Number", int.Parse(txtNumber.Text));
                                cmd.Parameters.AddWithValue("@DepartmentID", cbDept.SelectedIndex + 1);

                                cmd.ExecuteNonQuery();
                            }

                            using (SqlCommand cmd2 = new SqlCommand(q2, conn, transaction))
                            {
                                cmd2.Parameters.AddWithValue("@CourseID", courseID);
                                cmd2.Parameters.AddWithValue("@Topic", txtTopic.Text);
                                cmd2.Parameters.AddWithValue("@AssignmentDate", dateTimePicker1.Value);
                                cmd2.Parameters.AddWithValue("@SubmissionDate", dateTimePicker2.Value);
                                cmd2.Parameters.AddWithValue("@Grade", int.Parse(txtGrade.Text));
                                cmd2.Parameters.AddWithValue("@Number", int.Parse(txtNumber.Text));

                                cmd2.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                        MessageBox.Show("Record updated successfully!");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Bir hata oluştu: " + ex.Message);
                    }
                }
                conn.Close();
            }

            // ComboBox'ları doldurmak için metotları çağırın
            FillDept();
            if (cbDept.SelectedIndex != -1)
            {
                FillCourses(cbDept.SelectedIndex + 1);
            }
        }
        int GetAssignmentId(string topic)
        {
            string connectionString = "server=DESKTOP-8QQD2EQ; Initial Catalog=StudentAppDB; Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT A.ID FROM Assignment A WHERE A.Topic = @Topic";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Topic", topic);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while retrieving the AssignmentID: " + ex.Message);
                }
            }
            return -1;

        }
        private void DeleteAssignmentById(int assignmentId)
        {
            string connectionString = "server=DESKTOP-8QQD2EQ; Initial Catalog=StudentAppDB; Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM Assignment WHERE ID = @AssignmentID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@AssignmentID", assignmentId);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Assignment successfully deleted!");
                        }
                        else
                        {
                            MessageBox.Show("No assignment found with the given ID.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
        void FillDept()
        {
            string connectionString = "server=DESKTOP-8QQD2EQ; Initial Catalog=StudentAppDB; Integrated Security=True; Encrypt=True; TrustServerCertificate=True;";

            using (SqlConnection c = new SqlConnection(connectionString))
            {
                string query = "SELECT DepartmentName FROM Department";

                SqlCommand cmd = new SqlCommand(query, c);

                try
                {
                    c.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    cbDept.Items.Clear();

                    while (reader.Read())
                    {
                        cbDept.Items.Add(reader["DepartmentName"].ToString());
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
                finally
                {
                    c.Close();
                }
            }
        }

        void FillCourses(int departmentID)
        {
            string connectionString = "server=DESKTOP-8QQD2EQ; Initial Catalog=StudentAppDB; Integrated Security=True; Encrypt=True; TrustServerCertificate=True;";

            using (SqlConnection c = new SqlConnection(connectionString))
            {
                string query = "SELECT CourseName FROM Course WHERE DepartmentID = @DepartmentID";
                SqlCommand cmd = new SqlCommand(query, c);
                cmd.Parameters.AddWithValue("@DepartmentID", departmentID);

                try
                {
                    c.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    cbCourse.Items.Clear();

                    while (reader.Read())
                    {
                        cbCourse.Items.Add(reader["CourseName"].ToString());
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
                finally
                {
                    c.Close();
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            UpdateRec();
        }

        private void FrmUpdate_Load(object sender, EventArgs e)
        {
            FillDept();
        }

        private void cbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDept.SelectedItem != null)
            {
                var selectedDepartment = (dynamic)cbDept.SelectedIndex;
                int departmentID = selectedDepartment + 1;
                FillCourses(departmentID);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
          int id = GetAssignmentId(txtTopic.Text);
            DeleteAssignmentById(id);
        }
    }
}
