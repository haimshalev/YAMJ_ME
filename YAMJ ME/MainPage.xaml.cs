using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //Run the YAMJ.cmd file
        private void Run_YAMJ_Click(object sender, RoutedEventArgs e)
        {
            //Get the YAMJ path from configuration
            YAMJData data = YAMJData.GetConfiguration();

            //Start the process , if cannot show error message 
            if (!StartProcess(data.YamjPath))
            {
                Run_YAMJ.Content = Constants.InvalidPathMessage;
            }
        }

        //Run the YAMJ configuration tool
        private void Run_YAMJ__Config_Click(object sender, RoutedEventArgs e)
        {
            //Get the YAMJ path from configuration
            YAMJData data = YAMJData.GetConfiguration();

            //Start the process , if cannot show error message 
            if (!StartProcess(data.ConfigToolPath))
            {
                Run_Yamj_Config.Content = Constants.InvalidPathMessage;
            }
            
        }

        //Navigate to the settings page
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            //Create a new settings page
            Settings settingsPage = new Settings();

            //Navigate to the settings page using the navigation service
            this.NavigationService.Navigate(settingsPage);
        }

        //Try to start a process
        private bool StartProcess(string path)
        {
            //if the config tool path initialized
            if (path != null)
            {
                //Run the Yamj cmd process which creates the video library in the configured location
                Process.Start(path);
                return true;
            }

            //invalid path 
            return false;
        }
    }
}
