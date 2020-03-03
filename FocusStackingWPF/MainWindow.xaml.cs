using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Emgu.CV;
using Emgu.CV.Structure;

namespace FocusStackingWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Images (*.BMP;*.JPG;*.GIF;*.TIFF)|*.BMP;*.JPG;*.GIF;*.TIFF|" +
            "All files (*.*)|*.*";
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == true)
            {
                this.listBox.ItemsSource = "";
                listBox.ItemsSource = openFileDialog.FileNames;
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fName = "";
            try
            {     
                fName = e.AddedItems[0].ToString();
                Uri fileUri = new Uri(fName);
                this.image_Start.Source = new BitmapImage(fileUri);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot display the image: " + fName.Substring(fName.LastIndexOf('\\'))
                    + ". You may not have permission to read the file, or " +
                    "it may be corrupt.\n\nReported error: " + ex.Message);
            }
        }

        private void Button_Start_Click(object sender, RoutedEventArgs e)
        {
            //InputArray[] arr = new InputArray();
            //IInputArray src = arr;
            Mat img1 = new Mat(@"C:\DI_PLOT\Bitmaps\img_C.TIF");
            Image<Bgr, Byte> image1 = new Image<Bgr, byte>(@"C:\imgoflder\Bitmaps\img_C.TIF");
            Image<Bgr, Byte> image2 = new Image<Bgr, byte>(@"C:\imgoflder\Bitmaps\img_M.TIF");
            Image<Bgr, Byte> image3 = new Image<Bgr, byte>(@"C:\imgoflder\Bitmaps\img_Y.TIF");
            Image<Bgr, Byte> image4 = new Image<Bgr, byte>(@"C:\imgoflder\Bitmaps\img_K.TIF");
            Image<Bgr, Byte> image5 = image1 + image2 + image3 + image4;
            image5.Save(@"something.TIF");

        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
