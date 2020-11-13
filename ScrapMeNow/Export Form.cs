﻿using ClosedXML.Excel;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ScrapMeNow
{
    public partial class Export_Form : MaterialSkin.Controls.MaterialForm
    {
        public Export_Form()
        {
            InitializeComponent();
            var skinmanager = MaterialSkin.MaterialSkinManager.Instance;
            skinmanager.AddFormToManage(this);
            skinmanager.Theme = MaterialSkin.MaterialSkinManager.Themes.DARK;
            skinmanager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.BlueGrey800,
                MaterialSkin.Primary.Grey800, MaterialSkin.Primary.Grey800,
                MaterialSkin.Accent.LightBlue700, MaterialSkin.TextShade.WHITE);

        }

        public int countCheckboxes()
        {
            var checkedBoxes = 0;
            // Iterate through all of the Controls in your Form
            foreach (Control c in this.groupBoxTables.Controls)
            {
                // If one of the Controls is a CheckBox and it is checked, then
                // increment your count
                if (c is CheckBox && (c as CheckBox).Checked)
                {
                    checkedBoxes++;
                }
            }
            return checkedBoxes;
        }

        public string getCheckboxesChecked()
        {
            var checkedBoxes = "";
            // Iterate through all of the Controls in your Form
            foreach (Control c in this.groupBoxTables.Controls)
            {
                // If one of the Controls is a CheckBox and it is checked, then
                // increment your count
                if (c is CheckBox && (c as CheckBox).Checked)
                {
                    checkedBoxes = c.Text;
                }
            }
            return checkedBoxes;
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if (!(cbContributions.Checked | cbEvents.Checked | cbPersons.Checked | cbProduction.Checked | cbVenue.Checked))
            {
                MessageBox.Show("You must check at least one of the checkboxes to convert into csv.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (txtId.Text != "")
                {
                    for (int i = 0; i < 1; i++)
                    {
                        MySqlConnection mySqlConnection = new MySqlConnection();
                        string connetionString = "SERVER= 88.99.136.47;PORT=3306;DATABASE=xuxlffke_testdb;USER=xuxlffke_testuser;PASSWORD=';*r-?lL&FqV]';";
                        MySqlConnection mysqlCon = new MySqlConnection(connetionString);
                        mysqlCon.Open();
                        int count = 0;
                        mySqlConnection.ConnectionString = connetionString;
                        DataTable table = new DataTable();
                        SaveFileDialog save = new SaveFileDialog();
                        MySqlDataAdapter MyDA = new MySqlDataAdapter();
                        save.FileName = "Record.csv";
                        save.Filter = "Csv File | *.csv";
                        save.Title = "Save " + getCheckboxesChecked() + " into a csv file";
                        string sqlSelectAll = "SELECT * from " + getCheckboxesChecked() + " where ID = " + txtId.Text;
                        MyDA.SelectCommand = new MySqlCommand(sqlSelectAll, mysqlCon);
                        MySqlCommand countcomm = new MySqlCommand();
                        countcomm.Connection = mysqlCon;
                        countcomm.CommandText = "SELECT COUNT(*) from " + getCheckboxesChecked() + " where ID = " + txtId.Text;
                        countcomm.ExecuteNonQuery();
                        int num = int.Parse(countcomm.ExecuteScalar().ToString());
                        if (num > 0)
                        {
                            MyDA.Fill(table);
                            if (save.ShowDialog() == DialogResult.OK)
                            {
                                WriteToCsvFile(table, save.FileName);
                            }
                        }
                        else
                        {
                            MessageBox.Show("This ID cannot be found on this table..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        mysqlCon.Close();
                    }
                }
            }
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public string DataTableToJsonWithJsonNet(DataTable objDataTable)
        {
            string jsonString = string.Empty;
            jsonString = JsonConvert.SerializeObject(objDataTable);
            return jsonString;
        }

        private void btnExportJSON_Click(object sender, EventArgs e)
        {
            if (!(cbContributions.Checked | cbEvents.Checked | cbPersons.Checked | cbProduction.Checked | cbVenue.Checked))
            {
                MessageBox.Show("You must check at least one of the checkboxes.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (txtId.Text != "")
                {
                    DataTable table = new DataTable();
                    string connetionString = "SERVER= 88.99.136.47;PORT=3306;DATABASE=xuxlffke_testdb;USER=xuxlffke_testuser;PASSWORD=';*r-?lL&FqV]';";
                    MySqlConnection mysqlCon = new MySqlConnection(connetionString);
                    MySqlDataAdapter MyDA = new MySqlDataAdapter();
                    mysqlCon.Open();
                    string s = "";

                    for (int i = 0; i < 1; i++)
                    {
                        SaveFileDialog save = new SaveFileDialog();
                        save.FileName = "Record.json";
                        save.Filter = "Json File | *.json";
                        save.Title = "Save " + getCheckboxesChecked() + " into a json file";

                        string sqlSelectAll = "SELECT * from " + getCheckboxesChecked() + " WHERE ID=" + txtId.Text;
                        MyDA.SelectCommand = new MySqlCommand(sqlSelectAll, mysqlCon);
                        MySqlCommand countcomm = new MySqlCommand();
                        countcomm.Connection = mysqlCon;
                        countcomm.CommandText = "SELECT COUNT(*) from " + getCheckboxesChecked() + " where ID=" + txtId.Text;
                        countcomm.ExecuteNonQuery();
                        int num = int.Parse(countcomm.ExecuteScalar().ToString());
                        if (num > 0)
                        {
                            MyDA.Fill(table);
                            if (save.ShowDialog() == DialogResult.OK)
                            {
                                StreamWriter writer = new StreamWriter(save.OpenFile());

                                writer.WriteLine(DataTableToJsonWithJsonNet(table));
                                writer.Dispose();
                                writer.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("This ID cannot be found on this table..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        mysqlCon.Close();
                    }
                }
            }
        }

        public void WriteToCsvFile(DataTable dataTable, string filePath)
        {
            StringBuilder fileContent = new StringBuilder();

            foreach (var col in dataTable.Columns)
            {
                fileContent.Append(col.ToString() + ",");
            }

            fileContent.Replace(",", System.Environment.NewLine, fileContent.Length - 1, 1);

            foreach (DataRow dr in dataTable.Rows)
            {
                foreach (var column in dr.ItemArray)
                {
                    fileContent.Append("\"" + column.ToString() + "\",");
                }

                fileContent.Replace(",", System.Environment.NewLine, fileContent.Length - 1, 1);
            }

            System.IO.File.WriteAllText(filePath, fileContent.ToString());
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (!(cbContributions.Checked | cbEvents.Checked | cbPersons.Checked | cbProduction.Checked | cbVenue.Checked))
            {
                MessageBox.Show("You must check at least one of the checkboxes.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (txtId.Text != "")
                {
                    DataSet set = new DataSet();
                    string connetionString = "SERVER= 88.99.136.47;PORT=3306;DATABASE=xuxlffke_testdb;USER=xuxlffke_testuser;PASSWORD=';*r-?lL&FqV]';";
                    MySqlConnection mysqlCon = new MySqlConnection(connetionString);
                    SaveFileDialog save = new SaveFileDialog();
                    mysqlCon.Open();
                    save.FileName = "example.xlsx";
                    save.Filter = "Excel File | *.xlsx";
                    save.Title = "Save " + getCheckboxesChecked() + " into a excel file";
                    MySqlCommand countcomm = new MySqlCommand();
                    countcomm.Connection = mysqlCon;
                    countcomm.CommandText = "SELECT COUNT(*) from " + getCheckboxesChecked() + " where ID = " + txtId.Text;
                    countcomm.ExecuteNonQuery();
                    int num = int.Parse(countcomm.ExecuteScalar().ToString());
                    if (num > 0)
                    {
                        if (save.ShowDialog() == DialogResult.OK)
                        {
                            var wb = new XLWorkbook();
                            for (int i = 0; i < countCheckboxes(); i++)
                            {
                                var dataTable = GetTable(getCheckboxesChecked());

                                wb.Worksheets.Add(dataTable);
                                wb.SaveAs(save.FileName);
                            }
                        }
                        else
                        {
                            MessageBox.Show("This ID cannot be found on this table..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        mysqlCon.Close();
                    }
                }
            }
        }
        private DataTable GetTable(String tableName)
        {
            string connetionString = "SERVER= 88.99.136.47;PORT=3306;DATABASE=xuxlffke_testdb;USER=xuxlffke_testuser;PASSWORD=';*r-?lL&FqV]';";
            MySqlConnection mysqlCon = new MySqlConnection(connetionString);
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string s = "";
            DataTable table = new DataTable();
            string sqlSelectAll = "SELECT * from " + getCheckboxesChecked() + " WHERE ID=" + txtId.Text;
            MyDA.SelectCommand = new MySqlCommand(sqlSelectAll, mysqlCon);
            MyDA.Fill(table);
            table.TableName = tableName;
            return table;
        }
        private int checkCounter;
        private void cbProduction_CheckedChanged(object sender, EventArgs e)
        {
            checkchecked(sender, e);
        }

        private void cbContributions_CheckedChanged(object sender, EventArgs e)
        {
            checkchecked(sender, e);
        }

        private void cbVenue_CheckedChanged(object sender, EventArgs e)
        {
            checkchecked(sender, e);
        }

        private void cbPersons_CheckedChanged(object sender, EventArgs e)
        {
            checkchecked(sender, e);
        }

        private void cbOrganizer_CheckedChanged(object sender, EventArgs e)
        {
            checkchecked(sender, e);
        }

        private void cbEvents_CheckedChanged(object sender, EventArgs e)
        {
            checkchecked(sender, e);
        }
        public void checkchecked(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;

            // prevent checking
            if (countCheckboxes() > 1)
            {
                MessageBox.Show("You can check only one checkbox at the time", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                box.Checked = false;
            }
        }
    }
}
