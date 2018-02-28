using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;
using SAPConIO.Helper;

namespace mb_samples_BAPI_USER_GETLIST
{
    public class BAPIUSNAME : ISapStructure
    {
        /// <summary>
        /// User Name in User Master Record 
        /// </summary>
        public string USERNAME { get; set; }

        /// <summary>
        /// First name 
        /// </summary>
        public string FIRSTNAME { get; set; }

        /// <summary>
        /// Last name 
        /// </summary>
        public string LASTNAME { get; set; }

        /// <summary>
        /// Full Name of Person 
        /// </summary>
        public string FULLNAME { get; set; }


        public IRfcStructure ToSapObject(string name)
        {
            IRfcStructure s = SapConnections.Get(name).Repository.GetStructureMetadata("BAPIUSNAME").CreateStructure();
            s["USERNAME"].SetValue(USERNAME);
            s["FIRSTNAME"].SetValue(FIRSTNAME);
            s["LASTNAME"].SetValue(LASTNAME);
            s["FULLNAME"].SetValue(FULLNAME);
            return s;
        }
        public ISapStructure FromSapObject(IRfcStructure s)
        {
            this.USERNAME = s.GetString("USERNAME");
            this.FIRSTNAME = s.GetString("FIRSTNAME");
            this.LASTNAME = s.GetString("LASTNAME");
            this.FULLNAME = s.GetString("FULLNAME");
            return this;
        }
    }
}