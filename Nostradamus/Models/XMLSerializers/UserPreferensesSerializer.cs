using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Windows;

namespace Nostradamus.Models
{
    /*
 Order of the houses systems:
0	'P'	Placidus
1	'K'	Koch
2	'O'	Porphyrius
3	'R'	Regiomontanus
4	'C'	Campanus
5	'A' or 'E'	Equal(cusp 1 is Ascendant)
6	'V'	Vehlow equal(Asc. in middle of house 1)
7	'X'	axial rotation system
8	'H'	azimuthal or horizontal system
9	'T'	Polich/Page("topocentric" system)
10	'B'	Alcabitus
11	'G'	Gauquelin sectors
 */
    public class HousesData
    {
        public string SystemName { get; set; }
        public string SystemID { get; set; }
        public string SystemRef { get; set; }
    }
    public class UserPreferensesData 
    {
        public string OrbsSystemName { get; set; }
        public HousesData HousesData { get; set; }

        
    }
    public class UserPreferensesSerializer : XMLSerializerBase
    {
        public override object Data { get; set; }
        
        protected override void UpdateFile()
        {
            _filename = _filename + "UserPreferences.xml";
        }  
         
        public UserPreferensesSerializer()
        {

        }
        public UserPreferensesSerializer(object data)
            :base(data)
        {

        }
        public  override void Save()
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(UserPreferensesData));
                using (Stream fs = new FileStream(_filename, FileMode.Create))
                {
                    using (XmlWriter writer = new XmlTextWriter(fs, Encoding.Unicode))
                    {
                        ser.Serialize(writer, Data);
                        writer.Close();
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show($"UserPreferenses :Save => {e.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public override void GetData()
        {
            XmlSerializer ser = new XmlSerializer(typeof(UserPreferensesData));

            using (Stream reader = new FileStream(_filename, FileMode.Open))
            {
                try
                {
                    Data = (UserPreferensesData)ser.Deserialize(reader);
                }
                catch
                {

                }
            }
        }
    }
}