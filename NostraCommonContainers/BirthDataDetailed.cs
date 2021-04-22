using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NostraCommonContainers
{
    public class BirthDataDetailed : BirthData
    {
        long IDContributor{get;set;}
        String Sex{get;set;}
        String AccessLevel{get;set;}
        List<KeyWord> KWList{get;set;}
        List<String> Notes{get;set;}
    }
}
