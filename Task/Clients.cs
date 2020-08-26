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
    public partial class Clients : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NP1RDM2\BAZALUIMARIAN;Initial Catalog=task;Persist Security Info=True;User ID=sa; Password = 0299");
        public Clients()
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

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            con.Open();
            cmd.CommandText = "select NameDoctor from Doctors";
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adap.Fill(ds);
            bunifuDataGridView1.DataSource = ds.Tables[0].DefaultView;
            con.Close();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            con.Open();
            cmd.CommandText = "Select NameDoctor,SalaryNr from Doctors inner join Salary on doctors.CodeDoctor = salary.CodeDoctor where SalaryNr like " + bunifuTextBox1.Text;
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adap.Fill(ds);
            bunifuDataGridView1.DataSource = ds.Tables[0].DefaultView;
            con.Close();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            con.Open();
            cmd.CommandText = "Select NameDoctor,NamePatient,App_Date from appointments inner join doctors on appointments.codedoctor=doctors.codedoctor  inner join patients on appointments.codepatient=patients.codepatient";
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adap.Fill(ds);
            bunifuDataGridView1.DataSource = ds.Tables[0].DefaultView;
            con.Close();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            Clientapp newForm = new Clientapp();
            newForm.ShowDialog(this);
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            Hide();
            con.Close();
        }
    }
    }
