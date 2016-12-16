using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_1039.Models
{
    public class Preaudit
    {
        public string PNO { get; set; }
        public string PATNAME { get; set; }
        public string TYPE { get; set; }
        public string MCODE { get; set; }
        public string ORDERNAME { get; set; }

        //public string SEQ               { get; set; }
        //public string REQY              { get; set; }
        public string REQYMD           { get; set; }
        public string REQQTY            { get; set; }
        //public string APVNO             { get; set; }
        public string APVQTY            { get; set; }
        public string REMAINDER { get; set; }
        public string text { get; set; }
        public bool done { get; set; }
        //public string UNIT              { get; set; }
        //public string UDATE             { get; set; }
        //public string OPR               { get; set; }
        //public string HOSPITAL          { get; set; }
        //public string SLIMIT            { get; set; }
        //public string MENO              { get; set; }
        public string APVDATE           { get; set; }
        public string HOSPITAL { get; set; }
        //public string REQNO             { get; set; }
        //public string FAILREP           { get; set; }
        //public string POS               { get; set; }
        //public string PRTFLG            { get; set; }
        //public string TYPE              { get; set; }
        //public string APPLYDR           { get; set; }
        //public string EXPIREDATE        { get; set; }
        //public string APPLY_R           { get; set; }
        //public string PRELINKNO         { get; set; }
        //public string NHICODE           { get; set; }
    }
}