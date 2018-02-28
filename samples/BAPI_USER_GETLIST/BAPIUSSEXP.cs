using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;
using SAPConIO.Helper;

namespace mb_samples_BAPI_USER_GETLIST
{
    public class BAPIUSSEXP : ISapStructure
    {
        /// <summary>
        /// Logical operation 
        /// </summary>
        public string LOGOP { get; set; }

        /// <summary>
        /// Priority of logical operation 
        /// </summary>
        public int ARITY { get; set; }

        /// <summary>
        /// Parameter Name 
        /// </summary>
        public string PARAMETER { get; set; }

        /// <summary>
        /// Field in the Parameter 
        /// </summary>
        public string FIELD { get; set; }

        /// <summary>
        /// ABAP: Selection option (EQ/BT/CP/...) 
        /// </summary>
        public string OPTION { get; set; }

        /// <summary>
        /// ABAP/4: Selection value (LOW or HIGH value, external format) 
        /// </summary>
        public string LOW { get; set; }

        /// <summary>
        /// ABAP/4: Selection value (LOW or HIGH value, external format) 
        /// </summary>
        public string HIGH { get; set; }


        public IRfcStructure ToSapObject(string name)
        {
            IRfcStructure s = SapConnections.Get(name).Repository.GetStructureMetadata("BAPIUSSEXP").CreateStructure();
            s["LOGOP"].SetValue(LOGOP);
            s["ARITY"].SetValue(ARITY);
            s["PARAMETER"].SetValue(PARAMETER);
            s["FIELD"].SetValue(FIELD);
            s["OPTION"].SetValue(OPTION);
            s["LOW"].SetValue(LOW);
            s["HIGH"].SetValue(HIGH);
            return s;
        }
        public ISapStructure FromSapObject(IRfcStructure s)
        {
            this.LOGOP = s.GetString("LOGOP");
            this.ARITY = s.GetInt("ARITY");
            this.PARAMETER = s.GetString("PARAMETER");
            this.FIELD = s.GetString("FIELD");
            this.OPTION = s.GetString("OPTION");
            this.LOW = s.GetString("LOW");
            this.HIGH = s.GetString("HIGH");
            return this;
        }
    }
}