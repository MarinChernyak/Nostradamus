using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Nostradamus.Models.XMLSerializers
{
    public class XDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable
    {
        public XmlSchema GetSchema()
        {
            return null; ;
        }

        public void ReadXml(XmlReader reader)
        {
            if (reader.IsEmptyElement) { return; }

            reader.Read();
            while (reader.NodeType != XmlNodeType.EndElement)
            {
                object key = reader.GetAttribute("Title");
                object value = reader.GetAttribute("Value");
                this.Add((TKey)key, (TValue)value);
                reader.Read();
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            foreach (var key in this.Keys)
            {
                string valtype = this[key].GetType().Name;

                writer.WriteStartElement("MapType");
                writer.WriteAttributeString("Title", key.ToString());
                if (valtype != "XDictonary")
                {
                    writer.WriteAttributeString("Value", this[key].ToString());
                    writer.WriteEndElement();
                }
                //else
                //    WriteXml(writer)
            }
        }
    }
}
