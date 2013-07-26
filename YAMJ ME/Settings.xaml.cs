using Microsoft.Win32;
using System.Windows;

namespace YAMJ_ME
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings
    {
        public Settings()
        {
            InitializeComponent();
        }

        //Letting the user the option to select a YAMJ cmd file
        private void Set_YAMJ_cmd_File_Click(object sender, RoutedEventArgs e)
        {
            //Create the file dialog
            var openFileDialog = new OpenFileDialog {Filter = "cmd Files|*.cmd", Title = "Select the YAMJ cmd file"};

            //open the file dialog , if the user not selected a file exit
            if (openFileDialog.ShowDialog() != true) return;
            
            //Read the configuration 
            var data = YAMJData.GetConfiguration();

            //Update the data object
            data.YamjPath = openFileDialog.FileName;

            //Update the configuration file
            data.SetConfiguration();
        }

        private void Set_Config_tool_file_Click(object sender, RoutedEventArgs e)
        {
            //Create the file dialog
            var openFileDialog = new OpenFileDialog {Filter = "exe Files|*.exe", Title = "Select the YAMJ config tool file"};

            //open the file dialog , if the user not selected a file exit
            if (openFileDialog.ShowDialog() != true) return;
            //Read the configuration 
            var data = YAMJData.GetConfiguration();

            //Update the data object
            data.ConfigToolPath = openFileDialog.FileName;

            //Update the configuration file
            data.SetConfiguration();
        }
    }
}
