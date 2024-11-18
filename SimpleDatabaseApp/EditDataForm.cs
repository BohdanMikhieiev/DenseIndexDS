using System.Windows.Forms;

namespace SimpleDatabaseApp
{
    public partial class EditDataForm : Form
    {
        private MainForm mainForm;
        private int recordIndex;

        public EditDataForm(MainForm form, int index)
        {
            InitializeComponent();
            mainForm = form;
            recordIndex = index;
        }

        public static void ShowForm(MainForm form, int index)
        {
            var editForm = new EditDataForm(form, index);
            editForm.ShowDialog();
        }
    }
}