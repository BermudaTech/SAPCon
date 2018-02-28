using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;
using SAPConIO.Helper;

namespace mb_samples_BAPI_USER_GETLIST
{
    public class BAPIUSSRGE : ISapStructure
    {
        /// <summary>
        /// Parameter Name 
        /// </summary>
        public string PARAMETER { get; set; }

        /// <summary>
        /// Field in the Parameter 
        /// </summary>
        public string FIELD { get; set; }

        /// <summary>
        /// Inclusion/exclusion criterion SIGN for range tables 
        /// </summary>
        public string SIGN { get; set; }

        /// <summary>
        /// Selection operator OPTION for range tables 
        /// </summary>
        public string OPTION { get; set; }

        /// <summary>
        /// 'Generic' SELECT-OPTION for Dynamic Selections 
        /// </summary>
        public string LOW { get; set; }

        /// <summary>
        /// 'Generic' SELECT-OPTION for Dynamic Selections 
        /// </summary>
        public string HIGH { get; set; }


        public IRfcStructure ToSapObject(string name)
        {
            IRfcStructure s = SapConnections.Get(name).Repository.GetStructureMetadata("BAPIUSSRGE").CreateStructure();
            s["PARAMETER"].SetValue(PARAMETER);
            s["FIELD"].SetValue(FIELD);
            s["SIGN"].SetValue(SIGN);
            s["OPTION"].SetValue(OPTION);
            s["LOW"].SetValue(LOW);
            s["HIGH"].SetValue(HIGH);
            return s;
        }
        public ISapStructure FromSapObject(IRfcStructure s)
        {
            this.PARAMETER = s.GetString("PARAMETER");
            this.FIELD = s.GetString("FIELD");
            this.SIGN = s.GetString("SIGN");
            this.OPTION = s.GetString("OPTION");
            this.LOW = s.GetString("LOW");
            this.HIGH = s.GetString("HIGH");
            return this;
        }
    }
}