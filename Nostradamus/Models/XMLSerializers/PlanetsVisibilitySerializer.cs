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
    public class PlanetsVisibilitySerializer : XMLSerializerBase
    {
       
        public override void GetData()
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<GroupMapPlanetsVisibilityCollection>));
            if(!File.Exists(_filename))
            {
                File.Create(_filename);
            }

            using (Stream reader = new FileStream(_filename, FileMode.Open))
            {
                try
                {
                    Data = (List<GroupMapPlanetsVisibilityCollection>)ser.Deserialize(reader);
                    if (Data == null)
                        Data = new List<GroupMapPlanetsVisibilityCollection>();
                }
                catch (Exception e)
                {
                    //MessageBox.Show($"PlanetsVisibilitySerializer :GetData => {e.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                if(Data==null)
                {
                    Data = new List<GroupMapPlanetsVisibilityCollection>();
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
                    XmlSerializer ser = new XmlSerializer(typeof(List<GroupMapPlanetsVisibilityCollection>));
                    using (XmlWriter writer = XmlWriter.Create(_filename, xmlWriterSettings))
                    {
                        ser.Serialize(writer, Data);
                        writer.Close();
                    }
                }
            }
            catch (Exception e)
            {

                MessageBox.Show($"PlanetsVisibilitySerializer :Save => {e.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        protected override void UpdateFile()
        {
            _filename = $"{_filename}PlanetsVisibility.xml";
        }
    }
}
