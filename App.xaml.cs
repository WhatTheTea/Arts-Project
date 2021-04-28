using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Arts_Project
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const int startingBalance = 50;
        private const string startingCurrency = "M";

        public const int game1_reward = 100;

        public static Balance balance = new Balance(startingBalance, startingCurrency);
    }

}
