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
    /// Логика взаимодействия для BMICalculatorWindow.xaml
    /// </summary>
    public partial class BMICalculatorWindow : Window
    {
        public BMICalculatorWindow()
        {
            InitializeComponent();
        }
        int M = 0, F = 0;
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

        private void Man_Click(object sender, RoutedEventArgs e)
        {
            M++;
            F=0;
        }

        private void GetResult_Click(object sender, RoutedEventArgs e)
        { 
            if (M == 0 & F == 0 || M ==0 || F == 0)
            {
                MessageBox.Show("Вы не выбрали пол!\nВыберите пол прежде чем начинать расчет ИМТ!","Уведомление!",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            if (M != 0 || F !=0)
            {
                if (HeightBox.Text != "" && WeightBox.Text != "")
                {
                    if (Convert.ToDouble(HeightBox.Text) == 0 || Convert.ToDouble(WeightBox.Text) == 0)
                    {
                        MessageBox.Show("Вес или рост не может равняться нулю!","Уведомление!", MessageBoxButton.OK,MessageBoxImage.Stop);
                    }
                    else
                    {
                        double H = Math.Pow(Convert.ToDouble(HeightBox.Text) / 100, 2), W = Convert.ToDouble(WeightBox.Text), Result = W / H; // H - рост, W - вес
                        if (Result <= 20) // Недостаток веса
                        {
                            StatusImage.Source = new BitmapImage(new Uri(@"Resources/bmi-underweight-icon.png", UriKind.Relative));
                            StatusLabel.Text = string.Format("Недостаток веса ({0:f2})", Result);
                            StatusSlider.Value = Result;
                        }
                        else if (Result > 20 & Result <= 25) // Нормальный вес
                        {
                            StatusImage.Source = new BitmapImage(new Uri(@"Resources/bmi-healthy-icon.png", UriKind.Relative));
                            StatusLabel.Text = string.Format("Нормальный вес ({0:f2})", Result);
                            StatusSlider.Value = Result;
                        }
                        else if (Result >= 25.1 & Result <= 27.0) // Избыточный
                        {
                            StatusImage.Source = new BitmapImage(new Uri(@"Resources/bmi-overweight-icon.png", UriKind.Relative));
                            StatusLabel.Text = string.Format("Избыточный({0:f2})", Result);
                            StatusSlider.Value = Result;
                        }
                        else if (Result >= 27.1) // Ожирение
                        {
                            StatusImage.Source = new BitmapImage(new Uri(@"Resources/bmi-obese-icon.png", UriKind.Relative));
                            StatusLabel.Text = string.Format("Ожирение({0:f2})", Result);
                            StatusSlider.Value = Result;
                        }
                    }
                }    
            }
        }

        private void Female_Click(object sender, RoutedEventArgs e)
        {
            F++;
            M=0;
        }
    }
}
