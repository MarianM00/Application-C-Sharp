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
    public partial class Admins : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NP1RDM2\BAZALUIMARIAN;Initial Catalog=task;Persist Security Info=True;User ID=sa; Password = 0299");
        public Admins()
        {
            InitializeComponent();
        }
        string setValue(string column,string box)
        {
            SqlCommand cmd = new SqlCommand("select UserA from Users where UserA = 1;");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            using (SqlDataReader sdr = cmd.ExecuteReader())
            {
                sdr.Read();
                box = sdr[column].ToString();

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
        //Password 
        private void Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void BtnUsers_Click(object sender, EventArgs e)
        {
            AdminUser newForm = new AdminUser();
            newForm.ShowDialog(this);
            
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            AdminDoctor newForm = new AdminDoctor();
            newForm.ShowDialog(this);
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            AdminPatient newform = new AdminPatient();
            newform.ShowDialog(this);
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            AdminAppointments newform = new AdminAppointments();
            newform.ShowDialog(this);
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            AdminClientApp newform = new AdminClientApp();
            newform.ShowDialog(this);
        }
    }
    }
