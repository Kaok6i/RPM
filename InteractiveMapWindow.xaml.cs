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

namespace Marathon
{
    /// <summary>
    /// Логика взаимодействия для InteractiveMapWindow.xaml
    /// </summary>
    public partial class InteractiveMapWindow : Window
    {
        public InteractiveMapWindow()
        {
            InitializeComponent();
        }

        public void HiddenAll()
        {
            CheckpointLabel.Visibility = Visibility.Hidden;
            NameLandmark.Visibility = Visibility.Hidden;
            Services.Visibility = Visibility.Hidden;
            Label1.Visibility = Visibility.Hidden;
            Label2.Visibility = Visibility.Hidden;
            Label3.Visibility = Visibility.Hidden;
            Label4.Visibility = Visibility.Hidden;
            Label5.Visibility = Visibility.Hidden;
            InfoBox.Visibility = Visibility.Hidden;
            Image.Visibility = Visibility.Hidden;
            Image1.Visibility = Visibility.Hidden;
            Image2.Visibility = Visibility.Hidden;
            Image3.Visibility = Visibility.Hidden;
            Image4.Visibility = Visibility.Hidden;
            CloseButton.Visibility = Visibility.Hidden;
            ReturnImageSource();
        }
        public void ReturnImageSource()
        {
            Image.Source = new BitmapImage(new Uri(@"Resources/map-icon-drinks.png", UriKind.Relative));
            Image1.Source = new BitmapImage(new Uri(@"Resources/map-icon-energy-bars.png", UriKind.Relative));
            Image2.Source = new BitmapImage(new Uri(@"Resources/map-icon-toilets.png", UriKind.Relative));
            Image3.Source = new BitmapImage(new Uri(@"Resources/map-icon-information.png", UriKind.Relative));
            Image4.Source = new BitmapImage(new Uri(@"Resources/map-icon-medical.png", UriKind.Relative));
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            InfoAboutMarathon IAM = new InfoAboutMarathon();
            IAM.Show();
            this.Close();
        }

        private void StartFirst_Click(object sender, RoutedEventArgs e)
        {
            HiddenAll();
            CheckpointLabel.Content = "Samba Marathon";
            NameLandmark.Content = "Full marathon 15km";
            ReturnImageSource();
            CheckpointLabel.Visibility = Visibility.Visible;
            NameLandmark.Visibility = Visibility.Visible;
            CloseButton.Visibility = Visibility.Visible;
            InfoBox.Visibility = Visibility.Visible;
        }

        private void StartSecond_Click(object sender, RoutedEventArgs e)
        {
            HiddenAll();
            CheckpointLabel.Content = "Capoeira Run";
            NameLandmark.Content = "5 km";
            ReturnImageSource();
            CheckpointLabel.Visibility = Visibility.Visible;
            NameLandmark.Visibility = Visibility.Visible;
            CloseButton.Visibility = Visibility.Visible;
            InfoBox.Visibility = Visibility.Visible;
        }

        private void StartThird_Click(object sender, RoutedEventArgs e)
        {
            HiddenAll();
            CheckpointLabel.Content = "Jongo Half Marathon";
            NameLandmark.Content = "7,5 km";
            ReturnImageSource();
            CheckpointLabel.Visibility = Visibility.Visible;
            NameLandmark.Visibility = Visibility.Visible;
            CloseButton.Visibility = Visibility.Visible;
            InfoBox.Visibility = Visibility.Visible;
        }

        private void First_Click(object sender, RoutedEventArgs e)
        {
            Label4.Content = "Information";
            ReturnImageSource();
            CheckpointLabel.Content = "Checkpoint 1";
            NameLandmark.Content = "Avenida Rudge";
            CheckpointLabel.Visibility = Visibility.Visible;
            NameLandmark.Visibility = Visibility.Visible;
            Services.Visibility = Visibility.Visible;
            Label1.Visibility = Visibility.Visible;
            Label2.Visibility = Visibility.Visible;
            Image.Visibility = Visibility.Visible;
            Image1.Visibility = Visibility.Visible;
            CloseButton.Visibility = Visibility.Visible;
            InfoBox.Visibility = Visibility.Visible;
            Label3.Visibility = Visibility.Hidden;
            Label4.Visibility = Visibility.Hidden;
            Label5.Visibility = Visibility.Hidden;
            Image2.Visibility = Visibility.Hidden;
            Image3.Visibility = Visibility.Hidden;
            Image4.Visibility = Visibility.Hidden;
        }

        private void Second_Click(object sender, RoutedEventArgs e)
        {
            Label4.Content = "Information";
            ReturnImageSource();
            CheckpointLabel.Content = "Checkpoint 2";
            NameLandmark.Content = "Theatro Municipal";
            CheckpointLabel.Visibility = Visibility.Visible;
            NameLandmark.Visibility = Visibility.Visible;
            Services.Visibility = Visibility.Visible;
            Label1.Visibility = Visibility.Visible;
            Label2.Visibility = Visibility.Visible;
            Label3.Visibility = Visibility.Visible;
            Label4.Visibility = Visibility.Visible;
            Label5.Visibility = Visibility.Visible;
            Image.Visibility = Visibility.Visible;
            Image1.Visibility = Visibility.Visible;
            Image2.Visibility = Visibility.Visible;
            Image3.Visibility = Visibility.Visible;
            Image4.Visibility = Visibility.Visible;
            CloseButton.Visibility = Visibility.Visible;
            InfoBox.Visibility = Visibility.Visible;
        }

        private void Third_Click(object sender, RoutedEventArgs e)
        {
            Label4.Content = "Information";
            ReturnImageSource();
            CheckpointLabel.Content = "Checkpoint 3";
            NameLandmark.Content = "Parque do Ibirapuera";
            CheckpointLabel.Visibility = Visibility.Visible;
            NameLandmark.Visibility = Visibility.Visible;
            Services.Visibility = Visibility.Visible;
            Label1.Visibility = Visibility.Visible;
            Label2.Visibility = Visibility.Visible;
            Label3.Visibility = Visibility.Visible;;
            Image.Visibility = Visibility.Visible;
            Image1.Visibility = Visibility.Visible;
            Image2.Visibility = Visibility.Visible;
            CloseButton.Visibility = Visibility.Visible;
            InfoBox.Visibility = Visibility.Visible;
            Label4.Visibility = Visibility.Hidden;
            Label5.Visibility = Visibility.Hidden;
            Image3.Visibility = Visibility.Hidden;
            Image4.Visibility = Visibility.Hidden;
        }

        private void Fourth_Click(object sender, RoutedEventArgs e)
        {
            Label4.Content = "Medical";
            ReturnImageSource();
            CheckpointLabel.Content = "Checkpoint 4";
            NameLandmark.Content = "Jardim Luzitania";
            CheckpointLabel.Visibility = Visibility.Visible;
            NameLandmark.Visibility = Visibility.Visible;
            Services.Visibility = Visibility.Visible;
            Label1.Visibility = Visibility.Visible;
            Label2.Visibility = Visibility.Visible;
            Label3.Visibility = Visibility.Visible;
            Label4.Visibility = Visibility.Visible;
            Label5.Visibility = Visibility.Hidden;
            Image.Visibility = Visibility.Visible;
            Image1.Visibility = Visibility.Visible;
            Image2.Visibility = Visibility.Visible;
            Image3.Visibility = Visibility.Visible;
            Image4.Visibility = Visibility.Hidden;
            Image3.Source = new BitmapImage(new Uri(@"Resources/map-icon-medical.png", UriKind.Relative));
            CloseButton.Visibility = Visibility.Visible;
            InfoBox.Visibility = Visibility.Visible;
        }

        private void Fifth_Click(object sender, RoutedEventArgs e)
        {
            Label4.Content = "Information";
            ReturnImageSource();
            CheckpointLabel.Content = "Checkpoint 5";
            NameLandmark.Content = "Iguatemi";
            CheckpointLabel.Visibility = Visibility.Visible;
            NameLandmark.Visibility = Visibility.Visible;
            Services.Visibility = Visibility.Visible;
            Label1.Visibility = Visibility.Visible;
            Label2.Visibility = Visibility.Visible;
            Label3.Visibility = Visibility.Visible;
            Label4.Visibility = Visibility.Visible;
            Label5.Visibility = Visibility.Hidden;
            Image.Visibility = Visibility.Visible;
            Image1.Visibility = Visibility.Visible;
            Image2.Visibility = Visibility.Visible;
            Image3.Visibility = Visibility.Visible;
            Image4.Visibility = Visibility.Hidden;
            CloseButton.Visibility = Visibility.Visible;
            InfoBox.Visibility = Visibility.Visible;
        }

        private void Sixth_Click(object sender, RoutedEventArgs e)
        {
            Label4.Content = "Information";
            CheckpointLabel.Content = "Checkpoint 6";
            NameLandmark.Content = "Rua Lisboa";
            CheckpointLabel.Visibility = Visibility.Visible;
            NameLandmark.Visibility = Visibility.Visible;
            Services.Visibility = Visibility.Visible;
            Label1.Visibility = Visibility.Visible;
            Label2.Visibility = Visibility.Visible;
            Label3.Visibility = Visibility.Visible; ;
            Image.Visibility = Visibility.Visible;
            Image1.Visibility = Visibility.Visible;
            Image2.Visibility = Visibility.Visible;
            CloseButton.Visibility = Visibility.Visible;
            InfoBox.Visibility = Visibility.Visible;
            Label4.Visibility = Visibility.Hidden;
            Label5.Visibility = Visibility.Hidden;
            Image3.Visibility = Visibility.Hidden;
            Image4.Visibility = Visibility.Hidden;
        }

        private void Seventh_Click(object sender, RoutedEventArgs e)
        {
            Label4.Content = "Information";
            ReturnImageSource();
            CheckpointLabel.Content = "Checkpoint 7";
            NameLandmark.Content = "Cemitério da Consolação";
            CheckpointLabel.Visibility = Visibility.Visible;
            NameLandmark.Visibility = Visibility.Visible;
            Services.Visibility = Visibility.Visible;
            Label1.Visibility = Visibility.Visible;
            Label2.Visibility = Visibility.Visible;
            Label3.Visibility = Visibility.Visible;
            Label4.Visibility = Visibility.Visible;
            Label5.Visibility = Visibility.Visible;
            Image.Visibility = Visibility.Visible;
            Image1.Visibility = Visibility.Visible;
            Image2.Visibility = Visibility.Visible;
            Image3.Visibility = Visibility.Visible;
            Image4.Visibility = Visibility.Visible;
            CloseButton.Visibility = Visibility.Visible;
            InfoBox.Visibility = Visibility.Visible;
        }

        private void Eigth_Click(object sender, RoutedEventArgs e)
        {
            Label4.Content = "Information";
            ReturnImageSource();
            CheckpointLabel.Content = "Checkpoint 8";
            NameLandmark.Content = "Cemitério da Consolação";
            CheckpointLabel.Visibility = Visibility.Visible;
            NameLandmark.Visibility = Visibility.Visible;
            Services.Visibility = Visibility.Visible;
            Label1.Visibility = Visibility.Visible;
            Label2.Visibility = Visibility.Visible;
            Label3.Visibility = Visibility.Visible;
            Label4.Visibility = Visibility.Visible;
            Label5.Visibility = Visibility.Visible;
            Image.Visibility = Visibility.Visible;
            Image1.Visibility = Visibility.Visible;
            Image2.Visibility = Visibility.Visible;
            Image3.Visibility = Visibility.Visible;
            Image4.Visibility = Visibility.Visible;
            CloseButton.Visibility = Visibility.Visible;
            InfoBox.Visibility = Visibility.Visible;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            HiddenAll();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HiddenAll();
        }
    }
}
