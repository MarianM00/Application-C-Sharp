﻿using System;
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
    public partial class AdminDoctorEdit : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NP1RDM2\BAZALUIMARIAN;Initial Catalog=task;Persist Security Info=True;User ID=sa; Password = 0299");
        public AdminDoctorEdit()
        {
            InitializeComponent();
        }
        

        private void currentPosition()
        {
            int CurrentPosition, rowNumber;

            rowNumber = doctorsBindingSource.Count;
            CurrentPosition = doctorsBindingSource.Position + 1;
            bunifuTextBox3.Text = CurrentPosition.ToString() + " of " + rowNumber.ToString();

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
            // TODO: This line of code loads data into the 'taskDataSet1.Doctors' table. You can move, or remove it, as needed.
            this.doctorsTableAdapter.Fill(this.taskDataSet1.Doctors);
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
            this.doctorsBindingSource.MoveNext();
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
            this.Validate();
            doctorsBindingSource.EndEdit();
            this.doctorsTableAdapter.Update(this.taskDataSet1);
            MessageBox.Show("The doctors table is updated.");
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            this.doctorsBindingSource.MovePrevious();
            currentPosition();

        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            
            this.doctorsBindingSource.MoveFirst();
            currentPosition();
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            this.doctorsBindingSource.MoveLast();
            currentPosition();
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
    }
