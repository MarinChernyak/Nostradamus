using Nostradamus.AstroMaps;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using static NostraPlanetarium.NPTypes;

namespace Nostradamus.UserControls
{
    public abstract class PanelPainterPlanetsVisisbilityBase : PanelPainterBase
    {
        public List<MapPlanetsVisibility> MapPlanetsVisibilityCollection { get; set; }
        protected List<string> _maps_acr;
        public PanelPainterPlanetsVisisbilityBase()
        {
            _maps_acr = new List<string>()
            {
                "Natal","Transit","Progress","Direct","Solar", "Solar Pr","Synastry","Horar"
            };
        }
        protected override void SetSize()
        {
            _Height = 330;
            _Width = 550;
            _Height_Grid_Cell = 30;
            _Width_Grid_Cell = 60;
        }
        public override void Draw(Graphics g)
        {
            base.Draw(g);
            DrawPlanetsIcons(g);
            DrawMapsTypes(g);
            DrawData(g);
        }
        protected void DrawMapsTypes(Graphics g)
        {
            Font f = new Font(FontFamily.GenericSansSerif, 10);
            for (int i = 0; i < _maps_acr.Count; i++)
            {
                g.DrawString(_maps_acr[i], f, Brushes.Black, new PointF((i + 1) * _Width_Grid_Cell + 5, 5));
            }
        }
        protected void DrawData(Graphics g)
        {
            string path = Directory.GetCurrentDirectory().Replace("bin\\Debug\\netcoreapp3.1", "Resources\\icons\\");
            string imagepath = $"{path}yes.png";
            Image ic = Image.FromFile(imagepath);
            int imapCounter = 1;
            foreach (tAstroMapType map in Enum.GetValues(typeof(tAstroMapType)))
            {
                MapPlanetsVisibility mapobj = MapPlanetsVisibilityCollection.Where(x => x.MapType == map).FirstOrDefault();
                if (mapobj != null)
                {
                    for (int j = 0; j < mapobj.PlanetsVisibilityList.Count; j++)
                    {
                        PlanetsVisibility pv = mapobj.PlanetsVisibilityList[j];
                        if (pv.IsVisible)
                        {
                            float X = imapCounter * _Width_Grid_Cell + 5;
                            float Y = (j + 1) *_Height_Grid_Cell  + 5;

                            g.DrawImage(ic, X, Y);
                        }
                    }
                    imapCounter++;
                }
            }
        }
    }
}
