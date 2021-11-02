using Nostradamus.Models;
using NostraPlanetarium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Nostradamus.AstroMaps
{
    public class AstromapComplex : AstroMapBase
    {
        protected AstroMapStaticComplex _map_static;
        protected AstroMapDynamic _map_dynamic;
        public AstromapComplex(AstroMapStaticComplex mapstatic, MDynamicMapUpdateInfo info)
        {
           
            ID = mapstatic.ID;
            _map_static = mapstatic;
            _map_dynamic = new AstroMapDynamic(info);
            _map_dynamic._houses = _map_static._houses;
            CreateMap();
        }
        public override void DrawMap(Graphics g)
        {
            _map_static.DrawHouses(g);
            _map_dynamic.DrawMap(g);
            _map_static.DrawMap(g);
            //dynamic-static
            DrawAspects(g);
        }

        protected override void Createaspects()
        {
            _aspects = new AspectsCollection( _map_static._space_objects, _map_dynamic._space_objects, _map_dynamic.DynamicType);

        }
        public void DrawAspects(Graphics g)
        {

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
