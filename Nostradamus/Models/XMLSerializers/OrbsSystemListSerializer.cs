using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;

namespace Nostradamus.Models.XMLSerializers
{
    public class OrbsSystemListSerializer : XMLSerializerBase
    {
        public List<string> OrbsSystemsList { get; protected set; }
        public OrbsSystemListSerializer()
        {
           
            GetData();
        }
        public void AddSystemToCollectuion(string newsystem)
        {
            int index=OrbsSystemsList.FindIndex(x =>x== newsystem);
            if(index<0)
            {
                OrbsSystemsList.Add(newsystem);
            }
        }
        public override void GetData()
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<string>));

            using (Stream reader = new FileStream(_filename, FileMode.Open))
            {
                try
                {
                    OrbsSystemsList = (List<string>)ser.Deserialize(reader);
                }
                catch
                {

                }                
            }
        }

        public override void Save()
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<string>));
                using (Stream fs = new FileStream(_filename, FileMode.Create))
                {
                    using (XmlWriter writer = new XmlTextWriter(fs, Encoding.Unicode))
                    {
                        ser.Serialize(writer, OrbsSystemsList);
                        writer.Close();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"OrbsSystemListSerializer: Save => {e.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        //protected override void InitDefaults()
        //{
        //    OrbsSystemsList = new List<string>();
        //    OrbsSystemsList.Add(Constants.DefaultOrbsSystem);
        //    Save();
        //}

        protected override void UpdateFile()
        {
            _filename = $"{_filename}OrbsSystemsList.xml";
        }

        protected override void UpdateFile(object param)
        {
           
        }

        public override void SaveAsNew()
        {
            
        }
    }
}
