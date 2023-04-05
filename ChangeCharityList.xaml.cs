using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace Marathon
{
    /// <summary>
    /// Логика взаимодействия для ChangeCharityList.xaml
    /// </summary>
    public partial class ChangeCharityList : Window
    {
        MainWindow MW = new MainWindow();
        ManageCharities MC = new ManageCharities();
        Charity ch = new Charity();
        public ChangeCharityList(Charity cha)
        {
            InitializeComponent();
            ch = cha;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MC.Show();
            this.Close();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MW.Show();
            this.Close();
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

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Entities ch1 = new Entities();
            try
            {
                if (ChangeLogoCheck.IsChecked== true)
                {
                    Charity dataChange = new Charity 
                    {
                        ID = ch.ID,
                        Name = NameCharity.Text,
                        Description = DescriptionCharity.Text,
                        Image = File.ReadAllBytes(ImagePath.Text),
                    };
                    ch1.Charities.AddOrUpdate(dataChange);
                    ch1.SaveChanges();
                    MC.Show();
                    this.Close();
                }
                else
                {
                    Charity data = new Charity
                    {
                        ID = ch.ID,
                        Name = NameCharity.Text,
                        Description = DescriptionCharity.Text,
                        Image = ch.Image,
                    };
                    ch1.Charities.AddOrUpdate(data);
                    ch1.SaveChanges();
                    MC.Show();
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так!\nНе волнуйтесь специалист уже работает над исправлением!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void FirstImage (byte[]data)
        {
            try
            {
                BitmapImage bmpi = new BitmapImage();
                bmpi.BeginInit();
                bmpi.StreamSource = new MemoryStream(data);
                bmpi.EndInit();
                SelectedImage.Source = bmpi;
            }
            catch { }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            NameCharity.Text = ch.Name;
            DescriptionCharity.Text = ch.Description;
            FirstImage(ch.Image);
        }
    }
}
