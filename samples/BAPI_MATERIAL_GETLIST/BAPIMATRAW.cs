using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;
using SAPConIO.Helper;

namespace mb_samples_BAPI_MATERIAL_GETLIST
{
    public class BAPIMATRAW : ISapStructure
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
        /// From plant 
        /// </summary>
        public string PLANT_LOW { get; set; }

        /// <summary>
        /// To plant 
        /// </summary>
        public string PLANT_HIGH { get; set; }


        public IRfcStructure ToSapObject(string name)
        {
            IRfcStructure s = SapConnections.Get(name).Repository.GetStructureMetadata("BAPIMATRAW").CreateStructure();
            s["SIGN"].SetValue(SIGN);
            s["OPTION"].SetValue(OPTION);
            s["PLANT_LOW"].SetValue(PLANT_LOW);
            s["PLANT_HIGH"].SetValue(PLANT_HIGH);
            return s;
        }
        public ISapStructure FromSapObject(IRfcStructure s)
        {
            this.SIGN = s.GetString("SIGN");
            this.OPTION = s.GetString("OPTION");
            this.PLANT_LOW = s.GetString("PLANT_LOW");
            this.PLANT_HIGH = s.GetString("PLANT_HIGH");
            return this;
        }
    }
}