using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;
using SAPConIO.Helper;

namespace mb_samples_BAPI_MATERIAL_GETLIST
{
    public class BAPIMATRASO : ISapStructure
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
        /// Sales Organization From 
        /// </summary>
        public string SALESORG_LOW { get; set; }

        /// <summary>
        /// Sales Organization To 
        /// </summary>
        public string SALESORG_HIGH { get; set; }


        public IRfcStructure ToSapObject(string name)
        {
            IRfcStructure s = SapConnections.Get(name).Repository.GetStructureMetadata("BAPIMATRASO").CreateStructure();
            s["SIGN"].SetValue(SIGN);
            s["OPTION"].SetValue(OPTION);
            s["SALESORG_LOW"].SetValue(SALESORG_LOW);
            s["SALESORG_HIGH"].SetValue(SALESORG_HIGH);
            return s;
        }
        public ISapStructure FromSapObject(IRfcStructure s)
        {
            this.SIGN = s.GetString("SIGN");
            this.OPTION = s.GetString("OPTION");
            this.SALESORG_LOW = s.GetString("SALESORG_LOW");
            this.SALESORG_HIGH = s.GetString("SALESORG_HIGH");
            return this;
        }
    }
}