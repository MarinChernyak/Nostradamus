using Nostradamus.AstroMaps;
using Nostradamus.Models.XMLSerializers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace Nostradamus.Models.DataFactories
{
    public class AspectsMapFactory : DataFactoryBase<List<AspectData>>
    {
        
        protected override void CreateDefaultData()
        {
            AspectType value = AspectType.AT_CONJUNCTION;

            Data = new List<AspectData>();
            Data.Add(new AspectData(AspectType.AT_CONJUNCTION, (int)value, "Conjunction", "con", 0,0,0,0));

            value = AspectType.AT_SEMISEXTILE;
            Data.Add(new AspectData(AspectType.AT_SEMISEXTILE, (int)value, "Semi-sextile", "ssxt", 232, 102, 79, 1.5F, DashStyle.Dash));

            value = AspectType.AT_SEXTILE;
            Data.Add(new AspectData(AspectType.AT_SEXTILE, (int)value, "Sextile", "sxt", 38, 34, 213));

            value = AspectType.AT_QUADRO;
            Data.Add(new AspectData(AspectType.AT_QUADRO, (int)value, "Quadro", "qdr", 255, 40, 40));

            value = AspectType.AT_TRINE;
            Data.Add(new AspectData(AspectType.AT_TRINE, (int)value, "Trin", "trn", 0, 0, 255));

            value = AspectType.AT_QUINCUNX;
            Data.Add(new AspectData(AspectType.AT_QUINCUNX, (int)value, "Quincunx", "qcx", 187, 49, 206, 1.5F, DashStyle.Dash));

            value = AspectType.AT_OPPOSITION;
            Data.Add(new AspectData(AspectType.AT_OPPOSITION, (int)value, "Opposition", "opp", 208, 34, 51));

            //======= Minor ====
            //72
            value = AspectType.AT_QUINTILE;
            Data.Add(new AspectData(AspectType.AT_QUINTILE, (int)value, "Quintile", "qtl", 132, 184, 92, 1.5F, DashStyle.DashDot));
            //144
            value = AspectType.AT_BIQUINTILE;
            Data.Add(new AspectData(AspectType.AT_BIQUINTILE, (int)value, "Biquintile", "qtl", 95, 140, 62, 1.5F, DashStyle.DashDot));
            //45
            value = AspectType.AT_OCTILE;
            Data.Add(new AspectData(AspectType.AT_OCTILE, (int)value, "Octile", "oct", 189, 132, 53, 1.5F, DashStyle.DashDot));
            //135
            value = AspectType.AT_TRIOCTILE;
            Data.Add(new AspectData(AspectType.AT_TRIOCTILE, (int)value, "Trioctile", "tct", 151, 105, 43,1.5F, DashStyle.DashDot));
            //36
            value = AspectType.AT_DECILE;
            Data.Add(new AspectData(AspectType.AT_DECILE, (int)value, "Decile", "dcl", 181, 84, 245,1.5F, DashStyle.DashDot));
            //108
            value = AspectType.AT_TRIDECILE;
            Data.Add(new AspectData(AspectType.AT_TRIDECILE, (int)value, "Tridecile", "tdc",149, 13, 240,1.5F, DashStyle.DashDot ));
            
        }

        protected override void CreateSerializer()
        {
            _serializer = new AspectsMapSerializer();
        }
    }
}
