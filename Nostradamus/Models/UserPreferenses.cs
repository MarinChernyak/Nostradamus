using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace Nostradamus.Models
{
    public class UPrefXML
    {
        public String HousesSystem { get; set; }
    }
    public class UserPreferenses
    {

        private UPrefXML _uprefrences { get; set; }

        private const string _filename = "UserPreferences.xml";
        public UserPreferenses()
        {
            _uprefrences = new UPrefXML();
            GetPrefernces();
            _uprefrences.HousesSystem = "K";
        }
        public void SavePreferenses()
        {
            XmlSerializer ser = new XmlSerializer(typeof(UPrefXML));
            Stream fs = new FileStream(_filename, FileMode.Create);
            XmlWriter writer = new XmlTextWriter(fs, Encoding.Unicode);
            // Serialize using the XmlTextWriter.
            ser.Serialize(writer, _uprefrences);
            writer.Close();
        }
        public void GetPrefernces()
        {
            XmlSerializer ser = new XmlSerializer(typeof(UPrefXML));

            using (Stream reader = new FileStream(_filename, FileMode.Open))
            {
                try
                {
                    _uprefrences = (UPrefXML)ser.Deserialize(reader);
                }
                catch
                {

                }
            }
        }
    }
}