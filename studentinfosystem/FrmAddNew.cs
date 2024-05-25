using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace studentinfosystem
{
    public partial class FrmAddNew : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlCommand cmd2;

        public FrmAddNew()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void FillDept()
        {
            string connectionString = "server=DESKTOP-8QQD2EQ; Initial Catalog=StudentAppDB; Integrated Security=True; Encrypt=True; TrustServerCertificate=True;";

            using (SqlConnection c = new SqlConnection(connectionString))
            {
                try
                {
                    c.Open();

                    // Bölüm isimlerini doldur
                    string query = "SELECT DepartmentName FROM Department";
                    SqlCommand cmd = new SqlCommand(query, c);
                    SqlDataReader reader = cmd.ExecuteReader();
                    cbDept.Items.Clear();

                    while (reader.Read())
                    {
                        string item = reader["DepartmentName"].ToString();
                        cbDept.Items.Add(item);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
        }

        void FillCourses(int departmentIndex)
        {
            string connectionString = "server=DESKTOP-8QQD2EQ; Initial Catalog=StudentAppDB; Integrated Security=True; Encrypt=True; TrustServerCertificate=True;";

            using (SqlConnection c = new SqlConnection(connectionString))
            {
                try
                {
                    c.Open();

                    string q2 = "SELECT CourseName FROM Course WHERE Course.DepartmentID = @DepartmentID";
                    SqlCommand cmd2 = new SqlCommand(q2, c);
                    cmd2.Parameters.AddWithValue("@DepartmentID", departmentIndex + 1);

                    SqlDataReader reader = cmd2.ExecuteReader();
                    cbCourse.Items.Clear();

                    while (reader.Read())
                    {
                        string item = reader["CourseName"].ToString();
                        cbCourse.Items.Add(item);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
        }


        //void FillCourse()
        //{
        //    string connectionString = "server=DESKTOP-8QQD2EQ; Initial Catalog=StudentAppDB; Integrated Security=True; Encrypt=True; TrustServerCertificate=True;";

        //    using (SqlConnection c = new SqlConnection(connectionString))
        //    {
        //        int departmentID = cbDept.SelectedIndex + 1;
        //        string query = "SELECT C.CourseName FROM Course C WHERE C.DepartmentID = @DepartmentID";
        //        SqlCommand cmd = new SqlCommand(query, c);

        //        cmd.Parameters.AddWithValue("@DepartmentID", departmentID);

        //        try
        //        {
        //            c.Open();
        //            SqlDataReader reader = cmd.ExecuteReader();

        //            cbCourse.Items.Clear(); // Mevcut öğeleri temizle

        //            while (reader.Read())
        //            {
        //                string item = reader["CourseName"].ToString();
        //                cbCourse.Items.Add(item);
        //            }

        //            reader.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Bir hata oluştu: " + ex.Message);
        //        }
        //        finally
        //        {
        //            c.Close();
        //        }
        //    }
        //}


        private void AddNew()
        {
            string connectionString = "server=DESKTOP-8QQD2EQ; Initial Catalog=StudentAppDB; Integrated Security=True; Encrypt=True; TrustServerCertificate=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Student(FirstName, LastName, Class, Number, DepartmentID) VALUES (@FirstName, @LastName, @Class, @Number, @DepartmentID); SELECT SCOPE_IDENTITY();";
                string query2 = "INSERT INTO Assignment(StudentID, Topic, AssignmentDate, SubmissionDate, Grade, CourseID) VALUES (@StudentID, @Topic, @AssignmentDate, @SubmissionDate, @Grade, @CourseID)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlCommand cmd2 = new SqlCommand(query2, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", txtName.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtSurname.Text);
                    cmd.Parameters.AddWithValue("@Class", txtClass.Text);
                    cmd.Parameters.AddWithValue("@Number", int.Parse(txtNumber.Text)); // Assuming there's a txtNumber field for the student's number
                    cmd.Parameters.AddWithValue("@DepartmentID", cbDept.SelectedIndex + 1);

                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();
                    cmd.Transaction = transaction;
                    cmd2.Transaction = transaction;

                    try
                    {
                        // Execute the first command and get the new StudentID
                        int studentID = Convert.ToInt32(cmd.ExecuteScalar());

                        // Get the CourseID
                        string query3 = "SELECT ID FROM Course WHERE CourseName = @CourseName";
                        SqlCommand cmd3 = new SqlCommand(query3, conn, transaction);
                        cmd3.Parameters.AddWithValue("@CourseName", cbCourse.SelectedItem.ToString());
                        int courseID = Convert.ToInt32(cmd3.ExecuteScalar());

                        // Add parameters for the second command
                        cmd2.Parameters.AddWithValue("@StudentID", studentID);
                        cmd2.Parameters.AddWithValue("@Topic", txtTopic.Text);
                        cmd2.Parameters.AddWithValue("@AssignmentDate", dateTimePicker1.Value);
                        cmd2.Parameters.AddWithValue("@SubmissionDate", dateTimePicker2.Value);
                        cmd2.Parameters.AddWithValue("@Grade", int.Parse(txtGrade.Text));
                        cmd2.Parameters.AddWithValue("@CourseID", courseID);

                        // Execute the second command
                        cmd2.ExecuteNonQuery();

                        // Commit the transaction
                        transaction.Commit();

                        MessageBox.Show("Öğrenci ve ödev başarıyla eklendi!");
                    }
                    catch (SqlException ex)
                    {
                        // Rollback the transaction in case of error
                        transaction.Rollback();
                        MessageBox.Show("Bir SQL hatası oluştu: " + ex.Message);
                    }
                    catch (FormatException ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Bir format hatası oluştu: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Bir hata oluştu: " + ex.Message);
                    }
                }
            }

            FillDept();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            AddNew();
        }

        private void FrmAddNew_Load(object sender, EventArgs e)
        {
            FillDept();

        }

        private void cbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillCourses(cbDept.SelectedIndex);
        }
    }
}
