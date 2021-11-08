using Nostradamus.AstroMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nostradamus
{
    public class Constants
    {
        public const int CustomIdMap = 300000;
        //public const string ConnectionRemote = "NostradamusRemote";
        public const string ConnectionLocal = "NostradamusLocal";
        //public const string ConnectionGeoRemote = "NostraGeneralRemote";
        public const string ConnectionGeoLocal = "NostraGeo";

        public const string DefaultOrbsSystem = "Huber";
        public const string DefaultHuseSystemId = "K";
        public const string DefaultHuseSystem = "Koch";
        protected static List<string> __aspects;
        public static List<string> _aspects
        {
            get
            {
                if(__aspects==null)
                {
                    
                    __aspects = new string[]
                    {
                        "Conjunction","Semisextile","Sextile","Quadro","Trine","Quincunx","Opposition","Quintile","Biquintile","Octile","Trioctile","Decile","Tridecile"
                    }.ToList();
                }
                return __aspects;
            }
        }
        
        protected  Constants()
        {
            
        }



    }
}
