using System;
using System.Collections.Generic;
using System.Text;

namespace Nostradamus.Models.DataFactories
{
    public class UserPreferncesDataFactory : DataFactoryBase<UserPreferensesData>
    {
        public UserPreferncesDataFactory()
        {

        }
        public UserPreferncesDataFactory(UserPreferensesData data)
            :base(data)
        {

        }
        protected override void CreateSerializer()
        {
            _serializer = new UserPreferensesSerializer();
        }

        protected override void ConsiderDefaultData()
        {
            if (Data == null)
            {
                Data = new UserPreferensesData();
            }
            if(string.IsNullOrEmpty(Data.OrbsSystemName))
            {
                Data.OrbsSystemName = Constants.DefaultOrbsSystem;
            }
            if(Data.HousesData==null)
            {
                Data.HousesData = new HousesData()
                {
                    SystemID = Constants.DefaultHuseSystemId,
                    SystemName = Constants.DefaultHuseSystem
                };
            }
        }        
    }
}
