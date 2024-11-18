using System.Windows.Forms;

namespace SimpleDatabaseApp
{
    public partial class AddDataForm : Form
    {
        private MainForm mainForm;

        public AddDataForm(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
        }

        public static void ShowForm(MainForm form)
        {
            var addForm = new AddDataForm(form);
            addForm.ShowDialog();
        }
    }
}