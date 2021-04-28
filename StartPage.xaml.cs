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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Arts_Project
{
    /// <summary>
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public static event EventHandler<PageChangingEventArgs> PageChanging;
        public StartPage()
        {
            InitializeComponent();
            Label_Balance.Content = MainWindow.balance.StrToLabel();
        }

        private void game_start_button_Click(object sender, RoutedEventArgs e)
        {
            PageChanging.Invoke(new StartPage(), new PageChangingEventArgs(new Game1_Hand()));
        }
    }
}
