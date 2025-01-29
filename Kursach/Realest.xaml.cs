using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для Realest.xaml
    /// </summary>
    public partial class Realest : Window
    {
        Realestate _RealestModel;

        public Realest()
        {
            _RealestModel = new Realestate();
            InitializeComponent();
            DataContext = _RealestModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var db = new ApplicationContext();
            if (_RealestModel.type == null || _RealestModel.cost == null || _RealestModel.address == null || _RealestModel.area == null)
            {
                MessageBox.Show("all text boxes must be filled!", "Error");
            }
            else
            {
                var AddReal = new Realestate()
                {
                    type = _RealestModel.type,
                    address = _RealestModel.address,
                    area = _RealestModel.area,
                    cost = _RealestModel.cost,
                };
                db.Add(AddReal);
                db.SaveChanges();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var mainw = new MainWindow();
            Close();
            mainw.Show();
        }

        private void Check_base(object sender, RoutedEventArgs e)
        {
            var collection = new ObsCollection("realest");
            collection.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Delete_w delete_W = new Delete_w() { t_name = "realest" };
            delete_W.Show();
        }
    }
}
