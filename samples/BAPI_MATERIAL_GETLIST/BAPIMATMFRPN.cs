using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;
using SAPConIO.Helper;

namespace mb_samples_BAPI_MATERIAL_GETLIST
{
    public class BAPIMATMFRPN : ISapStructure
    {
        /// <summary>
        /// Manufacturer Part Number 
        /// </summary>
        public string MANU_MAT { get; set; }

        /// <summary>
        /// Number of a Manufacturer 
        /// </summary>
        public string MFR_NO { get; set; }


        public IRfcStructure ToSapObject(string name)
        {
            IRfcStructure s = SapConnections.Get(name).Repository.GetStructureMetadata("BAPIMATMFRPN").CreateStructure();
            s["MANU_MAT"].SetValue(MANU_MAT);
            s["MFR_NO"].SetValue(MFR_NO);
            return s;
        }
        public ISapStructure FromSapObject(IRfcStructure s)
        {
            this.MANU_MAT = s.GetString("MANU_MAT");
            this.MFR_NO = s.GetString("MFR_NO");
            return this;
        }
    }
}