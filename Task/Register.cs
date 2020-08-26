using System;
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
    public partial class Register : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NP1RDM2\BAZALUIMARIAN;Initial Catalog=task;Persist Security Info=True;User ID=sa; Password = 0299");
        public Register()
        {
            InitializeComponent();
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
        //text-box username
        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //Password 
        private void Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }
        //button register
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(rezult);
            if (TxtPassword.Text == "")
            {
                MessageBox.Show("Please enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtPassword.Focus();
                return;
            }
            if (TxtPassword2.Text == "")
            {
                MessageBox.Show("Please enter confirm password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtPassword.Focus();
                return;
            }
            if (TxtUsername.Text == "")
            {
                MessageBox.Show("Please enter username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtPassword.Focus();
                return;
            }
            try
            {
                SqlConnection myConnection = default(SqlConnection);
                myConnection = new SqlConnection(@"Data Source=DESKTOP-NP1RDM2\BAZALUIMARIAN;Initial Catalog=task;Persist Security Info=True;User ID=sa; Password = 0299");

               

              
                if (TxtPassword.Text == TxtPassword2.Text)
                {
                   
                    String query = "INSERT INTO dbo.Users (NameUser,PasswordUser) VALUES (@UserName,@Password)";

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@UserName", TxtUsername.Text);
                        command.Parameters.AddWithValue("@Password", TxtPassword.Text);
                        MessageBox.Show("Register successfully !", "Register Successfully", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        con.Open();
                        int result = command.ExecuteNonQuery();

                        // Check Error
                        if (result < 0)
                            Console.WriteLine("Error inserting data into Database!");
                        Close();
                    }
                }


            

                else
                {
                    MessageBox.Show("Register Denied", "Register Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtUsername.Clear();
                    TxtPassword.Clear();
                    TxtPassword2.Clear();
                    TxtUsername.Focus();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
    }
