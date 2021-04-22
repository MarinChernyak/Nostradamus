using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NostraPlanetarium
{
    public abstract class SpaceObject
    {
        NPTypes.tPlanetType _ptype;
        public NPTypes.tPlanetType PlanetType { get { return _ptype; } }
        private  NPTypes.CoordinateObject _coordinate;
        protected NPTypes.CoordinateObject Coordinates
        {
            get
            {
                if (_coordinate == null)
                    _coordinate = new NPTypes.CoordinateObject();

                return _coordinate;
            }
        }
        public double Lambda { get { return Coordinates.dLambda; } }
        public double Beta { get { return Coordinates.dBeta; } }
        public double Distance { get { return Coordinates.dDistance; } }
        public double SpeedLong { get { return Coordinates.dSpeedLong; } }
        public double SpeedLat { get { return Coordinates.dSpeedLat; } }
        public double SpeedDist { get { return Coordinates.dSpeedDist; } }

        public bool Enable { get; set; }

        public SpaceObject(double JD, NPTypes.tPlanetType ptype)
        {
            _ptype = ptype;
            CalcObjPosition(JD, ptype);
        }

        public virtual void CalcObjPosition(double JD, NPTypes.tPlanetType ptype)
        {
            	String serr=String.Empty;
	            long iflgret;
                double [] dCoordinates= new double[6];
                using (var sweph = new SwissEphNet.SwissEph())
                {
                    if ((int)ptype == 15)
                    {
                        bool dir = Directory.Exists("C:\\DEV\\Ephem");
                        bool f = File.Exists(@"C:\SWEPH\ephe\seas_18.se1");

                    }
                    sweph.swe_set_ephe_path(null);
                    sweph.swe_set_ephe_path(@"C:\SWEPH\ephe\");
                    iflgret = sweph.swe_calc_ut(JD, (int)ptype, Constants.SEFLG_SPEED, dCoordinates,ref serr);
                    Enable = false;

                    if (iflgret >= 0)
                    {
                        Enable = true;
                        FillCoordinates(dCoordinates);
                    }
                    else
                    {
                        Enable = false;
                    }
                    
                    sweph.swe_close();
                }
        }
        protected void FillCoordinates(double [] pdCoord)
        {
            Coordinates.dLambda = pdCoord[0];
            Coordinates.dBeta = pdCoord[1];
            Coordinates.dDistance = pdCoord[2];
            Coordinates.dSpeedLong = pdCoord[3];
            Coordinates.dSpeedLat = pdCoord[4];
            Coordinates.dSpeedDist = pdCoord[5];
        }
    }
}
