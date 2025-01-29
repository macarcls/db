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
    /// Логика взаимодействия для Change_Transport.xaml
    /// </summary>
    public partial class Change_Transport : Window
    {
        Transport _TransportModel;

        public Change_Transport()
        {
            _TransportModel = new Transport();
            InitializeComponent();
            DataContext = _TransportModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var db = new ApplicationContext();
            if (_TransportModel.Type == null || _TransportModel.cost == null || _TransportModel.place == null)
            {
                MessageBox.Show("all text boxes must be filled!", "Error");
            }
            else
            {
                var addtoDB = new Transport()
                {
                    Type = _TransportModel.Type,
                    cost = _TransportModel.cost,
                    place = _TransportModel.place,
                };
                db.Add(addtoDB);
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
            var collection = new ObsCollection("transport");
            collection.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Delete_w delete_W = new Delete_w() { t_name = "transport" };
            delete_W.Show();
        }
    }
}
