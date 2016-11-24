using System.Threading.Tasks;
using System.Windows;
using FileUploader.Services;
using Microsoft.Win32;

namespace FileUploader
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void upload_file_button_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() => PickFile());
        }

        private void PickFile()
        {
            var dialog = new OpenFileDialog
            {
                Multiselect = true,
                DefaultExt = "*.*",
                Filter =
                    "All files (*.*)|*.*|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif"
            };

            if (dialog.ShowDialog() == true)
            {
                if ((dialog.FileNames != null) && (dialog.FileNames.Length > 0))
                {
                    var message = "";
                    var files = dialog.FileNames;
                    FileSender.UploadFiles(files, out message);
                    {
                        //MessageBox.Show("Upload successful:\n" + message);
                        MessageBox.Show("Upload result:\n" + message);
                    }
                }
            }
        }
    }
}