using System;
using System.Text.RegularExpressions;
using Microsoft.Win32;
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
    /// Логика взаимодействия для RegisterAsNewRunner.xaml
    /// </summary>
    public partial class RegisterAsNewRunner : Window
    {
        public RegisterAsNewRunner()
        {
            InitializeComponent();
        }
        public Tools tools = new Tools();

        private bool HaveNumber(string text)
        {
            foreach (char c in text)
            {
                if ("0123456789".Contains(c))
                {
                    return true;
                }
            }
            return false;
        }

        private bool HaveBigChar(string text)
        {
            Regex regex = new Regex(@"[A-Z]");
            foreach (char c in text)
            {
                if (!(regex.Matches(c.ToString()).Count == 0))
                {
                    return true;
                }
            }
            return false;
        }

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
            BottomLabel.Content = String.Format("{0} до старта марафона!",tools.RestOfTime(timeSpan));
            /* Стартовое отображение оставшегося времени */
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            TimeSpan timeSpan = new DateTime(2022, 6, 28, 0, 0, 0) - dateTime;
            BottomLabel.Content = String.Format("{0} до старта марафона!",tools.RestOfTime(timeSpan));
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            RegData.Clear();
            MainWindow MW = new MainWindow();
            MW.Show();
            this.Close();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            bool AllFull = false;
            bool GoodPassword = false;
            bool GoodEmail = false;
            bool GoodBirthday = false;
            if (Email.Text != "" && Password.Text != "" && Name.Text != "" &&
                SecondName.Text != "" && Sex.Text != "" && RegData.ImagePath != "" &&
                Country.Text != "" && Calendar.SelectedDate.HasValue)
            {
                AllFull = true;
            }
            else
            {
                MessageBox.Show("Не все поля заполнены!", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (Password.Text == EqualPassword.Text)
            {
                if (Password.Text.Contains('!') || Password.Text.Contains('@') || Password.Text.Contains('#') ||
                    Password.Text.Contains('$') || Password.Text.Contains('%') || Password.Text.Contains('^'))
                {
                    if (HaveNumber(Password.Text))
                    {
                        if (HaveBigChar(Password.Text))
                        {
                            if (Password.Text.Length >= 6)
                            {
                                GoodPassword = true;
                            }
                            else
                            {
                                MessageBox.Show("Пароль должен содержать минимум шесть символов!", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Пароль должен содержать хотя бы одну большую букву!", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пароль должен содержать хотя бы одну цифру!", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Пароль должен содержать один из этих символов: \"!@#$%^\"!", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Пароли не совпадают!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (Regex.IsMatch(Email.Text, @"[A-Za-z0-9]+\@\w+\.\w+"))
            {
                GoodEmail = true;
            }
            else
            {
                MessageBox.Show("Неверный email!", "Ошибка!", MessageBoxButton.OK,MessageBoxImage.Error);
            }
            if (Calendar.SelectedDate.HasValue)
            {
                if ((DateTime.Now.Year - Calendar.SelectedDate.Value.Year == 10 && DateTime.Now > Calendar.SelectedDate.Value) ||
                 DateTime.Now.Year - Calendar.SelectedDate.Value.Year > 10)
                {
                    GoodBirthday = true;
                }
                else
                {
                    MessageBox.Show("Бегун должен быть минимум 10-ти летнего возраста!", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Не выбрана дата!", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (GoodPassword && GoodEmail && GoodBirthday && AllFull)
            {
                RegData.Email = Email.Text;
                RegData.Password = Password.Text;
                RegData.Name = Name.Text;
                RegData.SecondName = SecondName.Text;
                RegData.Sex = Sex.Text;
                RegData.Birthday = Calendar.SelectedDate.ToString();
                RegData.Country = Country.Text;
                RegData.Registration();
                FocusedUser.FocusPocus(RegData.User());
                MarathonRegistrationWindow MRW = new MarathonRegistrationWindow();
                MRW.Show();
                this.Close();
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            RegData.Clear();
            MainWindow MW = new MainWindow();
            MW.Show();
            this.Close();
        }

        private void ViewImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Nullable<bool> result = openFileDialog.ShowDialog();
            if (result == true)
            {
                string filename = openFileDialog.FileName;
                RegData.ImagePath = filename;
                FileNameBox.Text = openFileDialog.FileName.Trim();
                SelectedImage.Source = new BitmapImage(new Uri(filename));
            }
        }
    }
}
