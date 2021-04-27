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
			}
		}

		private void Image_DragOver(object sender, DragEventArgs e)
		{
			e.Effects = DragDropEffects.Move;
		}

        private void CheckAnswers_Click(object sender, RoutedEventArgs e)
        {
			bool IsFirstCorrect, IsSecondCorrect, IsThirdCorrect, IsFourthCorrect, IsFifthCorrect;
			IsFirstCorrect = finger_first.Source == water_img.Source;
			IsSecondCorrect = finger_second.Source == ingot_img.Source;
			IsThirdCorrect = finger_third.Source == soil_img.Source;
			IsFourthCorrect = finger_fourth.Source == fire_img.Source;
			IsFifthCorrect = finger_fifth.Source == wind_img.Source;
			bool IsAnswersCorrect = IsFirstCorrect && IsSecondCorrect && IsThirdCorrect && IsFourthCorrect && IsFifthCorrect;

            if (IsAnswersCorrect)
            {
                MessageBox.Show($"Ви успішно завершили першу гру\nВаш баланс поповнено на NUMBER мудр", "Вітання", MessageBoxButton.OK, MessageBoxImage.Information);
				//
				////Пополнение баланса
				//
				PageChanging.Invoke(new Game1_Hand(), new PageChangingEventArgs(new StartPage()));
            } else
            {
				MessageBox.Show("На жаль, ви не вгадали за що відповідають пальці\n" +
					$"Правильних відповідей: NUMBER\n" +
					$"З вашого балансу знято NUMBER мудри","Подумайте ще", MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void element_MouseDown(object sender, MouseButtonEventArgs e)
		{
			Image finger = (from img in fingers
							where img.Source == ((Image)sender).Source
							select img).SingleOrDefault<Image>();

			if (finger != default(Image))
			{	
				finger.Opacity = 1;
				finger.IsEnabled = true;

				((Image)sender).Source = elements_source_og[(Image)sender];
			}
		}
	}
}
