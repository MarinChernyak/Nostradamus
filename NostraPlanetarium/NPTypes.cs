using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NostraPlanetarium
{
    public class NPTypes
    {
        public class CoordinateObject
        {
            public double dBeta{get;set;}
            public double dLambda{get;set;}
            public double dDistance{get;set;}
            public double dSpeedLat{get;set;}//speed in latitude., 
            public double dSpeedLong{get;set;}//speed in longitude., 
            public double dSpeedDist{get;set;}//speed in distance. See document
        }
        public enum tAstroMapType
        {
            UNKNOWN = -1,
            RADICAL = 0,
            TRANSIT,
            PROGRESS,
            DIRRECTIVE,
            SOLAR,
            SOLAR_PROGRESS,
            SYNASTRY,
            NUMBER_DYNAMIC_TYPES
        };
        public enum tPlanetType
        {
            PT_NONE = -1,
            PT_SUN = 0,
            PT_MOON,
            PT_MERCURY,
            PT_VENUS,
            PT_MARS,
            PT_JUPITER,
            PT_SATURN,
            PT_URANUS,
            PT_NEPTUNE,
            PT_PLUTO,//9
            PT_MEAN_NODE,//10
            PT_TRUE_NODE,             
            PT_MEAN_APOG, //Lilit 
            PT_OSCU_APOG,//13
            PT_EARTH,
            PT_CHIRON,//15
            PT_PHOLUS,
            PT_CERES,
            PT_PALLAS,
            PT_JUNO,
            PT_VESTA,//20
            PT_END_OF_SMALL_PORBITS_LIST,//21
            PT_CUPIDO = 40,
            PT_HADES,
            PT_ZEUS,
            PT_KRONOS,
            PT_APOLLON,
            PT_ADMETOS,
            PT_VULKANUS,
            PT_POSEIDON,
            PT_END_OF_HAMBURGERS_LIST,
            PT_CUSP_OBJECT_AC = 9000,
            PT_CUSP_OBJECT_12,
            PT_CUSP_OBJECT_11,
            PT_CUSP_OBJECT_MC, //9003
            PT_CUSP_OBJECT_9,
            PT_CUSP_OBJECT_8,
            PT_END_CUSP_OBJECTS,
            PT_CUSTOM = 10000

        };

        public enum tPlanetsGroup
        {
            PG_MAIN = 0,
            PG_SMALL_FICT,
            PG_HAMBURGERS,
            PG_CUSTOM
        };
        public enum tSmallFictPlanetIcon
        {
            SFPI_NODE = 0,
            SFPI_LILIT,
            SFPI_CHIRON,
            SFPI_PHOLUS,
            SFPI_CERES,
            SFPI_PALLAS,
            SFPI_JUNO,
            SFPI_VESTA,
            SFPI_NODE_R,
            SFPI_LILIT_R,
            SFPI_CHIRON_R,
            SFPI_PHOLUS_R,
            SFPI_CERES_R,
            SFPI_PALLAS_R,
            SFPI_JUNO_R,
            SFPI_VESTA_R,
            SFPI_NODE_PROGN,
            SFPI_LILIT_PROGN,
            SFPI_CHIRON_PROGN,
            SFPI_PHOLUS_PROGN,
            SFPI_CERES_PROGN,
            SFPI_PALLAS_PROGN,
            SFPI_JUNO_PROGN,
            SFPI_VESTA_PROGN,
            SFPI_NODE_PROGN_R,
            SFPI_LILIT_PROGN_R,
            SFPI_CHIRON_PROGN_R,
            SFPI_PHOLUS_PROGN_R,
            SFPI_CERES_PROGN_R,
            SFPI_PALLAS_PROGN_R,
            SFPI_JUNO_PROGN_R,
            SFPI_VESTA_PROGN_R,
            SFPI_NO_ICON
        };
    }
}
