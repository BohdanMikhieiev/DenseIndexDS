using System.Windows.Forms;
using System;

namespace SimpleDatabaseApp
{
    public partial class SearchDataForm : Form
    {
        private MainForm mainForm;

        public SearchDataForm(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
        }

        public static void ShowForm(MainForm form)
        {
            var searchForm = new SearchDataForm(form);
            searchForm.ShowDialog();
        }
        
        public int SharrSearch(int searchID)
        {
            int left = 0;
            int right = mainForm.IndexArea.Count - 1;
            int comparisonCount = 0;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                comparisonCount++;
                if (mainForm.IndexArea[mid].ID == searchID)
                {
                    Console.WriteLine("Total comparisons: " + comparisonCount);
                    return mainForm.IndexArea[mid].Address;
                }

                comparisonCount++;
                if (mainForm.IndexArea[mid].ID < searchID)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return -1;
        }
    }
}