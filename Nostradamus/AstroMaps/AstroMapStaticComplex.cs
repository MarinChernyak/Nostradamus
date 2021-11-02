﻿using Nostradamus.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Nostradamus.AstroMaps
{
    public class AstroMapStaticComplex : AstromapStaticStandAlone
    {
        public AstroMapStaticComplex(int id)
            : base(id)
        {
        }
        public AstroMapStaticComplex(MPersonBase person)
            : base(person)

        {
        }
        public AstroMapStaticComplex(AstromapStaticStandAlone map)
        {
            CreateMapSigns();
            _geometry = map.GetGeometry();
            JD = map.JD;
            EventPlace = map.EventPlace;
            _houses = map._houses;
            ID = map.ID;
            _space_objects = map._space_objects;
            _aspects = map._aspects;

        }
        public override void DrawMap(Graphics g)
        {
            DrawCircles(g);
            DrawSigns(g);
            DrawPlanets(g);

        }
    }
}