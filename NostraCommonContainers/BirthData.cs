using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NostraCommonContainers
{
    public class BirthData
    {
        int iBirthDay {get;set;}
        int iBirthMonth { get; set; }
        int iBirthYear { get; set; }
        int iBirthHour{get;set;}
        int iBirthMinutes{get;set;}
        int iBirthSecond{get;set;}
        double dDiffTime{get;set;}
        int iAdditionalHours{get;set;}
        bool bTimeIsRectificated{get;set;}
        double dLongitude{get;set;}
        double dLatitude{get;set;}
        String sBirthPlaceName{get;set;}
        int iPlaceID{get;set;}
        String sAuthenticity{get;set;}
        String sFirstName{get;set;}
        String sSecondName{get;set;}
        long ID {get;set;}
        int iDataType{get;set;}
    }
}
