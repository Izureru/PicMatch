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
using AForge;
using AForge.Imaging;
using System.Drawing;


namespace PicMatch_pimped
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.CheckFileExists = true;
            dlg.Filter = "Bitmap Files (*.bmp)|*.bmp";
            dlg.Multiselect = false;
            if (dlg.ShowDialog() != true)
            {
                return;
            }
            txtPic1.Text = dlg.FileName;
            ImageSource imageSource = new BitmapImage(new Uri(dlg.FileName));
            Pic1.Source = imageSource;
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.CheckFileExists = true;
                dlg.Filter = "Bitmap Files (*.bmp)|*.bmp";
                dlg.Multiselect = false;
                if (dlg.ShowDialog() != true)
                {
                    return;
                }
                txtPic2.Text = dlg.FileName;
                ImageSource imageSource = new BitmapImage(new Uri(dlg.FileName));
                Pic2.Source = imageSource;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var image1 = new Bitmap(txtPic1.Text, false);
            var image2 = new Bitmap(txtPic2.Text, false);
            ExhaustiveTemplateMatching tm = new ExhaustiveTemplateMatching(0);
            TemplateMatch[] matchings = tm.ProcessImage(image2, image1);
            var MatchScore = matchings[0].Similarity;
            MatchScore = MatchScore * 100;
            string result = "The images match " + MatchScore + "%";
            txtScore.Text = result;
           
        }
    }
}
