using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace RPG_Game.Classes
{
    public static class DataXML
    {
        public static string path = @"..\..\Data\";

        public static void Save(string file, List<Player> list)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;

            using (XmlWriter writer = XmlWriter.Create(path + file, settings))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Player>));
                xmlSerializer.Serialize(writer, list);
            }
        }
        //========================================================================
        public static List<Player> Load(string file)
        {
            List<Player> data = null;
            using (StreamReader reader = new StreamReader(path + file))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Player>));
                data = (List<Player>)xml.Deserialize(reader);
            }
            return data;
        }
    }
}
