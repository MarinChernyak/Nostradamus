using Nostradamus.AstroMaps;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;

namespace Nostradamus.Models.XMLSerializers
{
    public class AspectsMapSerializer : XMLSerializerBase
    {
        public override void GetData()
        {
            XmlSerializer ser = new XmlSerializer(typeof(OrbsCollectionData));
            if (File.Exists(_filename))
            {
                using (Stream reader = new FileStream(_filename, FileMode.Open))
                {
                    try
                    {
                        Data = (List<AspectData>)ser.Deserialize(reader);
                    }
                    catch (Exception e)
                    {
                        //MessageBox.Show($"AspectsMapSerializer :GetData => {e.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        public override void Save()
        {
            try
            {
                var xmlWriterSettings = new XmlWriterSettings() { Indent = true, Encoding = Encoding.Unicode, NewLineHandling = NewLineHandling.Entitize };
                XmlSerializer ser = new XmlSerializer(typeof(List<string>));
                using (XmlWriter writer = XmlWriter.Create(_filename, xmlWriterSettings))
                {
                    ser.Serialize(writer, Data);
                    writer.Close();
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show($"AspectsMapSerializer: Save => {e.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        protected override void UpdateFile()
        {
            _filename = $"{_filename}OrbsSystemsList.xml";
        }

        protected override void UpdateFile(object param)
        {

        }
    }
}
