using Nostradamus.Models.XMLSerializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nostradamus.Models.DataFactories
{
    public class MapNotesFactory : DataFactoryBase<MapNotes>
    {
        protected override void ConsiderDefaultData()
        {
            if (Data == null || Data.StaticMapNotes==null || Data.DynamicMapNotes==null)
            {
                Data = new MapNotes()
                {
                    StaticMapNotes = new StaticMapNotes()
                    {
                        Aspects = false,
                        Coordinates = true,
                        FirstLastName = true,
                        Houses = false,
                        DOB = true
                    },
                    DynamicMapNotes = new MapNotesBase()
                    {
                        Aspects = true,
                        Coordinates = true
                    }
                };                
            }
        }
        protected override void CreateSerializer()
        {
            _serializer = new MapsNotesSerializer();
        }
        public void Update(MapNotes data)
        {
            Data = data;
            SetData();
        }
    }
}
