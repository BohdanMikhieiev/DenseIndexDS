using System.ComponentModel;
using System.Windows.Forms;

namespace SimpleDatabaseApp
{
    partial class EditDataForm
    {
        private IContainer components = null;
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
            this.Text = "Edit Data";
            var lblID = new Label { Text = "ID:", Dock = DockStyle.Top };
            var txtID = new TextBox { Dock = DockStyle.Top };
            var lblData = new Label { Text = "Data:", Dock = DockStyle.Top };
            var txtData = new TextBox { Dock = DockStyle.Top };
            var btnAdd = new Button { Text = "Add", Dock = DockStyle.Top };
            

            btnAdd.Click += (s, e) =>
            {
                if (!string.IsNullOrWhiteSpace(txtData.Text))
                {
                    if (int.TryParse(txtID.Text, out int parsedID))
                    {
                        bool idExists = mainForm.MainTable.Exists(record => record.ID == parsedID);
                        if (!idExists)
                        {
                            mainForm.DeleteData();
                            var newRecord = new MainForm.Record
                            {
                                ID = parsedID,
                                Data = txtData.Text
                            };
                            mainForm.MainTable.Insert(recordIndex, newRecord);
                            var newIndexRecord = new MainForm.IndexRecord
                            {
                                ID = parsedID,
                                Address = mainForm.MainTable.Count - 1
                            };
                            mainForm.IndexArea.Insert(recordIndex, newIndexRecord);
                            mainForm.UpdateTables();
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("This ID already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Controls.Add(txtData);
            Controls.Add(lblData);
            Controls.Add(txtID);
            Controls.Add(lblID);
        }

        #endregion
    }
}