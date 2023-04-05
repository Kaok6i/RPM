using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marathon
{
    public static class FocusedUser
    {
        public static bool focused = false;
        public static string user;

        public static void FocusPocus(string user)
        {
            FocusedUser.user = user;
            FocusedUser.focused = true;
        }

        public static void AvadaCedavra()
        {
            FocusedUser.user = "";
            FocusedUser.focused = false;
        }
    }
}
