using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.Entity;
using System.Drawing;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Data;

namespace Marathon
{
    /// <summary>
    /// Логика взаимодействия для ManageCharities.xaml
    /// </summary>
    public partial class ManageCharities : Window
    {
        Entities ch = new Entities();
        public ManageCharities()
        {
            InitializeComponent();
            ch.Charities.Load();
            DataGrid_Charity.ItemsSource = ch.Charities.ToList();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ch.Charities.Load();
            DataGrid_Charity.ItemsSource = ch.Charities.ToList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdminMenuWindow AMW = new AdminMenuWindow();
            AMW.Show();
            this.Close();
        }

        private void AddCharity_Click(object sender, RoutedEventArgs e)
        {
            AddCharityList ACL = new AddCharityList();
            ACL.Show();
            this.Close();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var rowselected = DataGrid_Charity.SelectedItem as Charity;
            if (rowselected != null)
            {
                ChangeCharityList CCL = new ChangeCharityList(rowselected);
                CCL.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Не выбрана ни одна строка для редактирования!");
            }
        }
    }
}
