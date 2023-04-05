using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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

namespace Marathon
{
    /// <summary>
    /// Логика взаимодействия для AddCharityList.xaml
    /// </summary>
    public partial class AddCharityList : Window
    {
        Entities ch = new Entities();
        ManageCharities MC = new ManageCharities();
        public AddCharityList()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e) // Добавление данных в БД
        {
            try 
            {
                Charity data = new Charity 
                {
                    ID = (MC.DataGrid_Charity.SelectedIndex = MC.DataGrid_Charity.Items.Count - 1),
                    Name = NameCharity.Text, 
                    Description = DescriptionCharity.Text, 
                    Image = File.ReadAllBytes(ImagePath.Text)
                };
                ch.Charities.Add(data);
                ch.SaveChanges();
                MC.Show();
                this.Close();
            }
            catch 
            {
                MessageBox.Show("Что-то пошло не так!\nНе волнуйтесь специалист уже работает над исправлением!","Внимание!",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }


        private void AddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Nullable<bool> result = openFileDialog.ShowDialog();
            if (result == true)
            {
                string filename = openFileDialog.FileName;
                ImagePath.Text = openFileDialog.FileName.Trim();
                SelectedImage.Source = new BitmapImage(new Uri(filename));
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ManageCharities MC = new ManageCharities();
            MC.Show();
            this.Close();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MW = new MainWindow();
            MW.Show();
            this.Close();
        }
    }
}
