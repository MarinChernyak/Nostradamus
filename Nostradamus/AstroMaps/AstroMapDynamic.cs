using Nostradamus.Models;
using NostraPlanetarium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using static NostraPlanetarium.NPTypes;

namespace Nostradamus.AstroMaps
{
    public class AstroMapDynamic : AstroMapBase
    {

        protected AstromapGeometryDynamic _geometry;
        protected DateTime DynamicDate { get; set; }
        protected double AdditionalHour { get; set; }

        public tAstroMapType DynamicType{ get; protected set; }
        public AstromapGeometryDynamic GetGeometry()
        {
            return _geometry as AstromapGeometryDynamic;
        }
        public AstroMapDynamic(MDynamicMapUpdateInfo info)
        {
            _geometry = new AstromapGeometryDynamic();
            DynamicDate = info.DynamicDate;
            DynamicType = info.MapType;
            EventPlace = info.EventPlace;
            AdditionalHour = info.AdditionalHour;
            GetJD();
            CreateMap();
        }
        protected void CreateMap()
        {
            CreateSOCollection();
            Createaspects();
        }
        public override void DrawMap(Graphics g)
        {
            DrawDynCircles(g);
            DrawDynamicPlanets(g);
            
        }
        protected void GetJD()
        {
            JD = new JulianDay(DynamicDate.Day, DynamicDate.Month, DynamicDate.Year, DynamicDate.Hour, DynamicDate.Minute, 0, EventPlace.TimeZoneData.TimeOffset, AdditionalHour).JD;
        }
        protected override void CreateSOCollection()
        {
            _space_objects = CreateMainCollection(tAstroMapType.TRANSIT);
        }

        protected override void Createaspects()
        {
            //dynamic-dynamic
            //_aspects = new AspectsCollection(_space_objects, _space_objects, DynamicType);
        }
        protected void CreateGeometry()
        {
            _geometry = new AstromapGeometryDynamic();
        }
        public void DrawDynamicBullets(Graphics g)
        {
            string path = Directory.GetCurrentDirectory().Replace("bin\\Debug\\netcoreapp3.1", "Resources\\icons\\DynamicObjects\\");

            Icon bbicon = new Icon($"{path}BuletBlue.ico");
            Icon bricon = new Icon($"{path}BuletRed.ico");

            foreach (SpaceObjectData sod in _space_objects)
            {
                Icon bb = sod.IsRed ? bricon : bbicon;

                g.DrawIcon(bb, (int)sod._bullet.X, (int)sod._bullet.Y);
            }
        }
        protected void DrawDynamicPlanets(Graphics g)
        {
            AstromapGeometryDynamic geometry = _geometry as AstromapGeometryDynamic;
            string path = Directory.GetCurrentDirectory().Replace("bin\\Debug\\netcoreapp3.1", "Resources\\icons\\DynamicObjects\\");

            double alfa = _houses.GelAlfa();

            int planetShift = (geometry.RExtCircleDynamic - geometry.RExtCircle) / 4 + geometry.RExtCircle;
            const int iNumIntervals = 90;
            int[] iZuz1 = new int[iNumIntervals];
            int[] iZuz2 = new int[iNumIntervals];
            int[] iZuz3 = new int[iNumIntervals];

            foreach (SpaceObjectData sod in _space_objects)
            {
                //New
                int intWidth = 360 / iNumIntervals;
                int index1 = (int)sod._so.Lambda / intWidth;
                double dl = sod._so.Lambda - intWidth / 2;
                if (dl < 0)
                    dl += 360;
                int index2 = (int)(dl / intWidth);
                int index3 = (int)((sod._so.Lambda + intWidth / 2) / intWidth);
                if (index3 >= iNumIntervals)
                    index3 = iNumIntervals - 1;

                string pt = sod._so.PlanetType.ToString();
                double delta = sod._so.Lambda - alfa;
                if (delta < 0)
                    delta += 360;


                int iZuz = Math.Max(iZuz1[index1], iZuz2[index2]);
                iZuz = Math.Max(iZuz, iZuz3[index3]);

                string r = sod._so.SpeedLong < 0 ? "R" : "";
                Image ic = Image.FromFile($"{path}{pt}{r}.png");

                double bbx = geometry.Center.X - geometry.RLimbCircle * Math.Cos(delta * Math.PI / 180) - _geometry.BULET_SHIFT;
                double bby = geometry.Center.Y + geometry.RLimbCircle * Math.Sin(delta * Math.PI / 180) - _geometry.BULET_SHIFT;
                sod._bullet = new PointF((float)bbx, (float)bby);

                int planetIconShift = delta > 270 || (delta > 0 && delta < 90) ? _geometry.BULET_SHIFT : 0;
                double px = geometry.Center.X - planetShift  * (1 + 0.09 * iZuz) * Math.Cos((delta) * Math.PI / 180) - planetIconShift;
                double py = geometry.Center.Y + planetShift  * (1 + 0.09 * iZuz) * Math.Sin((delta) * Math.PI / 180) - planetIconShift;
                g.DrawImage(ic, (int)px, (int)py);

                iZuz1[index1]++;
                iZuz2[index2]++;
                iZuz3[index3]++;
            }
        }

        protected void DrawDynCircles(Graphics g)
        {
            SolidBrush myBrush = new SolidBrush(Color.FromArgb(216,233,231));
            g.DrawEllipse(_houses.PenHouses, _geometry.ExtCircleDynamicPoint.X, _geometry.ExtCircleDynamicPoint.Y, _geometry.ExternalCircleDynamic.Width, _geometry.ExternalCircleDynamic.Height);
            g.FillEllipse(myBrush, _geometry.ExtCircleDynamicPoint.X + 1, _geometry.ExtCircleDynamicPoint.Y + 1, _geometry.ExternalCircleDynamic.Width - 2, _geometry.ExternalCircleDynamic.Height - 2);
        }

    }
}
