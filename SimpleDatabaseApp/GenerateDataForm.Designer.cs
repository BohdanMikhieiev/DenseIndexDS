using System.ComponentModel;
using System.Windows.Forms;

namespace SimpleDatabaseApp
{
    partial class GenerateDataForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Text = "Generate";
            var lblNumber = new Label { Text = "Number of Data:", Dock = DockStyle.Top };
            var txtNumber = new TextBox { Dock = DockStyle.Top };
            var btnAdd = new Button { Text = "Generate", Dock = DockStyle.Top };

            btnAdd.Click += (s, e) =>
            {
                if (!string.IsNullOrWhiteSpace(txtNumber.Text))
                {
                    if (int.TryParse(txtNumber.Text, out int parsedNumber))
                    {
                        for (int i = 1; i <= parsedNumber; i++)
                        {
                            bool idExists = mainForm.MainTable.Exists(record => record.ID == i);
                            while (idExists)
                            {
                                i++;
                                parsedNumber++;
                                idExists = mainForm.MainTable.Exists(record => record.ID == i);
                            }
                            
                            var newRecord = new MainForm.Record
                            {
                                ID = i,
                                Data = "Random_" + i
                            };
                            mainForm.MainTable.Add(newRecord);
                            var newIndexRecord = new MainForm.IndexRecord
                            {
                                ID = i,
                                Address = mainForm.MainTable.Count - 1
                            };
                            mainForm.IndexArea.Add(newIndexRecord);
                            mainForm.UpdateTables();
                            
                        }
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Amount must be a number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else
                {
                    MessageBox.Show("Please, fill all the fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            Controls.Add(btnAdd);
            Controls.Add(txtNumber);
            Controls.Add(lblNumber);
        }

        #endregion
    }
}