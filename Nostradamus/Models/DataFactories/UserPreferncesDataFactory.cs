using System;
using System.Collections.Generic;
using System.Text;

namespace Nostradamus.Models.DataFactories
{
    public class UserPreferncesDataFactory : DataFactoryBase<UserPreferensesData>
    {
        protected override void CreateSerializer()
        {
            _serializer = new UserPreferensesSerializer();
        }

        protected override void CreateDefaultData()
        {
            Data = new UserPreferensesData();
            Data.OrbsSystemName = Constants.DefaultOrbsSystem;
            Data.HousesData = new HousesData()
            {
                SystemID = Constants.DefaultHuseSystemId,
                SystemName = Constants.DefaultHuseSystem
            };
        }
    }
}
