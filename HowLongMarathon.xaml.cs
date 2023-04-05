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
using System.Windows.Threading;

namespace Marathon
{
    /// <summary>
    /// Логика взаимодействия для HowLongMarathon.xaml
    /// </summary>
    public partial class HowLongMarathon : Window
    {
        public HowLongMarathon()
        {
            InitializeComponent();
        }
        Tools tools = new Tools();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            /* Создание таймера */
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Start();
            /* Создание таймера */

            /* Стартовое отображение оставшегося времени */
            DateTime dateTime = DateTime.Now;
            TimeSpan timeSpan = new DateTime(2022, 6, 28, 0, 0, 0) - dateTime;
            BottomLabel.Content = String.Format("{0} до старта марафона!",
                                                tools.RestOfTime(timeSpan));
            /* Стартовое отображение оставшегося времени */
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            TimeSpan timeSpan = new DateTime(2022, 6, 28, 0, 0, 0) - dateTime;
            BottomLabel.Content = String.Format("{0} до старта марафона!",
                                                tools.RestOfTime(timeSpan));
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            FindOutMore FOM = new FindOutMore();
            FOM.Show();
            this.Close();
        }

        private void SpeedImage1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           SelectedImage.Source = new BitmapImage(new Uri(@"Resources/f1-car.jpg", UriKind.Relative));
            NameTabItem.Content = "F1-машина";
            InfoAboutTabItem.Text = "Едет со скоростью 150 км/ч. Проидет марафон за 7 минут и 20 секунд.";
        }

        private void SpeedImage2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SelectedImage.Source = new BitmapImage(new Uri(@"Resources/Pinguin.png", UriKind.Relative));
            NameTabItem.Content = "Пингвин";
            InfoAboutTabItem.Text = "Ходит со скоростью 5 км/ч. Проидет марафон за 8 часов и 27 минут.";
        }

        private void SpeedImage3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SelectedImage.Source = new BitmapImage(new Uri(@"Resources/Capybara.png", UriKind.Relative));
            NameTabItem.Content = "Капибара";
            InfoAboutTabItem.Text = "Ходит со скоростью 10 км/ч. Проидет марафон за 5 часов и 20 минут.";
        }
        private void SpeedImage4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SelectedImage.Source = new BitmapImage(new Uri(@"Resources/worm.jpg", UriKind.Relative));
            NameTabItem.Content = "Червяк";
            InfoAboutTabItem.Text = "Ползет со скоростью 0,01 км/ч. Проидет марафон за 70 часов и 35 минут.";
        }

        private void SpeedImage5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SelectedImage.Source = new BitmapImage(new Uri(@"Resources/jaguar.jpg", UriKind.Relative));
            NameTabItem.Content = "Ягуар";
            InfoAboutTabItem.Text = "Бегает со скоростью 70 км/ч. Проидет марафон за 15 минут и 35 секунд.";
        }

        private void DistanceImage1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SelectedImage.Source = DistanceImage1.Source;
            NameTabItem.Content = "Airbus A380";
            InfoAboutTabItem.Text = "Длина самолета равна 0,08 км, поэтому потребуется 525 самолетов чтобы заполнить дистанцию марафона";
        }

        private void DistanceImage2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SelectedImage.Source = DistanceImage2.Source;
            NameTabItem.Content = "Шлепки";
            InfoAboutTabItem.Text = "Размер шлепок равен 0,00029 км, поэтому потребуется 144 827 шлепок чтобы заполнить дистанцию марафона";
        }

        private void DistanceImage3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SelectedImage.Source = DistanceImage3.Source;
            NameTabItem.Content = "Футбольное поле";
            InfoAboutTabItem.Text = "Длина поля равна 0,12 км, поэтому потребуется 350 футбольных полей чтобы заполнить дистанцию марафона";
        }

        private void DistanceImage4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SelectedImage.Source = DistanceImage4.Source;
            NameTabItem.Content = "Кремль";
            InfoAboutTabItem.Text = "Длина стен московского Кремля равно 2,2 км, поэтому потребуется 20 стен чтобы заполнить дистанцию марафона";
        }
            private void DistanceImage5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SelectedImage.Source = DistanceImage5.Source;
            NameTabItem.Content = "Автобус";
            InfoAboutTabItem.Text = "Длина автобуса равна 2,2 км, поэтому потребуется 6087 автобусов чтобы заполнить дистанцию марафона";
        }
    }
}
