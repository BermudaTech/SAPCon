using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;
using SAPConIO.Helper;

namespace mb_samples_BAPI_MATERIAL_GETLIST
{
    public class BAPIMATRAL : ISapStructure
    {
        /// <summary>
        /// Inclusion/exclusion criterion SIGN for range tables 
        /// </summary>
        public string SIGN { get; set; }

        /// <summary>
        /// Selection operator OPTION for range tables 
        /// </summary>
        public string OPTION { get; set; }

        /// <summary>
        /// From storage location 
        /// </summary>
        public string STLOC_LOW { get; set; }

        /// <summary>
        /// To storage location 
        /// </summary>
        public string STLOC_HIGH { get; set; }


        public IRfcStructure ToSapObject(string name)
        {
            IRfcStructure s = SapConnections.Get(name).Repository.GetStructureMetadata("BAPIMATRAL").CreateStructure();
            s["SIGN"].SetValue(SIGN);
            s["OPTION"].SetValue(OPTION);
            s["STLOC_LOW"].SetValue(STLOC_LOW);
            s["STLOC_HIGH"].SetValue(STLOC_HIGH);
            return s;
        }
        public ISapStructure FromSapObject(IRfcStructure s)
        {
            this.SIGN = s.GetString("SIGN");
            this.OPTION = s.GetString("OPTION");
            this.STLOC_LOW = s.GetString("STLOC_LOW");
            this.STLOC_HIGH = s.GetString("STLOC_HIGH");
            return this;
        }
    }
}