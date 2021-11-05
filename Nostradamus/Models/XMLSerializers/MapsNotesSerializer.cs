using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;

namespace Nostradamus.Models.XMLSerializers
{
    public class MapNotesBase
    {
        public bool Coordinates { get; set; }
        public bool Aspects { get; set; }
    }
    public class StaticMapNotes : MapNotesBase
    {
        public bool FirstLastName { get; set; }
        public bool Houses { get; set; }
        public bool DOB { get; set; }
    }
    public class MapNotes 
    {
        public StaticMapNotes StaticMapNotes { get; set; }
        public MapNotesBase DynamicMapNotes { get; set; }
    }


    public class MapsNotesSerializer : XMLSerializerBase
    {
        public override void GetData()
        {
            XmlSerializer ser = new XmlSerializer(typeof(MapNotes));
            if (!File.Exists(_filename))
            {
                File.Create(_filename);
            }

            using (Stream reader = new FileStream(_filename, FileMode.Open))
            {
                try
                {
                    Data = (MapNotes)ser.Deserialize(reader);
                    if (Data == null)
                        Data = new MapNotes();
                }
                catch (Exception e)
                {
                    _lm.SetLog($"MapsNotesSerializer :GetData => {e.Message}");
                }

                if (Data == null)
                {
                    Data = new MapNotes();
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
                    XmlSerializer ser = new XmlSerializer(typeof(MapNotes));
                    using (XmlWriter writer = XmlWriter.Create(_filename, xmlWriterSettings))
                    {
                        ser.Serialize(writer, Data);
                        writer.Close();
                    }
                }
            }
            catch (Exception e)
            {
                _lm.SetLog($"MapsNotesSerializer :Save => {e.Message}");
            }
        } 
        protected override void UpdateFile()
        {
            _filename = _filename + "MapNotes.xml";
        }
    }
}
