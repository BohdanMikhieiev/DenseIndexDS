using System.ComponentModel;
using System.Windows.Forms;

namespace SimpleDatabaseApp
{
    partial class SearchDataForm
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
            this.Text = "Search Data";
            var lblID = new Label { Text = "ID:", Dock = DockStyle.Top };
            var txtID = new TextBox { Dock = DockStyle.Top };
            
            var btnAdd = new Button { Text = "Search", Dock = DockStyle.Top };

            btnAdd.Click += (s, e) =>
            {
                if (!string.IsNullOrWhiteSpace(txtID.Text))
                {
                    if (int.TryParse(txtID.Text, out int parsedID))
                    {
                        bool idExists = mainForm.MainTable.Exists(record => record.ID == parsedID);
                        if (idExists)
                        {
                            int address = SharrSearch(parsedID);
                            if (address != -1)
                            {
                                MessageBox.Show($"Record found at address: {address}\nData: {mainForm.MainTable[address].Data}", 
                                    "Search Result", 
                                    MessageBoxButtons.OK, 
                                    MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Record not found!", 
                                    "Search Result", 
                                    MessageBoxButtons.OK, 
                                    MessageBoxIcon.Warning);
                            }
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("This ID doesn't exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("ID must be a number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else
                {
                    MessageBox.Show("Please, fill all the fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            Controls.Add(btnAdd);
            Controls.Add(txtID);
            Controls.Add(lblID);
        }

        #endregion
    }
}