using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;
using SAPConIO.Helper;

namespace mb_samples_BAPI_MATERIAL_GETLIST
{
    public class BAPIMATLST : ISapStructure
    {
        /// <summary>
        /// Material Number 
        /// </summary>
        public string MATERIAL { get; set; }

        /// <summary>
        /// Material Description (Short Text) 
        /// </summary>
        public string MATL_DESC { get; set; }

        /// <summary>
        /// Long Material Number for MATERIAL Field 
        /// </summary>
        public string MATERIAL_EXTERNAL { get; set; }

        /// <summary>
        /// External GUID for MATERIAL Field 
        /// </summary>
        public string MATERIAL_GUID { get; set; }

        /// <summary>
        /// Version Number for MATERIAL Field 
        /// </summary>
        public string MATERIAL_VERSION { get; set; }


        public IRfcStructure ToSapObject(string name)
        {
            IRfcStructure s = SapConnections.Get(name).Repository.GetStructureMetadata("BAPIMATLST").CreateStructure();
            s["MATERIAL"].SetValue(MATERIAL);
            s["MATL_DESC"].SetValue(MATL_DESC);
            s["MATERIAL_EXTERNAL"].SetValue(MATERIAL_EXTERNAL);
            s["MATERIAL_GUID"].SetValue(MATERIAL_GUID);
            s["MATERIAL_VERSION"].SetValue(MATERIAL_VERSION);
            return s;
        }
        public ISapStructure FromSapObject(IRfcStructure s)
        {
            this.MATERIAL = s.GetString("MATERIAL");
            this.MATL_DESC = s.GetString("MATL_DESC");
            this.MATERIAL_EXTERNAL = s.GetString("MATERIAL_EXTERNAL");
            this.MATERIAL_GUID = s.GetString("MATERIAL_GUID");
            this.MATERIAL_VERSION = s.GetString("MATERIAL_VERSION");
            return this;
        }
    }
}