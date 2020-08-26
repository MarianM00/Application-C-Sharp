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
    public partial class Clientapp : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NP1RDM2\BAZALUIMARIAN;Initial Catalog=task;Persist Security Info=True;User ID=sa; Password = 0299");
        public Clientapp()
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
          
            if (TxtFirstname.Text == "")
            {
                MessageBox.Show("Please enter confirm password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtFirstname.Focus();
                return;
            }
            if (TxtFamilyname.Text == "")
            {
                MessageBox.Show("Please enter username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtFamilyname.Focus();
                return;
            }

            if (TxtData.Text == "")
            {
                MessageBox.Show("Please enter username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtData.Focus();
                return;
            }
            if (TxtNumber.Text == "")
            {
                MessageBox.Show("Please enter username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtNumber.Focus();
                return;
            }
            try
            {
                SqlConnection myConnection = default(SqlConnection);
                myConnection = new SqlConnection(@"Data Source=DESKTOP-NP1RDM2\BAZALUIMARIAN;Initial Catalog=task;Persist Security Info=True;User ID=sa; Password = 0299");
                 String query = "INSERT INTO dbo.Clientapp (family_name,first_name,clientappdate,number) VALUES (@family_name,@first_name,@clientappdate,@number)";

                using (SqlCommand command = new SqlCommand(query, con))
                {      
                    command.Parameters.AddWithValue("@family_name", TxtFamilyname.Text);
                    command.Parameters.AddWithValue("@first_name", TxtFirstname.Text);
                    command.Parameters.AddWithValue("@clientappdate", TxtData.Text);
                    command.Parameters.AddWithValue("@number", TxtNumber.Text);

                    MessageBox.Show("Register successfully !We will call you back today !", "Register Successfully", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    con.Open();
                    int result = command.ExecuteNonQuery();
                    Hide();

                    // Check Error
                    if (result < 0)
                    {
                        MessageBox.Show("Register Denied", "Register Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TxtNumber.Clear();
                        TxtFirstname.Clear();
                        TxtFamilyname.Clear();
                        TxtData.Clear();
                        TxtFamilyname.Focus();
                        Close();
                    }

                   

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
