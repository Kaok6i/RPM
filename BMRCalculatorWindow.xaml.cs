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
    /// Логика взаимодействия для BMRCalculatorWindow.xaml
    /// </summary>
    public partial class BMRCalculatorWindow : Window
    {
        Tools tools = new Tools();
        BMR BMRS = new BMR();
        int M = 0, F = 0;
        public BMRCalculatorWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var FOM = new FindOutMore();
            FOM.Show();
            this.Close();
        }

        private void Man_Click(object sender, RoutedEventArgs e)
        {
            M++;
            F = 0;
            FemaleFlag.Visibility = Visibility.Hidden;
            MaleFlag.Visibility = Visibility.Visible;
        }

        private void Female_Click(object sender, RoutedEventArgs e)
        {
            F++;
            M = 0;
            FemaleFlag.Visibility = Visibility.Visible;
            MaleFlag.Visibility = Visibility.Hidden;
        }

        private void GetResult_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BMRLabel.Content = "";
                Seated.Content = "";
                SmallActivity.Content = "";
                MeduimActivity.Content = "";
                PowerActivity.Content = "";
                MaxActivity.Content = "";
                if (M != 0 || F != 0)
                {
                    if (M != 0)
                    {
                        if (HeightBox.Text != "" && WeightBox.Text != "" && AgeBox.Text != "")
                        {
                            var bmr = BMRS.GetBMR(Convert.ToDouble(AgeBox.Text), Convert.ToDouble(HeightBox.Text), Convert.ToDouble(WeightBox.Text), true);
                            BMRLabel.Content = string.Format("{0:f3}", bmr);
                            Seated.Content = string.Format("{0:f3}", BMRS.Seated(bmr));
                            SmallActivity.Content = string.Format("{0:f3}", BMRS.SmallActivity(bmr));
                            MeduimActivity.Content = string.Format("{0:f3}", BMRS.MeduimActivity(bmr));
                            PowerActivity.Content = string.Format("{0:f3}", BMRS.PowerActivity(bmr));
                            MaxActivity.Content = string.Format("{0:f3}", BMRS.MaxActivity(bmr));
                        }
                        else
                        {
                            MessageBox.Show("Вы забыли ввести значения в одно из полей!", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Stop);
                        }
                    }
                    else
                    {
                        var bmr = BMRS.GetBMR(Convert.ToDouble(AgeBox.Text), Convert.ToDouble(HeightBox.Text), Convert.ToDouble(WeightBox.Text), false);
                    }
                }
                else
                {
                    MessageBox.Show("Вы забыли выбрать пол!", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch
            {

            }
        }
    }
}
