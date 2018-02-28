using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;
using SAPConIO.Helper;

namespace mb_samples_BAPI_MATERIAL_GETLIST
{
    public class BAPIMATRADC : ISapStructure
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
        /// Distribution Channel From 
        /// </summary>
        public string DISTR_CHAN_LOW { get; set; }

        /// <summary>
        /// Distribution Channel To 
        /// </summary>
        public string DISTR_CHAN_HIGH { get; set; }


        public IRfcStructure ToSapObject(string name)
        {
            IRfcStructure s = SapConnections.Get(name).Repository.GetStructureMetadata("BAPIMATRADC").CreateStructure();
            s["SIGN"].SetValue(SIGN);
            s["OPTION"].SetValue(OPTION);
            s["DISTR_CHAN_LOW"].SetValue(DISTR_CHAN_LOW);
            s["DISTR_CHAN_HIGH"].SetValue(DISTR_CHAN_HIGH);
            return s;
        }
        public ISapStructure FromSapObject(IRfcStructure s)
        {
            this.SIGN = s.GetString("SIGN");
            this.OPTION = s.GetString("OPTION");
            this.DISTR_CHAN_LOW = s.GetString("DISTR_CHAN_LOW");
            this.DISTR_CHAN_HIGH = s.GetString("DISTR_CHAN_HIGH");
            return this;
        }
    }
}