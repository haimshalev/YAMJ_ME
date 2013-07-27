using System.Windows;

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
            //Start the process , if cannot show error message 
            if (!YAMJMe.StartProcess(new YAMJMe().YamjPath))
            {
                Run_YAMJ.Content = Constants.InvalidPathMessage;
            }
        }

        //Run the YAMJ configuration tool
        private void Run_YAMJ__Config_Click(object sender, RoutedEventArgs e)
        {
            //Start the process , if cannot show error message 
            if (!YAMJMe.StartProcess(new YAMJMe().ConfigToolPath))
            {
                Run_Yamj_Config.Content = Constants.InvalidPathMessage;
            }
            
        }

        //Navigate to the settings page
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            //Navigate to a settings page using the navigation service
            if (NavigationService != null) NavigationService.Navigate(new Settings());
        }
    }
}
