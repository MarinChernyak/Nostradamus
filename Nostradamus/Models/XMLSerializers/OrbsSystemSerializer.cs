using Nostradamus.AstroMaps;
using Nostradamus.Models.XMLSerializers;
using NostraPlanetarium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;
using static NostraPlanetarium.NPTypes;

namespace Nostradamus.Models
{
    public class OrbsSystemSerializer : XMLSerializerBase
    {
        private string CurrentSystem { get;  }
        public OrbsCollectionData OrbsCollection { get; set; }
        public  OrbsSystemSerializer(string system)
            :base(system)
        {
             CurrentSystem = system;            
        }
        protected override void UpdateFile(object param)
        {
            _filename = $"{_filename}{param}.xml";
        }
        protected override void UpdateFile()
        {
           
        }
        public override void GetData()
        {

            XmlSerializer ser = new XmlSerializer(typeof(OrbsCollectionData));
            if (File.Exists(_filename))
            {
                using (Stream reader = new FileStream(_filename, FileMode.Open))
                {
                    try
                    {
                        OrbsCollection = (OrbsCollectionData)ser.Deserialize(reader);

                    }
                    catch (Exception e)
                    {
                        MessageBox.Show($"OrbsSystemSerializer :GetData => {e.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        public override void Save()
        {
            try
            {
                if (OrbsCollection != null)
                {
                    var xmlWriterSettings = new XmlWriterSettings() { Indent = true, Encoding = Encoding.Unicode, NewLineHandling = NewLineHandling.Entitize };
                    XmlSerializer ser = new XmlSerializer(typeof(OrbsCollectionData));
                    using(XmlWriter writer = XmlWriter.Create(_filename, xmlWriterSettings))
                    {
                        ser.Serialize(writer, OrbsCollection);
                        writer.Close();
                    }
                    //XmlSerializer ser = new XmlSerializer(typeof(OrbsCollectionData));
                    //using (Stream fs = new FileStream(_filename, FileMode.Create))
                    //{
                    //    using (XmlWriter writer = new XmlTextWriter(fs, Encoding.Unicode))
                    //    {
                    //        ser.Serialize(writer, OrbsCollection);
                    //        writer.Close();
                    //    }
                    //}
                }
            }
            catch (Exception e)
            {

                MessageBox.Show($"OrbsSystemSerializer :Save => {e.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        public override void SaveAsNew()
        {
            if (!File.Exists(_filename))
            {
                using (FileStream fs = File.Create(_filename))
                {
                    for (byte i = 0; i < 100; i++)
                    {
                        fs.WriteByte(i);
                    }
                }
            }

            
        }

        

    }
}
