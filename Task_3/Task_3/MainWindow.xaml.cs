using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Task_2_API;

namespace Task_3
{
    public partial class MainWindow : Window
    {
        private const string Path = @"..\Resources\test.json";
        public MainWindow()
        {
            InitializeComponent();
            FillDataGrid(GetFile());
        }

        private string GetFile()
        {
            string file = "";
            try
            {
                Task<string> getFile = Task.Run(() => file = JsonParse.GetJson(Path).Result);
                while (!getFile.IsCompleted) ;
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return file;
        }

        private void FillDataGrid(string file)
        {
            try
            {
                Breakage breakage = JsonParse.GetObject<Breakage>(file);
                List<Breakage> breakages = new List<Breakage>();
                breakages.Add(breakage);
                var row = breakage.AffectedAreas.Select(area => new
                {
                    OutageStart = breakages[0].OutageStart,
                    OutageEnd = breakages[0].OutageEnd,
                    Name = area.Name,
                    Reason = area.Reason,
                    EstimatedRecoveryTime = area.EstimatedRecoveryTime,
                    AffectedCustomers = area.AffectedCustomers
                });
                affectedAreasDataGrid.ItemsSource = row;
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
