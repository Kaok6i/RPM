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
    /// Логика взаимодействия для RegisterAsRunnerWindow.xaml
    /// </summary>
    public partial class RegisterAsRunnerWindow : Window
    {
        public RegisterAsRunnerWindow()
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

        private void Back_Click(object sender, RoutedEventArgs e) // Кнопка возращения назад
        {
            MainWindow MW = new MainWindow();
            MW.Show();
            this.Close();
        }

        private void LoginBefore_Click(object sender, RoutedEventArgs e) // Для старых пользователей - вход
        {
            LoginWindow LW = new LoginWindow();
            LW.Show();
            this.Close();
        }

        private void LoginNew_Click(object sender, RoutedEventArgs e) // Для новых пользователей - регистрация
        {
            RegisterAsNewRunner RAWR = new RegisterAsNewRunner();
            RAWR.Show();
            this.Close();
        }
    }
}
