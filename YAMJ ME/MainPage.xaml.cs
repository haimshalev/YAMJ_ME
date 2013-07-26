using System.Diagnostics;
using System.Windows;
using System.Windows.Navigation;


namespace YAMJ_ME
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //Run the YAMJ.cmd file
        private void Run_YAMJ_Click(object sender, RoutedEventArgs e)
        {
            //Get the YAMJ path from configuration
            var data = YAMJData.GetConfiguration();

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
            var data = YAMJData.GetConfiguration();

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
            var settingsPage = new Settings();

            //Navigate to the settings page using the navigation service
            NavigationService navigationService = NavigationService;
            if (navigationService != null) navigationService.Navigate(settingsPage);
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
