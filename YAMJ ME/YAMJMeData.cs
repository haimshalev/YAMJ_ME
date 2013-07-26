using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace YAMJ_ME
{
    static class Constants
    {
        public const string configurationFile = "config.xml";
        public const string InvalidPathMessage = "Invalid Path";

    }

    [Serializable()]
    public class YAMJData
    {
        public String YamjPath { get; set; }
        public String ConfigToolPath { get; set; }

        public static YAMJData GetConfiguration()
        {
            //Create a new data object
            YAMJData data = new YAMJData();
            XmlSerializer reader = new XmlSerializer(typeof(YAMJData));

            //Read the configuration
            try
            {
                using (FileStream input = File.OpenRead(Constants.configurationFile))
                {
                    data = reader.Deserialize(input) as YAMJData;
                }
            }
            catch (Exception e)
            {
                //The file is in valid or damaged, lets create one from scretch
                data.SetConfiguration();
            }

            return data;
        }

        public bool SetConfiguration()
        {
            // Write to XML
            XmlSerializer writer = new XmlSerializer(typeof(YAMJData));
            using (FileStream file = File.OpenWrite(Constants.configurationFile))
            {
                writer.Serialize(file, this);
            }

            return true;
        }

    }
}
