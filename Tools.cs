using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marathon
{
    public class Tools
    {
        public string Month_IntToString(int month)
        {
            switch (month)
            {
                case 1:
                    return "января";
                case 2:
                    return "февраля";
                case 3:
                    return "марта";
                case 4:
                    return "апреля";
                case 5:
                    return "мая";
                case 6:
                    return "июня";
                case 7:
                    return "июля";
                case 8:
                    return "августа";
                case 9:
                    return "сентября";
                case 10:
                    return "октября";
                case 11:
                    return "ноября";
                case 12:
                    return "декабря";
            }
            return "Error";
        }

        public string DayOfWeek_EnglishToRussian(string day)
        {
            switch (day)
            {
                case "Monday":
                    return "понедельник";
                case "Tuesday":
                    return "вторник";
                case "Wednesday":
                    return "среда";
                case "Thursday":
                    return "четверг";
                case "Friday":
                    return "пятница";
                case "Saturday":
                    return "суббота";
                case "Sunday":
                    return "воскресенье";
            }
            return "Error";
        }

        public string RestOfTime(TimeSpan timeSpan)
        {
            string days = timeSpan.Days.ToString();
            if (timeSpan.Days < 10)
            {
                if (timeSpan.Days == 1)
                {
                    days = "1 день";
                }
                else if (timeSpan.Days > 1 && timeSpan.Days < 5)
                {
                    days = timeSpan.Days.ToString() + " дня";
                }
                else
                {
                    days = timeSpan.Days.ToString() + " дней";
                }
            }
            else
            {
                if (Convert.ToInt32(days[days.Length - 2].ToString() + days[days.Length - 1].ToString()) > 10 && Convert.ToInt32(days[days.Length - 2].ToString() + days[days.Length - 1].ToString()) < 20)
                {
                    days = timeSpan.Days.ToString() + " дней";
                }
                else if (Convert.ToInt32(days[days.Length - 1].ToString()) == 1)
                {
                    days = timeSpan.Days.ToString() + " день";
                }
                else if (Convert.ToInt32(days[days.Length - 2].ToString() + days[days.Length - 1].ToString()) > 1 && Convert.ToInt32(days[days.Length - 2].ToString() + days[days.Length - 1].ToString()) < 5)
                {
                    days = timeSpan.Days.ToString() + " дня";
                }
                else
                {
                    days = timeSpan.Days.ToString() + " дней";
                }
            }

            string hours = timeSpan.Hours.ToString();
            if (timeSpan.Hours < 10)
            {
                if (timeSpan.Hours == 1)
                {
                    hours = "1 час";
                }
                else if (timeSpan.Hours > 1 && timeSpan.Hours < 5)
                {
                    hours = timeSpan.Hours.ToString() + " часа";
                }
                else
                {
                    hours = timeSpan.Hours.ToString() + " часов";
                }
            }
            else
            {
                if (Convert.ToInt32(hours[hours.Length - 2].ToString() + hours[hours.Length - 1].ToString()) > 10 && Convert.ToInt32(hours[hours.Length - 2].ToString() + hours[hours.Length - 1].ToString()) < 20)
                {
                    hours = timeSpan.Hours.ToString() + " часов";
                }
                else if (Convert.ToInt32(hours[hours.Length - 1].ToString()) == 1)
                {
                    hours = timeSpan.Hours.ToString() + " час";
                }
                else if (Convert.ToInt32(hours[hours.Length - 2].ToString() + hours[hours.Length - 1].ToString()) > 1 && Convert.ToInt32(hours[hours.Length - 2].ToString() + hours[hours.Length - 1].ToString()) < 5)
                {
                    hours = timeSpan.Hours.ToString() + " часа";
                }
                else
                {
                    hours = timeSpan.Hours.ToString() + " часов";
                }
            }

            string minutes = timeSpan.Minutes.ToString();
            if (timeSpan.Minutes < 10)
            {
                if (timeSpan.Minutes == 1)
                {
                    minutes = "1 минута";
                }
                else if (timeSpan.Minutes > 1 && timeSpan.Minutes < 5)
                {
                    minutes = timeSpan.Minutes.ToString() + " минуты";
                }
                else
                {
                    minutes = timeSpan.Minutes.ToString() + " минут";
                }
            }
            else
            {
                if (Convert.ToInt32(minutes[minutes.Length - 2].ToString() + minutes[minutes.Length - 1].ToString()) > 10 && Convert.ToInt32(minutes[minutes.Length - 2].ToString() + minutes[minutes.Length - 1].ToString()) < 20)
                {
                    minutes = timeSpan.Minutes.ToString() + " минут";
                }
                else if (Convert.ToInt32(minutes[minutes.Length - 1].ToString()) == 1)
                {
                    minutes = timeSpan.Minutes.ToString() + " минута";
                }
                else if (Convert.ToInt32(minutes[minutes.Length - 2].ToString() + minutes[minutes.Length - 1].ToString()) > 1 && Convert.ToInt32(minutes[minutes.Length - 2].ToString() + minutes[minutes.Length - 1].ToString()) < 5)
                {
                    minutes = timeSpan.Minutes.ToString() + " минуты";
                }
                else
                {
                    minutes = timeSpan.Minutes.ToString() + " минут";
                }
            }
            return String.Format("{0}, {1} и {2}", days, hours, minutes);
        }

    }
}
