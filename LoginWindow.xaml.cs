using System;
using System.IO;
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
using System.Windows.Shapes;

namespace Marathon
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
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

        public List<string> GetFunds()
        {
            string[] funds;
            using (Stream stream = File.OpenRead(@"База\Фонды.txt"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    funds = reader.ReadToEnd().Split(';');
                }
            }
            List<string> list = new List<string>();
            foreach (string fund in funds)
            {
                list.Add(fund);
            }
            return list;
        }

        public List<string> GetUsers()
        {
            string[] lines;
            using (Stream stream = File.OpenRead(@"База\Пользователи.txt"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    lines = reader.ReadToEnd().Split('\n');
                }
            }
            List<string> list = new List<string>();
            foreach (string line in lines)
            {
                list.Add(line);
            }
            return list;
        }

        private void Login_Click(object sender, RoutedEventArgs e) // Вход пользователя
        {
            string email = EmailBox.Text;
            string password = PasswordBox.Text;
            List<string> users = GetUsers();
            foreach (string user in users)
            {
                string[] data = user.Split(';');
                if (email == data[0] && password == data[1])
                {
                    if (data[4] == "Бегун")
                    {
                        FocusedUser.FocusPocus(user);
                        RunnerMenuWindow RMW = new RunnerMenuWindow();
                        RMW.Show();
                        this.Close();
                    }
                    else if (data[4] == "Администратор")
                    {
                        FocusedUser.FocusPocus(user);
                        AdminMenuWindow AMW = new AdminMenuWindow();
                        AMW.Show();
                        this.Close();
                    }
                    else if (data[4] == "Координатор")
                    {
                        FocusedUser.FocusPocus(user);
                        CoordinatorMenuWindow CMW = new CoordinatorMenuWindow();
                        CMW.Show();
                        this.Close();
                    }
                }
            }
            if (FocusedUser.focused == false)
            {
                MessageBox.Show("Отказано в доступе!\nНеправильный логин или пароль!", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            /* if (EmailBox.Text == "Runner101@mail.com" && PasswordBox.Text == "BestRunner") // Логин и пароль для бегуна
             {
                 RunnerMenuWindow RMW = new RunnerMenuWindow();
                 RMW.Show();
                 this.Close();
             }
             else if (EmailBox.Text == "Coordinator102@mail.com" && PasswordBox.Text == "BestCoordinator") // Логин и пароль для координатора
             {
                 CoordinatorMenuWindow CMW = new CoordinatorMenuWindow();
                 CMW.Show();
                 this.Close();
             }
             else if (EmailBox.Text == "AdminMain@mail.com" && PasswordBox.Text == "BestAdmin") // Логин и пароль для администратора
             {
                 AdminMenuWindow AMW = new AdminMenuWindow();
                 AMW.Show();
                 this.Close();
             }
             else
             {
                 MessageBox.Show("Вы ввели некорректные данные!\nПовторите ввод!","Уведомление!");
             } */
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MW = new MainWindow();
            MW.Show();
            this.Close();
        }

        private void EmailBox_GotFocus(object sender, RoutedEventArgs e)
        {
            int K = 0;
            if (K == 0)
            { 
                EmailBox.Text = "";
                K++;
            }
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            int K = 0;
            if (K == 0)
            {
                PasswordBox.Text = "";
                K++;
            }
        }
    }
}
