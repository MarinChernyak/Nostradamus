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
    public class OrbsCollectionDataSerializer : XMLSerializerBaseParam
    {
        private string CurrentSystem { get; set; }
        //public OrbsCollectionData OrbsCollection { get; set; }
        public  OrbsCollectionDataSerializer(string system)
            :base(system)
        {
                      
        }
        public OrbsCollectionDataSerializer(string system, object data)
        : base(system,data)
        {

        }
        protected override void UpdateFile(object param)
        {
            CurrentSystem = param.ToString();
            _filename = $"{_filename}{param}.xml";
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
                        Data = (OrbsCollectionData)ser.Deserialize(reader);
                        ((OrbsCollectionData)Data).OrbsSystemName = CurrentSystem;

                    }
                    catch (Exception e)
                    {
                        _lm.SetLog($"OrbsCollectionDataSerializer :GetData => {e.Message}");
                    }
                }
            }
        }

        public override void Save()
        {
            try
            {
                if (Data != null)
                {
                    var xmlWriterSettings = new XmlWriterSettings() { Indent = true, Encoding = Encoding.Unicode, NewLineHandling = NewLineHandling.Entitize };
                    XmlSerializer ser = new XmlSerializer(typeof(OrbsCollectionData));
                    using(XmlWriter writer = XmlWriter.Create(_filename, xmlWriterSettings))
                    {
                        ser.Serialize(writer, Data);
                        writer.Close();
                    }
                }
            }
            catch (Exception e)
            {

                MessageBox.Show($"OrbsSystemSerializer :Save => {e.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        protected override void UpdateFile()
        {
        }
    }
}
