using Nostradamus.Models.DataFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nostradamus.Models.DataProcessors
{
    public class OrbsSystemListProcessor
    {
        public List<string> OrbsSystemList { get; set; }
        OrbsSystemListFactory _fact;
        public OrbsSystemListProcessor()
        {
            _fact = new OrbsSystemListFactory();
            GetData();
        }
        protected void GetData()
        {           
            OrbsSystemList = _fact.Data;
        }
        public void AddNewSystem(string system)
        {
            if(!OrbsSystemList.Contains(system))
            {
                OrbsSystemList.Add(system);
                _fact.SetData(OrbsSystemList);
            }
        }
        public void RemoveSystem(string system)
        {
            if (!OrbsSystemList.Contains(system))
            {
                OrbsSystemList.Remove(system);
                _fact.SetData(OrbsSystemList);
            }
        }
    }
}
