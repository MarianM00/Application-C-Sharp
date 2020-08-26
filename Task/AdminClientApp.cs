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
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;



namespace Task
{   
    public partial class AdminClientApp : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NP1RDM2\BAZALUIMARIAN;Initial Catalog=task;Persist Security Info=True;User ID=sa; Password = 0299");
        string connectionString = @"Data Source=DESKTOP-NP1RDM2\BAZALUIMARIAN;Initial Catalog=task;Persist Security Info=True;User ID=sa; Password = 0299";
        public AdminClientApp()
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

        private void AdminUser_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'taskDataSet1.Clientapp' table. You can move, or remove it, as needed.
            this.clientappTableAdapter.Fill(this.taskDataSet1.Clientapp);
            // TODO: This line of code loads data into the 'taskDataSet1.Appointments' table. You can move, or remove it, as needed.
            this.appointmentsTableAdapter.Fill(this.taskDataSet1.Appointments);
            // TODO: This line of code loads data into the 'taskDataSet1.Patients' table. You can move, or remove it, as needed.
            this.patientsTableAdapter.Fill(this.taskDataSet1.Patients);
            // TODO: This line of code loads data into the 'taskDataSet1.Doctors' table. You can move, or remove it, as needed.
            this.doctorsTableAdapter.Fill(this.taskDataSet1.Doctors);
            // TODO: This line of code loads data into the 'taskDataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.taskDataSet.Users);

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
            private void BtnSave_Click(object sender, EventArgs e)
        {
            this.Validate();
            clientappBindingSource.EndEdit();
            clientappTableAdapter.Update(taskDataSet1.Clientapp);
            MessageBox.Show("The table has updated!");
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            AdminClientAppEdit newform = new AdminClientAppEdit();
            newform.ShowDialog(this);
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            string deleteValue = TxtDelete.Text.ToString();
            string query;

            query = string.Format("delete from Appointments where Id_appointment like {0}", deleteValue);
            CreateCommand(query, connectionString);
            MessageBox.Show("Appointment has been removed!");
            Hide();
        }
      

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            
        }

        public void Export_Data_To_Excel(DataGridView DGV, string filename)
        {

            if (DGV.Rows.Count != 0)
            {
                int RowCount = DGV.Rows.Count;
                int ColumnCount = DGV.Columns.Count;
                Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];
                //add rows
                int r = 0;
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    for (r = 0; r <= RowCount - 1; r++)
                    {
                        DataArray[r, c] = DGV.Rows[r].Cells[c].Value;
                    } //end row loop
                } //end column loop


            }
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
            int StartCol = 1;
            int StartRow = 1;
            int j = 0, i = 0;

            for (j = 0; j < DGV.Columns.Count; j++)
            {
                Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                myRange.Value2 = DGV.Columns[j].HeaderText;
            }

            StartRow++;

            for (i = 0; i < DGV.Rows.Count; i++)
            {
                for (j = 0; j < DGV.Columns.Count; j++)
                {
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];
                    myRange.Value2 = DGV[j, i].Value == null ? "" : DGV[j, i].Value;
                }
            }

        }
        private void bunifuButton5_Click(object sender, EventArgs e)
        {

            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Excel Documents (*.xlsx)|*.xlsx";

            sfd.FileName = "export.xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {

                Export_Data_To_Excel(bunifuDataGridView1, sfd.FileName);

            }
        }

        public void Export_Data_To_Word(DataGridView DGV, string filename)
        {
            if (DGV.Rows.Count != 0)
            {
                int RowCount = DGV.Rows.Count;
                int ColumnCount = DGV.Columns.Count;
                Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];

                //add rows
                int r = 0;
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    for (r = 0; r <= RowCount - 1; r++)
                    {
                        DataArray[r, c] = DGV.Rows[r].Cells[c].Value;
                    } //end row loop
                } //end column loop

                Word.Document oDoc = new Word.Document();
                oDoc.Application.Visible = true;

                //page orintation
                oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;


                dynamic oRange = oDoc.Content.Application.Selection.Range;
                string oTemp = "";
                for (r = 0; r <= RowCount - 1; r++)
                {
                    for (int c = 0; c <= ColumnCount - 1; c++)
                    {
                        oTemp = oTemp + DataArray[r, c] + "\t";

                    }
                }

                //table format
                oRange.Text = oTemp;

                object Separator = Word.WdTableFieldSeparator.wdSeparateByTabs;
                object ApplyBorders = true;
                object AutoFit = true;
                object AutoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitContent;

                oRange.ConvertToTable(ref Separator, ref RowCount, ref ColumnCount,
                                      Type.Missing, Type.Missing, ref ApplyBorders,
                                      Type.Missing, Type.Missing, Type.Missing,
                                      Type.Missing, Type.Missing, Type.Missing,
                                      Type.Missing, ref AutoFit, ref AutoFitBehavior, Type.Missing);

                oRange.Select();

                oDoc.Application.Selection.Tables[1].Select();
                oDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
                oDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.InsertRowsAbove(1);
                oDoc.Application.Selection.Tables[1].Rows[1].Select();

                //header row style
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 1;
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Tahoma";
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 14;

                //add header row manually
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = DGV.Columns[c].HeaderText;
                }

                //table style 
                oDoc.Application.Selection.Tables[1].set_Style("Grid Table 4 - Accent 5");
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                //header text
                foreach (Word.Section section in oDoc.Application.ActiveDocument.Sections)
                {
                    Word.Range headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, Word.WdFieldType.wdFieldPage);
                    headerRange.Text = "Informaciq za zaeti mesta";
                    headerRange.Font.Size = 16;
                    headerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                }

                //save the file
                oDoc.SaveAs2(filename);
            }
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Word Documents (*.docx)|*.docx";

            sfd.FileName = "export.docx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {

                Export_Data_To_Word(bunifuDataGridView1,sfd.FileName);
            }

        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {   AdminAppointmentAdd newform = new AdminAppointmentAdd();
            newform.ShowDialog(this);
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }
