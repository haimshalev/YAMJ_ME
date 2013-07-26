using Microsoft.Win32;
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

namespace YAMJ_ME
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        public Settings()
        {
            InitializeComponent();
        }

        //Letting the user the option to select a YAMJ cmd file
        private void Set_YAMJ_cmd_File_Click(object sender, RoutedEventArgs e)
        {
            //Create the file dialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "cmd Files|*.cmd";
            openFileDialog.Title = "Select the YAMJ cmd file";

            //open the file dialog , if the user selected the file
            if (openFileDialog.ShowDialog() == true)
            {
                //Read the configuration 
                YAMJData data = YAMJData.GetConfiguration();

                //Update the data object
                data.YamjPath = openFileDialog.FileName;

                ///Update the configuration file
                data.SetConfiguration();
 
            }
        }

        private void Set_Config_tool_file_Click(object sender, RoutedEventArgs e)
        {
            //Create the file dialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "exe Files|*.exe";
            openFileDialog.Title = "Select the YAMJ config tool file";

            //open the file dialog , if the user selected the file
            if (openFileDialog.ShowDialog() == true)
            {
                //Read the configuration 
                YAMJData data = YAMJData.GetConfiguration();

                //Update the data object
                data.ConfigToolPath = openFileDialog.FileName;

                ///Update the configuration file
                data.SetConfiguration();

            }
        }
    }
}
