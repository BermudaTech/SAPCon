using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;
using SAPConIO.Helper;

namespace mb_samples_BAPI_MATERIAL_GETLIST
{
    public class BAPIMATRAM : ISapStructure
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
        /// From material number 
        /// </summary>
        public string MATNR_LOW { get; set; }

        /// <summary>
        /// To material number 
        /// </summary>
        public string MATNR_HIGH { get; set; }


        public IRfcStructure ToSapObject(string name)
        {
            IRfcStructure s = SapConnections.Get(name).Repository.GetStructureMetadata("BAPIMATRAM").CreateStructure();
            s["SIGN"].SetValue(SIGN);
            s["OPTION"].SetValue(OPTION);
            s["MATNR_LOW"].SetValue(MATNR_LOW);
            s["MATNR_HIGH"].SetValue(MATNR_HIGH);
            return s;
        }
        public ISapStructure FromSapObject(IRfcStructure s)
        {
            this.SIGN = s.GetString("SIGN");
            this.OPTION = s.GetString("OPTION");
            this.MATNR_LOW = s.GetString("MATNR_LOW");
            this.MATNR_HIGH = s.GetString("MATNR_HIGH");
            return this;
        }
    }
}