using Nostradamus.AstroMaps;
using Nostradamus.Dialogs;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static NostraPlanetarium.NPTypes;

namespace Nostradamus.UserControls
{
    public partial class OrbsPanelView : UserControl
    {
        public List<PlanetsAspectsOrbsPairsCollection> OrbsData { get; set; }
        protected OrbsPanelPainter _painter;
        public OrbsPanelView()
        {
            InitializeComponent();
        }

        private void OnPaintMain(object sender, PaintEventArgs e)
        {
            Graphics g = Graphics.FromHwnd(panMain.Handle);
            _painter = new OrbsPanelPainter();
            _painter.Draw(g);
            DrawData(g);
        }
        protected void DrawData(Graphics g)
        {
            if(OrbsData != null && OrbsData.Count>0)
            {
                Font f = new Font(FontFamily.GenericSansSerif, 10);

                for (int index= 0; index< OrbsData.Count;  index++)
                {
                    PlanetsAspectsOrbsPairsCollection paoc = OrbsData[index];
                    for (int j = 0; j < Constants._aspects.Count; ++j)
                    { 
                        string saspect = Constants._aspects[j];
                         AspectType at = Utilities.FromStringToEnumType<AspectType>(saspect, "AT_");
                        AspectOrbsPair aop = paoc.AspectOrbsCollection.Where(x => x.AspectType == at).FirstOrDefault();
                        if (aop == null)
                            continue;

                        double dVal = aop.OrbValue;
                        float Y = (index + 1) * _painter._Width_Grid_Cell + 5;
                        float X = (j+1) * _painter._Width_Grid_Cell + 5;
                        g.DrawString(dVal.ToString(), f, Brushes.Black, new PointF(X,Y));
                    }
                }
            }
        }

        private void OnDoubleCkickPanel(object sender, System.EventArgs e)
        {
            MouseEventArgs me = e as MouseEventArgs;

            int X = me.X;
            int Y = me.Y;

            int planet = Y/ _painter._Width_Grid_Cell - 1;
            int aspect = X /_painter._Width_Grid_Cell - 1;

            string splanet = Utilities.FromUpperCaseToLowerWithFirstCapital<tPlanetType>(_painter._planets[planet]);
            string saspect = Constants._aspects[aspect];

            PlanetsAspectsOrbsPairsCollection aop = OrbsData.Where(X => X.PlanetType == _painter._planets[planet]).FirstOrDefault();
            if (aop == null)
            {
                aop = new PlanetsAspectsOrbsPairsCollection();
                aop.PlanetType = _painter._planets[planet];
                aop.AspectOrbsCollection = new List<AspectOrbsPair>();
                OrbsData.Add(aop);

            }            
            AspectType at = Utilities.FromStringToEnumType<AspectType>(Constants._aspects[aspect], "AT_");
            AspectOrbsPair orb = aop.AspectOrbsCollection.Where(x => x.AspectType == at).FirstOrDefault();
            double value = 0;
            if(orb ==null)
            {
                orb = new AspectOrbsPair()
                {
                    AspectType = at,
                    OrbValue = 0
                };
                aop.AspectOrbsCollection.Add(orb);
            }
            else
            {
                value = orb.OrbValue;
            }
            using (dlgOrbsEdit dlg = new dlgOrbsEdit(splanet,saspect,value))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    orb.OrbValue = dlg.OrbValue;
                    if(dlg.SameDown)
                    {
                        for(int i = planet; i<_painter._planets.Count; i++)
                        {
                            PlanetsAspectsOrbsPairsCollection aop2 = OrbsData.Where(X => X.PlanetType == _painter._planets[i]).FirstOrDefault();
                            if(aop2==null)
                            {
                                aop2 = new PlanetsAspectsOrbsPairsCollection();
                                aop2.PlanetType = _painter._planets[i];
                                aop2.AspectOrbsCollection = new List<AspectOrbsPair>();
                                OrbsData.Add(aop2);
                            }

                            AspectType at2 = Utilities.FromStringToEnumType<AspectType>(Constants._aspects[aspect], "AT_");
                            AspectOrbsPair orb2 = aop2.AspectOrbsCollection.Where(x => x.AspectType == at2).FirstOrDefault();
                            if(orb2 ==null)
                            {
                                orb2 = new AspectOrbsPair();
                                orb2.AspectType = at2;
                                aop2.AspectOrbsCollection.Add(orb2);

                            }
                            orb2.OrbValue = dlg.OrbValue;

                            
                        }
                    }
                    Refresh();
                }
            }
            

        }
    }
}
