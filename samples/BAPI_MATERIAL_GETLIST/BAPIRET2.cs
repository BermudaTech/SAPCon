using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;
using SAPConIO.Helper;

namespace mb_samples_BAPI_MATERIAL_GETLIST
{
    public class BAPIRET2 : ISapStructure
    {
        /// <summary>
        /// Message type: S Success, E Error, W Warning, I Info, A Abort 
        /// </summary>
        public string TYPE { get; set; }

        /// <summary>
        /// Message Class 
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Message Number 
        /// </summary>
        public int NUMBER { get; set; }

        /// <summary>
        /// Message Text 
        /// </summary>
        public string MESSAGE { get; set; }

        /// <summary>
        /// Application log: log number 
        /// </summary>
        public string LOG_NO { get; set; }

        /// <summary>
        /// Application log: Internal message serial number 
        /// </summary>
        public int LOG_MSG_NO { get; set; }

        /// <summary>
        /// Message Variable 
        /// </summary>
        public string MESSAGE_V1 { get; set; }

        /// <summary>
        /// Message Variable 
        /// </summary>
        public string MESSAGE_V2 { get; set; }

        /// <summary>
        /// Message Variable 
        /// </summary>
        public string MESSAGE_V3 { get; set; }

        /// <summary>
        /// Message Variable 
        /// </summary>
        public string MESSAGE_V4 { get; set; }

        /// <summary>
        /// Parameter Name 
        /// </summary>
        public string PARAMETER { get; set; }

        /// <summary>
        /// Lines in parameter 
        /// </summary>
        public int ROW { get; set; }

        /// <summary>
        /// Field in parameter 
        /// </summary>
        public string FIELD { get; set; }

        /// <summary>
        /// Logical system from which message originates 
        /// </summary>
        public string SYSTEM { get; set; }


        public IRfcStructure ToSapObject(string name)
        {
            IRfcStructure s = SapConnections.Get(name).Repository.GetStructureMetadata("BAPIRET2").CreateStructure();
            s["TYPE"].SetValue(TYPE);
            s["ID"].SetValue(ID);
            s["NUMBER"].SetValue(NUMBER);
            s["MESSAGE"].SetValue(MESSAGE);
            s["LOG_NO"].SetValue(LOG_NO);
            s["LOG_MSG_NO"].SetValue(LOG_MSG_NO);
            s["MESSAGE_V1"].SetValue(MESSAGE_V1);
            s["MESSAGE_V2"].SetValue(MESSAGE_V2);
            s["MESSAGE_V3"].SetValue(MESSAGE_V3);
            s["MESSAGE_V4"].SetValue(MESSAGE_V4);
            s["PARAMETER"].SetValue(PARAMETER);
            s["ROW"].SetValue(ROW);
            s["FIELD"].SetValue(FIELD);
            s["SYSTEM"].SetValue(SYSTEM);
            return s;
        }
        public ISapStructure FromSapObject(IRfcStructure s)
        {
            this.TYPE = s.GetString("TYPE");
            this.ID = s.GetString("ID");
            this.NUMBER = s.GetInt("NUMBER");
            this.MESSAGE = s.GetString("MESSAGE");
            this.LOG_NO = s.GetString("LOG_NO");
            this.LOG_MSG_NO = s.GetInt("LOG_MSG_NO");
            this.MESSAGE_V1 = s.GetString("MESSAGE_V1");
            this.MESSAGE_V2 = s.GetString("MESSAGE_V2");
            this.MESSAGE_V3 = s.GetString("MESSAGE_V3");
            this.MESSAGE_V4 = s.GetString("MESSAGE_V4");
            this.PARAMETER = s.GetString("PARAMETER");
            this.ROW = s.GetInt("ROW");
            this.FIELD = s.GetString("FIELD");
            this.SYSTEM = s.GetString("SYSTEM");
            return this;
        }
    }
}