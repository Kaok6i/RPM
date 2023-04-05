using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Marathon
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public Tools tools = new Tools();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            /* Создание таймера */
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Start();
            /* Создание таймера */

            /* Стартовое отображение даты и оставшегося времени */
            DateTime dateTime = DateTime.Now;
            TopLabel.Content = String.Format("{0} {1} {2} {3}",
                                             tools.DayOfWeek_EnglishToRussian(dateTime.DayOfWeek.ToString()), dateTime.Day, tools.Month_IntToString(dateTime.Month), dateTime.Year);

            TimeSpan timeSpan = new DateTime(2022, 6, 28, 0, 0, 0) - dateTime;
            BottomLabel.Content = String.Format("{0} до старта марафона!",
                                                tools.RestOfTime(timeSpan));
            /* Стартовое отображение даты и оставшегося времени */
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            TopLabel.Content = String.Format("{0} {1} {2} {3}",
                                                        tools.DayOfWeek_EnglishToRussian(dateTime.DayOfWeek.ToString()), dateTime.Day, tools.Month_IntToString(dateTime.Month), dateTime.Year);

            TimeSpan timeSpan = new DateTime(2022, 6, 28, 0, 0, 0) - dateTime;
            BottomLabel.Content = String.Format("{0} до старта марафона!",
                                                tools.RestOfTime(timeSpan));
        }

        private void RunnerButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterAsRunnerWindow RARW = new RegisterAsRunnerWindow();
            RARW.Show();
            this.Close();
        }

        private void SponsorButton_Click(object sender, RoutedEventArgs e)
        {
            SponsorWindow SW = new SponsorWindow();
            SW.Show();
            this.Close();
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            FindOutMore FOM = new FindOutMore();
            FOM.Show();
            this.Close();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow LW = new LoginWindow();
            LW.Show();
            this.Close();
        }
    }
}
