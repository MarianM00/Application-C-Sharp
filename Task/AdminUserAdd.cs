using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Task
{   
    public partial class AdminUserAdd : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NP1RDM2\BAZALUIMARIAN;Initial Catalog=task;Persist Security Info=True;User ID=sa; Password = 0299");
        public AdminUserAdd()
        {
            InitializeComponent();
        }
        

        private void currentPosition()
        {
            

        }

        
        //panel
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        //IMAGE logo
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        //close button
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //restore down
        private void pictureBox3_Click(object sender, EventArgs e)
        {
        
          
        }
        //minimize
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        //text-box username
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //Password 
        private void Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void AdminUser_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'taskDataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.taskDataSet.Users);

        }

        private void bunifuLabel5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.usersBindingSource.MoveNext();
            currentPosition();

           
        }
        private static void CreateCommand(string queryString, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection myConnection = default(SqlConnection);
                myConnection = new SqlConnection(@"Data Source=DESKTOP-NP1RDM2\BAZALUIMARIAN;Initial Catalog=task;Persist Security Info=True;User ID=sa; Password = 0299");




                {

                    String query = "INSERT INTO dbo.Users (NameUser,PasswordUser,UserA) VALUES (@UserName,@Password,@UserA)";

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@UserName", TxtUserName.Text);
                        
                        command.Parameters.AddWithValue("@Password", TxtPassword.Text);
                        command.Parameters.AddWithValue("@UserA", TxtUserA.Text);
                        MessageBox.Show("Save with successfully !", "Save with successfully", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        con.Open();
                        int result = command.ExecuteNonQuery();

                        // Check Error
                        if (result < 0)
                        {
                            MessageBox.Show("Save with successfully", "Save with successfully", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            
                            TxtUserName.Clear();
                            TxtUserA.Clear();
                            TxtPassword.Clear();
                            TxtUserName.Focus();
                        }
                        
                    }
                }




              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            this.usersBindingSource.MovePrevious();
            currentPosition();

        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            
            this.usersBindingSource.MoveFirst();
            currentPosition();
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            this.usersBindingSource.MoveLast();
            currentPosition();
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void TxtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }
