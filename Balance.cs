using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arts_Project
{
    public class Balance
    {
        private static int have;
        public static int Have => have;

        public Balance()
        {
            have = 50; //Starting balance
        }
        public static string StrToLabel() => "Баланс: " + have;
    }
}
