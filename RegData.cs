using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marathon
{
    public static class RegData
    {
        public static string Email;
        public static string Password;
        public static string Name;
        public static string SecondName;
        public static string Sex;
        public static string ImagePath;
        public static string Country;
        public static string Birthday;

        public static void Registration()
        {

            Bitmap bitmap = new Bitmap(ImagePath);
            ImagePath = @"База\Фото пользователей\" + Email.Substring(0, Email.Length - (Email.Length - Email.IndexOf('@'))) + ".png";
            bitmap.Save(ImagePath, ImageFormat.Png);

            string data;

            using (Stream stream = File.OpenRead(@"База\Пользователи.txt"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    data = reader.ReadToEnd();
                }
            }

            using (Stream stream = File.Create(@"База\Пользователи.txt"))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(data + '\n');
                    writer.Write(User());
                }
            }

        }

        public static string User()
        {
            return Email + ";" + Password + ";" + Name + ";" + SecondName + ";" + "Бегун" + ";" + Country + ";" + "none" + ";" + Sex + ";" + Birthday + ";" + ImagePath + ";" + "Пуфик";
        }

        public static void Clear()
        {
            Email = "";
            Password = "";
            Name = "";
            SecondName = "";
            Sex = "";
            ImagePath = "";
            Country = "";
            Birthday = "";
        }

    }
}
