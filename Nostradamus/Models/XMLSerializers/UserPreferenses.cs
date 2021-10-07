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
    public class UPrefXML 
    {
        public string OrbsSystemName { get; set; }
        public HousesData HousesData { get; set; }

        
    }
    public class UserPreferenses : XMLSerializerBase
    {
        public HousesData SelectedHousesSystem
        {
            get { return _uprefrences.HousesData; }
            set
            { 
                _uprefrences.HousesData = value;
                Save();
            }
        }
        protected override void UpdateFile()
        {
            _filename = _filename + "UserPreferences.xml";
        }
        public string OrbsSystem {
            get { return _uprefrences.OrbsSystemName; }
            set
            {
                _uprefrences.OrbsSystemName = value;
                Save();
            }
        }

        private UPrefXML _uprefrences { get; set; }

        
        public UserPreferenses()
        {
            
        }
        //protected override void InitDefaults()
        //{
        //    if (_uprefrences.HousesData == null || string.IsNullOrEmpty(_uprefrences.HousesData.SystemName))
        //    {
        //        _uprefrences.HousesData = new HousesData()
        //        {
        //            SystemID = Constants.DefaultHuseSystemId,
        //            SystemName = Constants.DefaultHuseSystem
        //        };
        //        _uprefrences.OrbsSystemName = Constants.DefaultOrbsSystem;
        //    }
        //}
        public  override void Save()
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(UPrefXML));
                using (Stream fs = new FileStream(_filename, FileMode.Create))
                {
                    using (XmlWriter writer = new XmlTextWriter(fs, Encoding.Unicode))
                    {
                        ser.Serialize(writer, _uprefrences);
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

        protected override void UpdateFile(object param)
        {
            
        }

        public override void SaveAsNew()
        {
            
        }
    }
}