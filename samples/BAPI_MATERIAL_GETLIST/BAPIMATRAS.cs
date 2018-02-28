using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;
using SAPConIO.Helper;

namespace mb_samples_BAPI_MATERIAL_GETLIST
{
    public class BAPIMATRAS : ISapStructure
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
        /// Material description from 
        /// </summary>
        public string DESCR_LOW { get; set; }

        /// <summary>
        /// Material description to 
        /// </summary>
        public string DESCR_HIGH { get; set; }


        public IRfcStructure ToSapObject(string name)
        {
            IRfcStructure s = SapConnections.Get(name).Repository.GetStructureMetadata("BAPIMATRAS").CreateStructure();
            s["SIGN"].SetValue(SIGN);
            s["OPTION"].SetValue(OPTION);
            s["DESCR_LOW"].SetValue(DESCR_LOW);
            s["DESCR_HIGH"].SetValue(DESCR_HIGH);
            return s;
        }
        public ISapStructure FromSapObject(IRfcStructure s)
        {
            this.SIGN = s.GetString("SIGN");
            this.OPTION = s.GetString("OPTION");
            this.DESCR_LOW = s.GetString("DESCR_LOW");
            this.DESCR_HIGH = s.GetString("DESCR_HIGH");
            return this;
        }
    }
}