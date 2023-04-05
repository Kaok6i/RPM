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
    /// Логика взаимодействия для MarathonRegistrationWindow.xaml
    /// </summary>
    public partial class MarathonRegistrationWindow : Window
    {
        public MarathonRegistrationWindow()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Window window = new MainWindow();
            window.Show();
            this.Close();
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

            TotalSumLabel.Content = TotalSum.ToString();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            TimeSpan timeSpan = new DateTime(2022, 6, 28, 0, 0, 0) - dateTime;
            BottomLabel.Content = String.Format("{0} до старта марафона!",
                                                tools.RestOfTime(timeSpan));
        }

        private void Info_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (FundComboBox.Text != "")
            {
              if (FundComboBox.SelectedIndex == 0)
                {
                    InfoWindow IW = new InfoWindow();
                    IW.Show();
                }
                else if (FundComboBox.SelectedIndex == 1)
                {
                    InfoWindow1 IW = new InfoWindow1();
                    IW.Show();
                }
                else if (FundComboBox.SelectedIndex == 2)
                {
                    InfoWindow2 IW = new InfoWindow2();
                    IW.Show();
                }
            }
            else
            {
                MessageBox.Show("Сначала выберите фонд из списка...", "Уведомление:", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MarathonRegistration_Click(object sender, RoutedEventArgs e)
        {
            if (!(CheckBoxOne.IsChecked == true || CheckBoxTwo.IsChecked == true || CheckBoxThree.IsChecked == true))
            {
                MessageBox.Show("Выберите марафон!", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!(RadioButtonOne.IsChecked == true || RadioButtonTwo.IsChecked == true || RadioButtonThree.IsChecked == true))
            {
                MessageBox.Show("Выберите комплект!", "Уведомление!", MessageBoxButton.OK,MessageBoxImage.Error);
            }
            else if (FundPayBox.Text == "" || FundComboBox.Text == "")
            {
                MessageBox.Show("Выберите фонд и сумму взноса!", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {

                ThanksRegistrarionMarathon TRM = new ThanksRegistrarionMarathon();
                TRM.Show();
                this.Close();
            }
        }

        public int TotalSum = 0;

        private void ChangeTotalSum()
        {
            TotalSum = 0;
            if (CheckBoxOne.IsChecked == true)
            {
                TotalSum += 145;
            }
            if (CheckBoxTwo.IsChecked == true)
            {
                TotalSum += 75;
            }
            if (CheckBoxThree.IsChecked == true)
            {
                TotalSum += 20;
            }
            if (RadioButtonOne.IsChecked == true)
            {
                TotalSum += 0;
            }
            if (RadioButtonTwo.IsChecked == true)
            {
                TotalSum += 20;
            }
            if (RadioButtonThree.IsChecked == true)
            {
                TotalSum += 45;
            }
            if (FundPayBox.Text != "")
            {
                try
                {
                    TotalSum += Convert.ToInt32(FundPayBox.Text);
                }
                catch
                {

                }
            }
            TotalSumLabel.Content = "$" + TotalSum.ToString();
        }
        private void CheckBoxOne_Checked(object sender, RoutedEventArgs e)
        {
            ChangeTotalSum();
        }

        private void CheckBoxOne_Unchecked(object sender, RoutedEventArgs e)
        {
            ChangeTotalSum();
        }

        private void RadioButtonOne_Click(object sender, RoutedEventArgs e)
        {
            ChangeTotalSum();
        }

        private void FundPayBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ChangeTotalSum();
        }

        private void FundPayBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key < Key.D0 || e.Key > Key.D9 && e.Key != Key.Back)
            {
                e.Handled = true;
            }
        }
    }
}
