using Aspose.Cells;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kursach
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //string? appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //string imagePath = System.IO.Path.Combine(appPath!, "SPRK_default_preset_name_custom – 1.png");
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            var Transport = new Change_Transport();
            Transport.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var Invent = new Inventory();
            Invent.Show();
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var Realest = new Realest();
            Realest.Show();
            Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var Office = new Office_equip();
            Office.Show();
            Close();
        }

        private void Check_Price(object sender, RoutedEventArgs e)
        {
            var db = new ApplicationContext();

            var inv_price = db.Inventory;
            var Transport = db.Transport;
            var Office_equipment = db.Office_Equipment;
            var Realest = db.Realestates;

            var total_inv = inv_price.Select(x => x.cost).Sum();
            var total_transport = Transport.Select(x => x.cost).Sum();
            var total_Office_equip = Office_equipment.Select(x => x.cost).Sum();
            var total_Realest = Realest.Select(x => x.cost).Sum();

            int? total = total_inv + total_transport + total_Office_equip + total_Realest;
            MessageBox.Show($"{total}", Title = "total price");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var db = new ApplicationContext();

            var inv_price = db.Inventory;
            var Transport = db.Transport;
            var Office_equipment = db.Office_Equipment;
            var Realest = db.Realestates;
            Workbook workbook = new Workbook();
            WorksheetCollection worksheets = workbook.Worksheets;
            int a = workbook.Worksheets.Add();
            int b = workbook.Worksheets.Add();
            int c = workbook.Worksheets.Add();
            int d = workbook.Worksheets.Add();
            Worksheet Inventory_w = workbook.Worksheets[a];
            Inventory_w.Name = "Inventory";
            Worksheet Transport_w = workbook.Worksheets[b];
            Transport_w.Name = "Transport";
            Worksheet Office_equipment_w = workbook.Worksheets[c];
            Office_equipment_w.Name = "Office_equip";
            Worksheet Realest_w = workbook.Worksheets[d];
            Realest_w.Name = "Real_estate";
            Inventory_w.Cells.ImportArray(inv_price.Select(x => x.ID).ToArray(),1,0,true);
            Inventory_w.Cells.ImportArray(inv_price.Select(x => x.type).ToArray(),1,1,true);
            Inventory_w.Cells.ImportArray(inv_price.Select(x => x.cost.ToString()).ToArray(),1,2,true);
            //
            Transport_w.Cells.ImportArray(Transport.Select(x => x.ID).ToArray(), 1, 0, true);
            Transport_w.Cells.ImportArray(Transport.Select(x => x.Type).ToArray(), 1, 1, true);
            Transport_w.Cells.ImportArray(Transport.Select(x => x.place).ToArray(), 1, 2, true);
            Transport_w.Cells.ImportArray(Transport.Select(x => x.cost.ToString()).ToArray(), 1, 3, true);
            //
            Office_equipment_w.Cells.ImportArray(Office_equipment.Select(x => x.ID).ToArray(), 1,0,true);
            Office_equipment_w.Cells.ImportArray(Office_equipment.Select(x => x.Type).ToArray(), 1,1,true);
            Office_equipment_w.Cells.ImportArray(Office_equipment.Select(x => x.cost.ToString()).ToArray(), 1,2,true);
            //
            Realest_w.Cells.ImportArray(Realest.Select(x => x.ID).ToArray(), 1, 0, true);
            Realest_w.Cells.ImportArray(Realest.Select(x => x.type).ToArray(), 1, 1, true);
            Realest_w.Cells.ImportArray(Realest.Select(x => x.address).ToArray(), 1, 2, true);
            Realest_w.Cells.ImportArray(Realest.Select(x => x.area).ToArray(), 1, 3, true);
            Realest_w.Cells.ImportArray(Realest.Select(x => x.cost.ToString()).ToArray(), 1, 4, true);

            workbook.Save("D:\\удалить\\KursovayaRabota-master\\Kursach\\output.xlsx");

        }
    }
}