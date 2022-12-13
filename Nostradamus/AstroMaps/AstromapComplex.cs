using Nostradamus.Models;
using NostraPlanetarium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Nostradamus.AstroMaps
{
    public class AstromapComplex : AstroMapBase
    {
        protected AstroMapStaticComplex _map_static;
        protected AstroMapDynamic _map_dynamic;

        public AstroMapStaticComplex GetStaticMap() { return _map_static; }

        public AstromapComplex()
        {

        }
        public AstromapComplex(AstroMapStaticComplex mapstatic, MDynamicMapUpdateInfo info)
        {
           
            ID = mapstatic.ID;
            _map_static = mapstatic;
            switch(info.MapType)
            {
                case NPTypes.tAstroMapType.TRANSIT:
                    _map_dynamic = new AstroMapTransit(info);
                    break;
                case NPTypes.tAstroMapType.PROGRESSIVE:
                    _map_dynamic = new AstroMapProgressive(info, mapstatic.JD);
                    break;
                case NPTypes.tAstroMapType.SYNASTRY:
                    _map_dynamic = new AstroMapSynstry(info);
                    break;
            }; 
            _map_dynamic._houses = _map_static._houses;
            CreateMap();
        }
        public override void DrawMap(Graphics g)
        {
            _map_static.DrawHouses(g);
            _map_dynamic.DrawMap(g);
            _map_static.DrawMap(g);
            _map_dynamic.DrawDynamicBullets(g);
            DrawAspects(g);
        }

        protected override void Createaspects()
        {
            _aspects = new AspectsCollectionComplex( _map_static._space_objects, _map_dynamic._space_objects, _map_dynamic.DynamicType);

        }
        protected void DrawAspects(Graphics g)
        {
            var geometry = _map_dynamic.GetGeometry();

            if (_aspects != null)
            {
                foreach (Aspect at in _aspects.Aspects)
                {
                    NPTypes.tPlanetType p1 = at.PlanetType1;
                    NPTypes.tPlanetType p2 = at.PlanetType2;

                    SpaceObjectData sod1 = _map_static._space_objects.Where(x => x._so.PlanetType == p1).FirstOrDefault();
                    SpaceObjectData sod2 = _map_dynamic._space_objects.Where(x => x._so.PlanetType == p2).FirstOrDefault();

                    if (sod1 != null && sod2 != null)
                    {

                        PointF bulet1 = new PointF(sod1._bullet.X + geometry.BULET_SHIFT, sod1._bullet.Y + geometry.BULET_SHIFT);
                        PointF bulet2 = new PointF(sod2._bullet.X + geometry.BULET_SHIFT, sod2._bullet.Y + geometry.BULET_SHIFT);

                        g.DrawLine(at._aspect_data.GetPen(), bulet1, bulet2);
                    }
                }
            }
        }

        protected override void CreateSOCollection()
        {
            //throw new NotImplementedException();
        }
        protected virtual void CreateMap()
        {
            CreateGeometry();
            Createaspects();
        }
        protected void CreateGeometry()
        {
            _map_static._houses._geometry = _map_dynamic.GetGeometry();
        }
    }
}
