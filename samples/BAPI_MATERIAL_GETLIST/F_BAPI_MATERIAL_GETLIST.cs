using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;
using SAPConIO.Helper;

namespace mb_samples_BAPI_MATERIAL_GETLIST
{
    public class F_BAPI_MATERIAL_GETLIST
    {
        /// <summary>
        /// FUNCTION BAPI_MATERIAL_GETLIST 
        /// </summary>
        /// <param name="MAXROWS">Maximum number of materials to be selected</param>
        /// <param name="DISTRIBUTIONCHANNELSELECTION">Selection options for distribution channel</param>
        /// <param name="MANUFACTURERPARTNUMB">Manufacturer and manufacturer part number</param>
        /// <param name="MATERIALSHORTDESCSEL">Selection options for material description</param>
        /// <param name="MATNRLIST">List of material numbers with material description</param>
        /// <param name="MATNRSELECTION">Selection options for material number</param>
        /// <param name="PLANTSELECTION">Selection options for plants</param>
        /// <param name="RETURN">Return Parameter</param>
        /// <param name="SALESORGANISATIONSELECTION">Selection options for sales organization</param>
        /// <param name="STORAGELOCATIONSELECT">Selection options for storage locations</param>
        public static bool Invoke(ConnectionInformations ci, out string exception, int MAXROWS, ref SapTable<BAPIMATRADC> DISTRIBUTIONCHANNELSELECTION, ref SapTable<BAPIMATMFRPN> MANUFACTURERPARTNUMB, ref SapTable<BAPIMATRAS> MATERIALSHORTDESCSEL, ref SapTable<BAPIMATLST> MATNRLIST, ref SapTable<BAPIMATRAM> MATNRSELECTION, ref SapTable<BAPIMATRAW> PLANTSELECTION, ref SapTable<BAPIRET2> RETURN, ref SapTable<BAPIMATRASO> SALESORGANISATIONSELECTION, ref SapTable<BAPIMATRAL> STORAGELOCATIONSELECT)
        {
            exception = "";
            try
            {
                SapConnections.Init(ci);
                RfcRepository rfcRep = SapConnections.Get(ci.Name).Repository;
                IRfcFunction function = rfcRep.CreateFunction("BAPI_MATERIAL_GETLIST");
                function.SetValue("MAXROWS", MAXROWS);
                if(DISTRIBUTIONCHANNELSELECTION != null){
                    function.SetValue("DISTRIBUTIONCHANNELSELECTION", DISTRIBUTIONCHANNELSELECTION.ToSapObject(ci.Name));
                }
                if(MANUFACTURERPARTNUMB != null){
                    function.SetValue("MANUFACTURERPARTNUMB", MANUFACTURERPARTNUMB.ToSapObject(ci.Name));
                }
                if(MATERIALSHORTDESCSEL != null){
                    function.SetValue("MATERIALSHORTDESCSEL", MATERIALSHORTDESCSEL.ToSapObject(ci.Name));
                }
                if(MATNRLIST != null){
                    function.SetValue("MATNRLIST", MATNRLIST.ToSapObject(ci.Name));
                }
                if(MATNRSELECTION != null){
                    function.SetValue("MATNRSELECTION", MATNRSELECTION.ToSapObject(ci.Name));
                }
                if(PLANTSELECTION != null){
                    function.SetValue("PLANTSELECTION", PLANTSELECTION.ToSapObject(ci.Name));
                }
                if(RETURN != null){
                    function.SetValue("RETURN", RETURN.ToSapObject(ci.Name));
                }
                if(SALESORGANISATIONSELECTION != null){
                    function.SetValue("SALESORGANISATIONSELECTION", SALESORGANISATIONSELECTION.ToSapObject(ci.Name));
                }
                if(STORAGELOCATIONSELECT != null){
                    function.SetValue("STORAGELOCATIONSELECT", STORAGELOCATIONSELECT.ToSapObject(ci.Name));
                }
                function.Invoke(SapConnections.Get(ci.Name));
                if(DISTRIBUTIONCHANNELSELECTION == null)
                    DISTRIBUTIONCHANNELSELECTION = new SapTable<BAPIMATRADC>();
                DISTRIBUTIONCHANNELSELECTION.FromSapObject(function.GetTable("DISTRIBUTIONCHANNELSELECTION"));
                if(MANUFACTURERPARTNUMB == null)
                    MANUFACTURERPARTNUMB = new SapTable<BAPIMATMFRPN>();
                MANUFACTURERPARTNUMB.FromSapObject(function.GetTable("MANUFACTURERPARTNUMB"));
                if(MATERIALSHORTDESCSEL == null)
                    MATERIALSHORTDESCSEL = new SapTable<BAPIMATRAS>();
                MATERIALSHORTDESCSEL.FromSapObject(function.GetTable("MATERIALSHORTDESCSEL"));
                if(MATNRLIST == null)
                    MATNRLIST = new SapTable<BAPIMATLST>();
                MATNRLIST.FromSapObject(function.GetTable("MATNRLIST"));
                if(MATNRSELECTION == null)
                    MATNRSELECTION = new SapTable<BAPIMATRAM>();
                MATNRSELECTION.FromSapObject(function.GetTable("MATNRSELECTION"));
                if(PLANTSELECTION == null)
                    PLANTSELECTION = new SapTable<BAPIMATRAW>();
                PLANTSELECTION.FromSapObject(function.GetTable("PLANTSELECTION"));
                if(RETURN == null)
                    RETURN = new SapTable<BAPIRET2>();
                RETURN.FromSapObject(function.GetTable("RETURN"));
                if(SALESORGANISATIONSELECTION == null)
                    SALESORGANISATIONSELECTION = new SapTable<BAPIMATRASO>();
                SALESORGANISATIONSELECTION.FromSapObject(function.GetTable("SALESORGANISATIONSELECTION"));
                if(STORAGELOCATIONSELECT == null)
                    STORAGELOCATIONSELECT = new SapTable<BAPIMATRAL>();
                STORAGELOCATIONSELECT.FromSapObject(function.GetTable("STORAGELOCATIONSELECT"));
                return true;
            }
            catch(Exception ex)
            {
                exception = ex.Message;
                return false;
            }

        }

        public static void Test()
        {
            string exception = "";
            int MAXROWS = default(int);
            SapTable<BAPIMATRADC> DISTRIBUTIONCHANNELSELECTION = new SapTable<BAPIMATRADC>();
            SapTable<BAPIMATMFRPN> MANUFACTURERPARTNUMB = new SapTable<BAPIMATMFRPN>();
            SapTable<BAPIMATRAS> MATERIALSHORTDESCSEL = new SapTable<BAPIMATRAS>();
            SapTable<BAPIMATLST> MATNRLIST = new SapTable<BAPIMATLST>();
            SapTable<BAPIMATRAM> MATNRSELECTION = new SapTable<BAPIMATRAM>();
            SapTable<BAPIMATRAW> PLANTSELECTION = new SapTable<BAPIMATRAW>();
            SapTable<BAPIRET2> RETURN = new SapTable<BAPIRET2>();
            SapTable<BAPIMATRASO> SALESORGANISATIONSELECTION = new SapTable<BAPIMATRASO>();
            SapTable<BAPIMATRAL> STORAGELOCATIONSELECT = new SapTable<BAPIMATRAL>();
            var ci = SAPConIO.Helper.ConnectionInformations.ReadFromAppConfig();
            var result = Invoke(ci, out exception, MAXROWS, ref DISTRIBUTIONCHANNELSELECTION, ref MANUFACTURERPARTNUMB, ref MATERIALSHORTDESCSEL, ref MATNRLIST, ref MATNRSELECTION, ref PLANTSELECTION, ref RETURN, ref SALESORGANISATIONSELECTION, ref STORAGELOCATIONSELECT);
            Console.WriteLine("Result: " + result);
            if (!result)
                Console.WriteLine("Exception: " + exception);
        }

    }
}