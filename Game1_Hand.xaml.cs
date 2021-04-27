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
        private List<Image> elements;
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
        }

        private void finger_MouseDown(object sender, MouseButtonEventArgs e)
        {
            dragdrop_img = (Image)sender;
            DragDrop.DoDragDrop(dragdrop_img, dragdrop_img.Source, DragDropEffects.Move);
        }

        private void Image_Drop(object sender, DragEventArgs e)
        {
            Image element = (from img in elements
                            where img == sender
                            select img).First();
            element.Source = dragdrop_img.Source;
        }

        private void Image_DragEnter(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Move;
        }
    }
}
