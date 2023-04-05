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
    /// Логика взаимодействия для FindOutMore.xaml
    /// </summary>
    public partial class FindOutMore : Window
    {
        public FindOutMore()
        {
            InitializeComponent();
        }
        public Tools tools = new Tools();
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Window window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void BtnMS_Click(object sender, RoutedEventArgs e) // Информация об марафоне
        {
            InfoAboutMarathon IAM = new InfoAboutMarathon();
            IAM.Show();
            this.Close();
        }

        private void BtnPreviousResults_Click(object sender, RoutedEventArgs e) // Посмотреть предыдущие результаты
        {

        }

        private void BtnBMICalc_Click(object sender, RoutedEventArgs e) // Калькулятор ИМТ
        {
            BMICalculatorWindow BMICalculator = new BMICalculatorWindow();
            BMICalculator.Show();
            this.Close();
        }

        private void BtnDuration_Click(object sender, RoutedEventArgs e) // Длительность марафона
        {
            HowLongMarathon HLM = new HowLongMarathon();
            HLM.Show();
            this.Close();
        }

        private void BtnListOfCharitites_Click(object sender, RoutedEventArgs e) // Список поддерживающих организаций
        {
            ListOfCharities LOC = new ListOfCharities();
            LOC.Show();
            this.Close();
        }

        private void BtnBMRCalc_Click(object sender, RoutedEventArgs e) // BMR калькулятор
        {
            var BMR = new BMRCalculatorWindow();
            BMR.Show();
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
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            TimeSpan timeSpan = new DateTime(2022, 6, 28, 0, 0, 0) - dateTime;
            BottomLabel.Content = String.Format("{0} до старта марафона!",
                                                tools.RestOfTime(timeSpan));
        }
    }
}
