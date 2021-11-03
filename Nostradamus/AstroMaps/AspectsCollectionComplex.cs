using Nostradamus.Models.DataFactories;
using Nostradamus.Models.DataProcessors;
using NostraPlanetarium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static NostraPlanetarium.NPTypes;

namespace Nostradamus.AstroMaps
{
    public class AspectsCollectionComplex :AspectsCollection
    {

        public AspectsCollectionComplex(List<SpaceObjectData> lstStatic, List<SpaceObjectData> lstDynamic, tAstroMapType type)
            :base(lstStatic)
        {
            AstroMapType = type;
            UserPreferncesDataFactory _upfact = new UserPreferncesDataFactory();
            _ocdp = new OrbsCollectionDataProcessor(_upfact.Data.OrbsSystemName);
            CreateAspectsCollection(lstStatic, lstDynamic);
        }
        public void CreateAspectsCollection(List<SpaceObjectData> lstSO1, List<SpaceObjectData> lstSO2)
        {
            InitRedBuletsStatic(lstSO1);
            _aspects = new List<Aspect>();
            foreach(SpaceObjectData sod1 in lstSO1)
            {
                SpaceObject so1 = sod1._so;
                foreach (SpaceObjectData sod2 in lstSO2)
                {
                    SpaceObject so2 = sod2._so;
                    double dLambda = Math.Abs(so1.Lambda - so2.Lambda);
                    if (dLambda > 180)
                    {
                        dLambda = 360 - dLambda;
                    }

                    AspectType at = GetAspectType(dLambda, so1.PlanetType, so2.PlanetType);
                    if (at == AspectType.AT_CONJUNCTION)
                    {
                        sod1.IsRed = sod2.IsRed = true;
                    }

                    if (at != AspectType.AT_NONE)
                    {
                        _aspects.Add(new Aspect()
                        {
                            Angle = Math.Abs(dLambda),
                            PlanetType1 = so1.PlanetType,
                            PlanetType2 = so2.PlanetType,
                            _aspect_data = (AspectData)_AspectsDataCollection.Where(x => x.Angle == ((decimal)at)).FirstOrDefault()
                        });
                    }

                }
            }
        }
    }
}
