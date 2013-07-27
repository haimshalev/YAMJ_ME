using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace YAMJ_ME
{
    static class Constants
    {
        public const string ConfigurationFile = "config.xml";
        public const string InvalidPathMessage = "Invalid Path";

    }

    [Serializable]
    public class YAMJData
    {
        public String YamjPath { get; set; }
        public String ConfigToolPath { get; set; }

        //Create a YAMJData object from the configuration
        public static YAMJData GetConfiguration()
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
                if (data != null) data.SetConfiguration();
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
                writer.Serialize(file, this);
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
