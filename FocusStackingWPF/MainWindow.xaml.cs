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
            openFileDialog.Filter = "Images (*.BMP;*.JPG;*.GIF;*.TIFF)|*.BMP;*.JPG;*.GIF|*.TIFF|" +
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
            try
            {
                PictureBox pb = new PictureBox();
                Image loadedImage = Image.FromFile(file);
                pb.Height = loadedImage.Height;
                pb.Width = loadedImage.Width;
                pb.Image = loadedImage;
                flowLayoutPanel1.Controls.Add(pb);
            }
            catch (Exception ex)
            {
                // Could not load the image - probably related to Windows file system permissions.
                MessageBox.Show("Cannot display the image: " + file.Substring(file.LastIndexOf('\\'))
                    + ". You may not have permission to read the file, or " +
                    "it may be corrupt.\n\nReported error: " + ex.Message);
            }
        }
    }
}
