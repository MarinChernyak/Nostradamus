using Nostradamus.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static NostraPlanetarium.NPTypes;

namespace Nostradamus.AstroMaps
{
    public class AstroMapFactory
    {
        public AstroMapBase CreatedMap { get; protected set; }
        public AstroMapFactory(int Id)
        {
            CreatedMap = new AstromapStaticStandAlone(Id);
        }
        public AstroMapFactory(MPersonBase person)
        {
            CreatedMap = new AstromapStaticStandAlone(person);
        }
        public AstroMapFactory(int Id, MDynamicMapUpdateInfo info )
        {
            switch(info.MapType)
            {
                case tAstroMapType.TRANSIT:
                    //CreatedMap = new AstroMapTransit( );
                    break;
            }
        }
    }
}
