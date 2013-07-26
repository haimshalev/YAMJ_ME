using System;
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

    }
}
