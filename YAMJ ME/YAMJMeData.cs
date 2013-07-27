using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace YAMJ_ME
{
    //All the definitions in this program
    static class Constants
    {
        public const string ConfigurationFile = "config.xml";
        public const string InvalidPathMessage = "Invalid Path";

    }

    //The class which holds all the logic and data of the program (A god class for logic :( )
    public class YAMJMe
    {
        //An inner class which holds all the data from configuration
        [Serializable]
        public class YAMJData
        {
            public String YamjPath { get; set; }
            public String ConfigToolPath { get; set; }
        }

        //The instance of the class which holds the current configuration
        private readonly YAMJData _config;

        //Getter and setter for the YAMJPath property of the _config object
        public String YamjPath
        {
            get { return _config.YamjPath; }
            set { _config.YamjPath = value; }
        }

        //Getter and setter for the ConfigToolPath property of the _config object
        public String ConfigToolPath
        {
            get { return _config.ConfigToolPath; }
            set { _config.ConfigToolPath = value; }
        }

        //Ctor 
        public YAMJMe()
        {
            //Initialize the configuration object to the values from the configuration file
            _config = GetConfiguration();
        }

        //Create a YAMJData object from the configuration
        private YAMJData GetConfiguration()
        {
            //Create a new data object
            var data = new YAMJData();
            var reader = new XmlSerializer(typeof(YAMJData));

            //Read the configuration
            try
            {
                using (FileStream input = File.OpenRead(Constants.ConfigurationFile))
                {
                    data = reader.Deserialize(input) as YAMJData;
                }
            }
            catch (Exception)
            {
                //The file is in valid or damaged, lets create one from scretch
                SetConfiguration();
            }

            return data;
        }

        //Serialize the data to the configuration file
        public bool SetConfiguration()
        {
            // Write to XML
            var writer = new XmlSerializer(typeof(YAMJData));
            using (FileStream file = File.OpenWrite(Constants.ConfigurationFile))
            {
                //Serialize the configuration object
                writer.Serialize(file, _config);
            }

            return true;
        }

        //Try to start a process
        public static bool StartProcess(string path)
        {
            //if the config tool path initialized
            try
            {
                //Run the Yamj cmd process which creates the video library in the configured location
                Process.Start(path);
            }
            catch (Exception)
            {
                //invalid path 
                return false;
            }

            //Process started succefully
            return true;

        }
    }
}
