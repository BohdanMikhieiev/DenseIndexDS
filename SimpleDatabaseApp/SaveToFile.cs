using System.IO;
using System.Text;

namespace SimpleDatabaseApp
{
    public partial class MainForm
    {
        public void SaveToTextFile()
        {
            
            var mainTablePath = "MainTable.txt";
            using (var writer = new StreamWriter(mainTablePath, false, Encoding.UTF8))
            {
                foreach (var record in MainTable)
                {
                    writer.WriteLine($"{record.ID}\t{record.Data}");
                }
            }
            
            var indexAreaPath = "IndexArea.txt";
            using (var writer = new StreamWriter(indexAreaPath, false, Encoding.UTF8))
            {
                foreach (var indexRecord in IndexArea)
                {
                    writer.WriteLine($"{indexRecord.ID}\t{indexRecord.Address}");
                }
            }
        }
        
        public void LoadFromFile()
        {
            var mainTablePath = "MainTable.txt";
            if (File.Exists(mainTablePath))
            {
                using (var reader = new StreamReader(mainTablePath, Encoding.UTF8))
                {
                    MainTable.Clear();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split('\t');
                        if (parts.Length == 2 && int.TryParse(parts[0], out int id))
                        {
                            MainTable.Add(new Record
                            {
                                ID = id,
                                Data = parts[1]
                            });
                        }
                    }
                }
            }
            
            var indexAreaPath = "IndexArea.txt";
            if (File.Exists(indexAreaPath))
            {
                using (var reader = new StreamReader(indexAreaPath, Encoding.UTF8))
                {
                    IndexArea.Clear();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split('\t');
                        if (parts.Length == 2 &&
                            int.TryParse(parts[0], out int id) &&
                            int.TryParse(parts[1], out int address))
                        {
                            IndexArea.Add(new IndexRecord
                            {
                                ID = id,
                                Address = address
                            });
                        }
                    }
                }
            }

            UpdateTables();
        }
    }
}