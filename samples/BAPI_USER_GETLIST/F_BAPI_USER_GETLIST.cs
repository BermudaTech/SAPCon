using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;
using SAPConIO.Helper;

namespace mb_samples_BAPI_USER_GETLIST
{
    public class F_BAPI_USER_GETLIST
    {
        /// <summary>
        /// FUNCTION BAPI_USER_GETLIST 
        /// </summary>
        /// <param name="ROWS">No. of users selected</param>
        /// <param name="MAX_ROWS">Maximum Number of Lines of Hits</param>
        /// <param name="WITH_USERNAME">Read User with Name</param>
        /// <param name="RETURN">Return Parameter</param>
        /// <param name="SELECTION_EXP">Search for Users with Free Selections</param>
        /// <param name="SELECTION_RANGE">Search for Users with a Ranges Table</param>
        /// <param name="USERLIST">User List</param>
        public static bool Invoke(ConnectionInformations ci, out string exception, out int ROWS, int MAX_ROWS, string WITH_USERNAME, ref SapTable<BAPIRET2> RETURN, ref SapTable<BAPIUSSEXP> SELECTION_EXP, ref SapTable<BAPIUSSRGE> SELECTION_RANGE, ref SapTable<BAPIUSNAME> USERLIST)
        {
            exception = "";
            ROWS = default(int);
            try
            {
                SapConnections.Init(ci);
                RfcRepository rfcRep = SapConnections.Get(ci.Name).Repository;
                IRfcFunction function = rfcRep.CreateFunction("BAPI_USER_GETLIST");
                function.SetValue("MAX_ROWS", MAX_ROWS);
                function.SetValue("WITH_USERNAME", WITH_USERNAME);
                if(RETURN != null){
                    function.SetValue("RETURN", RETURN.ToSapObject(ci.Name));
                }
                if(SELECTION_EXP != null){
                    function.SetValue("SELECTION_EXP", SELECTION_EXP.ToSapObject(ci.Name));
                }
                if(SELECTION_RANGE != null){
                    function.SetValue("SELECTION_RANGE", SELECTION_RANGE.ToSapObject(ci.Name));
                }
                if(USERLIST != null){
                    function.SetValue("USERLIST", USERLIST.ToSapObject(ci.Name));
                }
                function.Invoke(SapConnections.Get(ci.Name));
                ROWS = function.GetInt("ROWS");
                if(RETURN == null)
                    RETURN = new SapTable<BAPIRET2>();
                RETURN.FromSapObject(function.GetTable("RETURN"));
                if(SELECTION_EXP == null)
                    SELECTION_EXP = new SapTable<BAPIUSSEXP>();
                SELECTION_EXP.FromSapObject(function.GetTable("SELECTION_EXP"));
                if(SELECTION_RANGE == null)
                    SELECTION_RANGE = new SapTable<BAPIUSSRGE>();
                SELECTION_RANGE.FromSapObject(function.GetTable("SELECTION_RANGE"));
                if(USERLIST == null)
                    USERLIST = new SapTable<BAPIUSNAME>();
                USERLIST.FromSapObject(function.GetTable("USERLIST"));
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
            int ROWS = default(int);
            int MAX_ROWS = default(int);
            string WITH_USERNAME = default(string);
            SapTable<BAPIRET2> RETURN = new SapTable<BAPIRET2>();
            SapTable<BAPIUSSEXP> SELECTION_EXP = new SapTable<BAPIUSSEXP>();
            SapTable<BAPIUSSRGE> SELECTION_RANGE = new SapTable<BAPIUSSRGE>();
            SapTable<BAPIUSNAME> USERLIST = new SapTable<BAPIUSNAME>();
            var ci = SAPConIO.Helper.ConnectionInformations.ReadFromAppConfig();
            var result = Invoke(ci, out exception, out ROWS, MAX_ROWS, WITH_USERNAME, ref RETURN, ref SELECTION_EXP, ref SELECTION_RANGE, ref USERLIST);
            Console.WriteLine("Result: " + result);
            if (!result)
                Console.WriteLine("Exception: " + exception);
        }

    }
}