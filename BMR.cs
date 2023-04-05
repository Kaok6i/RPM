using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marathon
{
    public class BMR
    {
        public double GetBMR(double Age, double Height, double Weight, bool Men)
        {
            if (Men)
            {
                return Math.Round((9.99 * Weight) + (6.25 * Height) - 4.92 * Age,3) / 1000;
            }
            else
            {
                return Math.Round((9.99 * Weight) + (6.25 * Height) - (4.92 * Age) - 161,3) / 1000;
            }
        }
        public double Seated(double BMR)
        {
            return BMR * 1.2;
        }
        public double SmallActivity(double BMR)
        {
            return BMR * 1.375;
        }
        public double MeduimActivity(double BMR)
        {
            return BMR * 1.55;
        }
        public double PowerActivity(double BMR)
        {
            return BMR * 1.725;
        }
        public double MaxActivity(double BMR)
        {
            return BMR * 1.9;
        }

    }
}
