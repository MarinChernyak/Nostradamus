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
            CreatedMap = new AstroMapStatic(Id);
        }
        public AstroMapFactory(MPersonBase person)
        {
            CreatedMap = new AstroMapStatic(person);
        }
        public AstroMapFactory(int Id, DateTime dtdynamic, tAstroMapType type )
        {
            switch(type)
            {
                case tAstroMapType.TRANSIT:
                    CreatedMap = new AstroMapTransit(Id, dtdynamic);
                    break;
            }
        }
    }
}
