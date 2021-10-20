using Nostradamus.Models.XMLSerializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nostradamus.Models.DataFactories
{
    public class OrbsSystemListFactory : DataFactoryBase<List<string>>
    {
        protected override void ConsiderDefaultData()
        {
            if (Data == null || Data.Count == 0)
            {
                Data = new List<string>();
                Data.Add(Constants.DefaultHuseSystem);
            }
        }
        protected override void CreateSerializer()
        {
            _serializer = new OrbsSystemListSerializer();
        }
        public void Update(List<string> data)
        {
            Data = data;
            SetData();
        }
   }
}
