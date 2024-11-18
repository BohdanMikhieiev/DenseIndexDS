using System.Linq;
using System.Windows.Forms;

namespace SimpleDatabaseApp
{
    public partial class MainForm
    {
        public void AddData()
        {
            AddDataForm.ShowForm(this);
            RebuildIndex();
        }
        public void EditData()
        {
            if (dgvMainTable.SelectedRows.Count > 0)
            {
                var rowIndex = dgvMainTable.SelectedRows[0].Index;
                EditDataForm.ShowForm(this, rowIndex);
                RebuildIndex();
            }
            else
            {
                MessageBox.Show("Choose the field to delete!");
            }
        }

        public void DeleteData()
        {
            if (dgvMainTable.SelectedRows.Count > 0)
            {
                var rowIndex = dgvMainTable.SelectedRows[0].Index;
                MainTable.RemoveAt(rowIndex);
                IndexArea.RemoveAt(rowIndex);
                UpdateTables();
                RebuildIndex();
            }
            else
            {
                MessageBox.Show("Choose the field to delete!");
            }
        }

        public void GenerateRandomData()
        {
            GenerateDataForm.ShowForm(this);
            RebuildIndex();
        }

        public void SearchData()
        {
            SearchDataForm.ShowForm(this);
        }

        public void RebuildIndex()
        {
            for (int i = 0; i < MainTable.Count; i++)
            {
                IndexArea[i].Address = i;
            }
            UpdateTables();
        }
    }
}