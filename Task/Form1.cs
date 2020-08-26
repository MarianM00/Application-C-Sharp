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
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NP1RDM2\BAZALUIMARIAN;Initial Catalog=task;Persist Security Info=True;User ID=sa; Password = 0299");
        public Form1()
        {
            InitializeComponent();
        }
        string setValue(string column,string box,string Numele)
        {
            SqlCommand cmd = new SqlCommand("select UserA from Users where NameUser=" + "'" + Numele+"'") ;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            using (SqlDataReader sdr = cmd.ExecuteReader())
            {
                sdr.Read();
                box = sdr[0].ToString();

            }
            return box;
            con.Close();
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

        private void BtnLogin_Click(object sender, EventArgs e)
        {
           
            
            //MessageBox.Show(rezult);
            if (TxtPassword.Text == "")
            {
                MessageBox.Show("Please enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtPassword.Focus();
                return;
            }
            try
            {
                SqlConnection myConnection = default(SqlConnection);
                myConnection = new SqlConnection(@"Data Source=DESKTOP-NP1RDM2\BAZALUIMARIAN;Initial Catalog=task;Persist Security Info=True;User ID=sa; Password = 0299");

                SqlCommand myCommand = default(SqlCommand);

                myCommand = new SqlCommand("SELECT NameUser,PasswordUser FROM Users WHERE NameUser = @NameUser AND PasswordUser = @PasswordUser", myConnection);

                SqlParameter uName = new SqlParameter("@NameUser", SqlDbType.VarChar);
                SqlParameter uPassword = new SqlParameter("@PasswordUser", SqlDbType.VarChar);


                uName.Value = TxtUsername.Text;
                uPassword.Value = TxtPassword.Text;

                myCommand.Parameters.Add(uName);
                myCommand.Parameters.Add(uPassword);

                myCommand.Connection.Open();

                SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

                if (myReader.Read() == true)
                {
                        string rezult = "";
                        string NameUser = "NameUser";
                        rezult = setValue(NameUser, rezult, TxtUsername.Text);
                        if (rezult == "0")
                    {
                        Clients newForm = new Clients();
                        newForm.ShowDialog(this);
                       
                    }
                    else
                    {
                        Admins newForm = new Admins();
                        newForm.ShowDialog(this);
                    }

                    con.Close();   
                }


                else
                {
                    MessageBox.Show("Login Failed...Try again !", "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    TxtUsername.Clear();
                    TxtPassword.Clear();
                    TxtUsername.Focus();

                }
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Register newForm = new Register();
            newForm.ShowDialog(this);
        }
    }
    }
