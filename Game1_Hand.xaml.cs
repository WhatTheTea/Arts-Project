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
	/// Логика взаимодействия для Page1.xaml
	/// </summary>
	public partial class Game1_Hand : Page
	{
		public static event EventHandler<PageChangingEventArgs> PageChanging;
		private List<Image> elements, fingers;
		private Dictionary<Image, ImageSource> elements_source_og;
		private Image dragdrop_img;

		private static void Game1_Reward() => App.balance.Add(App.game1_reward);
		private static void Game1_Penalty() => App.balance.Sub(App.game1_penalty);

		public Game1_Hand()
		{
			InitializeComponent();
			elements = new List<Image>
			{
				soil_img,
				wind_img,
				fire_img,
				water_img,
				ingot_img
			};
			fingers = new List<Image>
			{
				finger_first,
				finger_second,
				finger_third,
				finger_fourth,
				finger_fifth
			};
			elements_source_og = new Dictionary<Image, ImageSource>
			{
				{ soil_img, soil_img.Source },
				{ wind_img, wind_img.Source },
				{ fire_img, fire_img.Source },
				{ water_img, water_img.Source },
				{ ingot_img, ingot_img.Source }
			};
			Update();
			App.balance.BalanceChanged += Update;
			void Update(object sender = null, EventArgs e = null)
			{
				Label_Balance.Content = App.balance.StrToLabel();
			}
		}
		private void finger_MouseDown(object sender, MouseButtonEventArgs e)
		{
			dragdrop_img = (Image)sender;
			DragDrop.DoDragDrop(dragdrop_img, dragdrop_img.Source, DragDropEffects.Move);
		}

		private void Image_Drop(object sender, DragEventArgs e)
		{
			Image element = (from img in elements
							 where img.Source == elements_source_og[sender as Image]
							 select img).SingleOrDefault();
			if (element != default(Image))
			{
				element.Source = dragdrop_img.Source;
				dragdrop_img.Opacity = 0.3;
				dragdrop_img.IsEnabled = false;
				element.Cursor = Cursors.Hand;
			}
		}

		private void Image_DragOver(object sender, DragEventArgs e)
		{
			e.Effects = DragDropEffects.Move;
		}

        private void CheckAnswers_Click(object sender, RoutedEventArgs e)
        {
			List<bool> Answers = new List<bool>{ 
				finger_first.Source == water_img.Source,
				finger_second.Source == ingot_img.Source,
				finger_third.Source == soil_img.Source,
				finger_fourth.Source == fire_img.Source,
				finger_fifth.Source == wind_img.Source };
			var CorrectAnswers = from answer in Answers
								 where answer is true
								 select answer;
			bool IsAnswersCorrect = CorrectAnswers.Count() == Answers.Count;

            if (IsAnswersCorrect)
            {
				Game1_Reward();
                MessageBox.Show($"Ви успішно завершили першу гру\nВаш баланс поповнено на {App.game1_reward} {App.balance.Currency}", "Вітання", MessageBoxButton.OK, MessageBoxImage.Information);
				PageChanging.Invoke(new Game1_Hand(), new PageChangingEventArgs(new StartPage()));
            } else
            {
				Game1_Penalty();
				if(!App.balance.IsBalanceZero) MessageBox.Show("На жаль, ви не вгадали за що відповідають пальці\n" +
					$"Правильних відповідей: {CorrectAnswers.Count()}\n" +
					$"З вашого балансу знято {App.game1_penalty} {App.balance.Currency}","Подумайте ще", MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void element_MouseDown(object sender, MouseButtonEventArgs e)
		{
			Image finger = (from img in this.fingers
							where img.Source == (sender as Image).Source
							select img).SingleOrDefault();

			if (finger != default(Image))
			{	
				finger.Opacity = 1;
				finger.IsEnabled = true;
				(sender as Image).Cursor = Cursors.Arrow;

				(sender as Image).Source = elements_source_og[sender as Image];
			}
		}
	}
}
