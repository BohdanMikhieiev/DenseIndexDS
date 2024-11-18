using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SimpleDatabaseApp
{
    public partial class MainForm : Form
    {
        public List<Record> MainTable = new List<Record>();
        public List<IndexRecord> IndexArea = new List<IndexRecord>();
        public int currentId = 1;

        public MainForm()
        {
            InitializeComponent();
            InitializeUI();
            UpdateTables();
        }

        public void UpdateTables()
        {
            dgvMainTable.DataSource = null;
            dgvMainTable.DataSource = MainTable;

            dgvIndexArea.DataSource = null;
            dgvIndexArea.DataSource = IndexArea;
        }
        
        public void InitializeDatabase()
        {
            var initialRecord = new Record { ID = 1, Data = "Use ADD to manually add new content, don't forget to select the row to edit or delete it ^w^" };
            
           MainTable.Add(initialRecord);
           IndexArea.Add(new IndexRecord { ID = MainTable[currentId-1].ID, Address = currentId-1 });

           currentId++;
           UpdateTables();
        }

        private void InitializeUI()
        {
            dgvMainTable = new DataGridView
            {
                Name = "dgvMainTable",
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            };
            

            dgvIndexArea = new DataGridView
            {
                Name = "dgvIndexArea",
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };
            
            var mainPanel = new Panel { Dock = DockStyle.Fill };
            var indexPanel = new Panel { Dock = DockStyle.Bottom, Height = 200 };
            var buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true
            };
            
            var btnAddData = new Button { Text = "Add" };
            btnAddData.Click += (s, e) => AddData();

            var btnEditData = new Button { Text = "Edit" };
            btnEditData.Click += (s, e) => EditData();

            var btnDeleteData = new Button { Text = "Delete" };
            btnDeleteData.Click += (s, e) => DeleteData();

            var btnGenerateRandom = new Button { Text = "Generate" };
            btnGenerateRandom.Click += (s, e) => GenerateRandomData();

            var btnSearchData = new Button { Text = "Search" };
            btnSearchData.Click += (s, e) => SearchData();
            
            buttonPanel.Controls.Add(btnAddData);
            buttonPanel.Controls.Add(btnEditData);
            buttonPanel.Controls.Add(btnDeleteData);
            buttonPanel.Controls.Add(btnGenerateRandom);
            buttonPanel.Controls.Add(btnSearchData);
            
            mainPanel.Controls.Add(dgvMainTable);
            indexPanel.Controls.Add(dgvIndexArea);
            Controls.Add(mainPanel);
            Controls.Add(indexPanel);
            Controls.Add(buttonPanel);
            InitializeDatabase();
        }
        public DataGridView dgvMainTable;
        public DataGridView dgvIndexArea;
        
        public class Record
        {
            public int ID { get; set; }
            public string Data { get; set; }
        }

        public class IndexRecord
        {
            public int ID { get; set; }
            public int Address { get; set; }
        }
    }
}