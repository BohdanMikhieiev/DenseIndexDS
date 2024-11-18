using System.Windows.Forms;

namespace SimpleDatabaseApp
{
    public partial class GenerateDataForm : Form
    {
        private MainForm mainForm;

        public GenerateDataForm(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
        }

        public static void ShowForm(MainForm form)
        {
            var generateForm = new GenerateDataForm(form);
            generateForm.ShowDialog();
        }
    }
}