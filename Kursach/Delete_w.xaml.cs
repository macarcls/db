using Microsoft.EntityFrameworkCore.Internal;
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
using System.Xml.Linq;

namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для Delete_w.xaml
    /// </summary>
    public partial class Delete_w : Window
    {
        public string? t_name { get; set; }
        public Delete_w()
        {
            InitializeComponent();
            
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var db = new ApplicationContext();
            var my_table = db.Transport;
            var my_table1 = db.Inventory;
            var my_table2 = db.Office_Equipment;
            var my_table3 = db.Realestates;
            switch (t_name)
            {
                case "transport":
                    var IdFound = my_table.First(k => k.ID == int.Parse(id.Text));
                    if (IdFound == null)
                    {
                        MessageBox.Show("Id не найден");
                    }
                    else
                    {
                        db.Transport.Remove(IdFound);
                        db.SaveChanges();
                        MessageBox.Show("Элемент удалён");
                    }
                    break;
                case "office_equip":
                    var IdFound1 = my_table2.FirstOrDefault(k => k.ID == int.Parse(id.Text));
                    if (IdFound1 == null)
                    {
                        MessageBox.Show("Id не найден");
                    }
                    else
                    {
                        db.Office_Equipment.Remove(IdFound1);
                        db.SaveChanges();
                        MessageBox.Show("Элемент удалён");
                    }
                    break;
                case "inventory":
                    int int_id = int.Parse(id.Text);
                    var IdFound2 = my_table1.First(k => k.ID == int_id);
                    if (IdFound2 == null)
                    {
                        MessageBox.Show("Id не найден");
                    }
                    else
                    {
                        db.Inventory.Remove(IdFound2);
                        db.SaveChanges();
                        MessageBox.Show("Элемент удалён");
                    }
                    break;
                case "realest":
                    var IdFound3 = my_table3.FirstOrDefault(k => k.ID == int.Parse(id.Text));
                    if (IdFound3 == null)
                    {
                        MessageBox.Show("Id не найден");
                    }
                    else
                    {
                        db.Realestates.Remove(IdFound3);
                        db.SaveChanges();
                        MessageBox.Show("Элемент удалён");
                    }
                    break;
            }
        }
    }
}
