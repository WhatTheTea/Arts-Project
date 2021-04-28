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
        App()
        {
            balance.BalanceChanged += Game_Over;
        }

        private void Game_Over(object sender, EventArgs e)
        {
            if (balance.IsBalanceZero)
            {
                MessageBox.Show("На жаль, ви не змогли розгадати загадки мудр", "Гру Закінчено", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                MainWindow.Close();
            }
        }

        private const int startingBalance = 50;
        private const string startingCurrency = "M";

        public const int game1_reward = 100;
        public const int game1_penalty = 2;

        public static Balance balance = new Balance(startingBalance, startingCurrency);
    }

}
