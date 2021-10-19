using Nostradamus.Models.XMLSerializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nostradamus.Models.DataFactories
{
    public class OrbsSystemListFactory : DataFactoryBase<List<string>>
    {
        protected override void CreateDefaultData()
        {
            Data = new List<string>();
            Data.Add(Constants.DefaultHuseSystem);
        }
        protected override void CreateSerializer()
        {
            _serializer = new OrbsSystemListSerializer();
        }
   }
}
