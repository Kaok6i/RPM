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
using System.Windows.Shapes;

namespace Marathon
{
    /// <summary>
    /// Логика взаимодействия для SponsorWindow.xaml
    /// </summary>
    public partial class SponsorWindow : Window
    {
        public SponsorWindow()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e) // Возращение назад V1
        {
            Window window = new MainWindow();
            window.Show();
            this.Close();
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
            BottomLabel.Content = String.Format("{0} до старта марафона!",
                                                tools.RestOfTime(timeSpan));
            /* Стартовое отображение оставшегося времени */
        }

        public Tools tools = new Tools();

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            TimeSpan timeSpan = new DateTime(2022, 6, 28, 0, 0, 0) - dateTime;
            BottomLabel.Content = String.Format("{0} до старта марафона!",
                                                tools.RestOfTime(timeSpan));
        }

        private void Minus_Click(object sender, RoutedEventArgs e) // Уменьшение суммы денег которую жертвует пользователь
        {
            int sum = Convert.ToInt32(SumBox.Text);
            if (sum != 0)
            {
                if (sum - 10 < 0)
                {
                    sum = 0;
                }
                else
                {
                    sum = sum - 10;
                }
                SumBox.Text = sum.ToString();
            }
        }

        private void Plus_Click(object sender, RoutedEventArgs e) // Увеличение суммы денег которую жертвует пользователь
        {
            int sum = Convert.ToInt32(SumBox.Text);
            sum += 10;
            SumBox.Text = sum.ToString();
        }

        private void SumBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SumBox.Text == "")
            {
                Money.Content = "";
            }
            else
            {
                Money.Content = "$" + Convert.ToInt32(SumBox.Text);
            }
        }

        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBox1.SelectedIndex != -1)
            {
            if (NameBox.Text == "" || CardBox.Text == "" || CardNumberBox.Text == "" || CardMonthBox.Text == "" || CardYearBox.Text == "" || CVCBox.Text == "")
                MessageBox.Show("Вы забыли заполнить одно из предложенных окон!\nПовторите ввод!","Уведомление!", MessageBoxButton.OK,MessageBoxImage.Error);
            else
            {
                if (Convert.ToInt32(CardMonthBox.Text) < 1 || Convert.ToInt32(CardMonthBox.Text) > 12)
                     MessageBox.Show("Вы ввели несуществующий месяц!\nПовторите ввод!", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {   if (CardNumberBox.Text.Length != 19 || CardMonthBox.Text.Length != 2 || CardYearBox.Text.Length != 4 || CVCBox.Text.Length != 3)
                        MessageBox.Show("Неверный формат заполнения карты!\nПовторите ввод!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    else if (new DateTime(Convert.ToInt32(CardYearBox.Text), Convert.ToInt32(CardMonthBox.Text), DateTime.DaysInMonth(Convert.ToInt32(CardYearBox.Text), Convert.ToInt32(CardMonthBox.Text))) < DateTime.Now)
                        MessageBox.Show("У вас недействительная карта, у неё истек срок годности!\nПовторите ввод!", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Error);
                    else
                    {
                        Donate.RunnerName = ComboBox1.Text;
                        Donate.AmountOfMoney = Money.Content.ToString();
                        FondName.FondNM = LabelFond.Content.ToString();
                        Window window = new SponsorshipConfirmation();
                        window.Show();
                        this.Close();
                    }
                }
            }
            }
            else
                MessageBox.Show("Вы забыли выбрать бегуна для спонсорства!\nПовторите ввод!","Уведомление!",MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) // Возращение назад V2
        {
            Window window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void SumBox_KeyDown(object sender, KeyEventArgs e) // Запрет ввода не-цифр для суммы пожертвования
        {
            if (e.Key < Key.D0 || e.Key > Key.D9 && e.Key != Key.Back)
            {
                e.Handled = true;
            }
        }

        private void Info_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) // Просмотр информаций об организаций
        {
            if (ComboBox1.SelectedIndex == 0)
            {
                Window window = new InfoWindow();
                window.Show();
            }
            if (ComboBox1.SelectedIndex == 1)
            {
                Window window = new InfoWindow1();
                window.Show();
            }
            if (ComboBox1.SelectedIndex == 2)
            {
                Window window = new InfoWindow2();
                window.Show();
            }
        }

            private void CVCBox_KeyDown(object sender, KeyEventArgs e) // Ограничение для номера CVC карты
        {
            if (e.Key < Key.D0 || e.Key > Key.D9 || CVCBox.Text.Length == 3 && e.Key != Key.Back)
                e.Handled = true;
        }
        private void CardMonthBox_KeyDown(object sender, KeyEventArgs e) // Ограничение для месяца карты
        {
            if (e.Key < Key.D0 || e.Key > Key.D9 || CardMonthBox.Text.Length == 2 && e.Key != Key.Back)
            {
                e.Handled = true;
            }
        }

        private void CardYearBox_KeyDown(object sender, KeyEventArgs e) // Ограничение для года карты
        {
            if (e.Key < Key.D0 || e.Key > Key.D9 || CardYearBox.Text.Length == 4 && e.Key != Key.Back)
            {
                e.Handled = true;
            }
        }

        private void CardNumberBox_KeyDown(object sender, KeyEventArgs e) // Ограничение для номера карты
        {
            if (e.Key < Key.D0 || e.Key > Key.D9 || CardNumberBox.Text.Length == 19 && e.Key != Key.Back)
            {
                e.Handled = true;
            }
            if (CardNumberBox.Text.Length == 4 || CardNumberBox.Text.Length == 9 || CardNumberBox.Text.Length == 14)
            {
                CardNumberBox.Text += " ";
                CardNumberBox.Select(CardNumberBox.Text.Length, 0);
            }
        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e) // Изменение данных об фондах поддержки
        {
            if (ComboBox1.SelectedIndex == 0)
               LabelFond.Content = "Фонд кошек";
            if (ComboBox1.SelectedIndex == 1)
                LabelFond.Content = "Фонд собак";
            if (ComboBox1.SelectedIndex == 2)
                LabelFond.Content = "Фонд инвалидов";
        }
    }
}
