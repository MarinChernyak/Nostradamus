using NostraPlanetarium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using static NostraPlanetarium.NPTypes;

namespace Nostradamus.AstroMaps
{
    public class AstroMapDynamic : AstroMapStatic
    {
        protected List<SpaceObjectData> _dynamic_objects;
        protected DateTime DynamicDate { get; set; }

        protected tAstroMapType DynamicType{ get; set; }
    public AstroMapDynamic(int idStatic, DateTime dt, tAstroMapType type)
            : base(idStatic)
        {
            _geometry = new AstromapGeometryDynamic();
            DynamicDate = dt;
            DynamicType = type;
            GetJD(dt);
            _dynamic_objects=CreateSOCollection(DynamicType);
        }
        public override void DrawMap(Graphics g)
        {
            DrawDynCircles(g);
            DrawDynamicPlanets(g);
            base.DrawMap(g);
        }
        protected override void Createaspects()
        {
            _aspects = new AspectsCollection(_static_objects,_dynamic_objects,DynamicType);
        }
        protected override void CreateGeometry()
        {
            _geometry = new AstromapGeometryDynamic();
        }
        protected void DrawDynamicPlanets(Graphics g)
        {
            AstromapGeometryDynamic geometry = _geometry as AstromapGeometryDynamic;
            string path = Directory.GetCurrentDirectory().Replace("bin\\Debug\\netcoreapp3.1", "Resources\\icons\\DynamicObjects\\");

            double alfa = _houses.GelAlfa();
            Icon bbicon = new Icon($"{path}BuletBlue.ico");
            Icon bricon = new Icon($"{path}BuletRed.ico");

            int planetShift = (geometry.RExtCircleDynamic - geometry.RExtCircle) / 4 + geometry.RExtCircle;
            const int iNumIntervals = 90;
            int[] iZuz1 = new int[iNumIntervals];
            int[] iZuz2 = new int[iNumIntervals];
            int[] iZuz3 = new int[iNumIntervals];

            foreach (SpaceObjectData sod in _dynamic_objects)
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

                double bbx = geometry.Center.X - geometry.RLimbCircle * Math.Cos(delta * Math.PI / 180) - BULET_SHIFT;
                double bby = geometry.Center.Y + geometry.RLimbCircle * Math.Sin(delta * Math.PI / 180) - BULET_SHIFT;
                sod._bullet = new PointF((float)bbx, (float)bby);

                Icon bb = sod.IsRed ? bricon : bbicon;
                g.DrawIcon(bb, (int)bbx, (int)bby);


                double px = geometry.Center.X - (planetShift + BULET_SHIFT) * (1 + 0.09 * iZuz) * Math.Cos((delta) * Math.PI / 180);
                double py = geometry.Center.Y + (planetShift - BULET_SHIFT) * (1 + 0.09 * iZuz) * Math.Sin((delta) * Math.PI / 180);
                g.DrawImage(ic, (int)px, (int)py);


                iZuz1[index1]++;
                iZuz2[index2]++;
                iZuz3[index3]++;
            }
        }

        protected void DrawDynCircles(Graphics g)
        {
            SolidBrush myBrush = new SolidBrush(Color.FromArgb(216,233,231));
            g.DrawEllipse(_houses.PenHouses, ((AstromapGeometryDynamic)_geometry).ExtCircleDynamicPoint.X, ((AstromapGeometryDynamic)_geometry).ExtCircleDynamicPoint.Y, ((AstromapGeometryDynamic)_geometry).ExternalCircleDynamic.Width, ((AstromapGeometryDynamic)_geometry).ExternalCircleDynamic.Height);
            g.FillEllipse(myBrush, ((AstromapGeometryDynamic)_geometry).ExtCircleDynamicPoint.X + 1, ((AstromapGeometryDynamic)_geometry).ExtCircleDynamicPoint.Y + 1, ((AstromapGeometryDynamic)_geometry).ExternalCircleDynamic.Width - 2, ((AstromapGeometryDynamic)_geometry).ExternalCircleDynamic.Height - 2);
        }
    }
}
