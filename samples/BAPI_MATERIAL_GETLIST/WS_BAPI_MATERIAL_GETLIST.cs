using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using SAP.Middleware.Connector;
using SAPConIO.Helper;

namespace mb_samples_BAPI_MATERIAL_GETLIST
{
    [WebService(Namespace = "http://sapcon.io/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class WS_BAPI_MATERIAL_GETLIST : WebService
    {
        [WebMethod]
        public bool InvokeXml(string conID, string user, string passwd, out string exception, int MAXROWS, ref SapTable<BAPIMATRADC> DISTRIBUTIONCHANNELSELECTION, ref SapTable<BAPIMATMFRPN> MANUFACTURERPARTNUMB, ref SapTable<BAPIMATRAS> MATERIALSHORTDESCSEL, ref SapTable<BAPIMATLST> MATNRLIST, ref SapTable<BAPIMATRAM> MATNRSELECTION, ref SapTable<BAPIMATRAW> PLANTSELECTION, ref SapTable<BAPIRET2> RETURN, ref SapTable<BAPIMATRASO> SALESORGANISATIONSELECTION, ref SapTable<BAPIMATRAL> STORAGELOCATIONSELECT)
        {
            exception = "";
            if (String.IsNullOrEmpty(conID)){
                exception = "conID is empty.";
                return false;
            }
            if (!System.Web.Security.Membership.ValidateUser(user, passwd)){
                exception = "user/pass validation error.";
                return false;
            }
            try
            {
                var con = SAPConIO.DB.Operations.GetConnection(conID ,user);
                if (con == null){
                    exception = "Wrong connection ID.";
                    return false;
                }
                var ci = SAPConIO.Config.ConnectionHelper.GetSapConFromDBCon(con);
                return F_BAPI_MATERIAL_GETLIST.Invoke(ci, out exception, MAXROWS, ref DISTRIBUTIONCHANNELSELECTION, ref MANUFACTURERPARTNUMB, ref MATERIALSHORTDESCSEL, ref MATNRLIST, ref MATNRSELECTION, ref PLANTSELECTION, ref RETURN, ref SALESORGANISATIONSELECTION, ref STORAGELOCATIONSELECT);
            }
            catch(Exception ex)
            {
                exception = ex.Message;
                return false;
            }

        }
        class WsReturn
        {
            public SapTable<BAPIMATRADC> DISTRIBUTIONCHANNELSELECTION;
            public SapTable<BAPIMATMFRPN> MANUFACTURERPARTNUMB;
            public SapTable<BAPIMATRAS> MATERIALSHORTDESCSEL;
            public SapTable<BAPIMATLST> MATNRLIST;
            public SapTable<BAPIMATRAM> MATNRSELECTION;
            public SapTable<BAPIMATRAW> PLANTSELECTION;
            public SapTable<BAPIRET2> RETURN;
            public SapTable<BAPIMATRASO> SALESORGANISATIONSELECTION;
            public SapTable<BAPIMATRAL> STORAGELOCATIONSELECT;
            public WsReturn()
            {
                DISTRIBUTIONCHANNELSELECTION = new SapTable<BAPIMATRADC>();
                MANUFACTURERPARTNUMB = new SapTable<BAPIMATMFRPN>();
                MATERIALSHORTDESCSEL = new SapTable<BAPIMATRAS>();
                MATNRLIST = new SapTable<BAPIMATLST>();
                MATNRSELECTION = new SapTable<BAPIMATRAM>();
                PLANTSELECTION = new SapTable<BAPIMATRAW>();
                RETURN = new SapTable<BAPIRET2>();
                SALESORGANISATIONSELECTION = new SapTable<BAPIMATRASO>();
                STORAGELOCATIONSELECT = new SapTable<BAPIMATRAL>();
            }
        }

        class WsInput
        {
            public string conID;
            public string user;
            public string passwd;
            public int MAXROWS;
            public SapTable<BAPIMATRADC> DISTRIBUTIONCHANNELSELECTION;
            public SapTable<BAPIMATMFRPN> MANUFACTURERPARTNUMB;
            public SapTable<BAPIMATRAS> MATERIALSHORTDESCSEL;
            public SapTable<BAPIMATLST> MATNRLIST;
            public SapTable<BAPIMATRAM> MATNRSELECTION;
            public SapTable<BAPIMATRAW> PLANTSELECTION;
            public SapTable<BAPIRET2> RETURN;
            public SapTable<BAPIMATRASO> SALESORGANISATIONSELECTION;
            public SapTable<BAPIMATRAL> STORAGELOCATIONSELECT;
            public WsInput()
            {
                DISTRIBUTIONCHANNELSELECTION = new SapTable<BAPIMATRADC>();
                MANUFACTURERPARTNUMB = new SapTable<BAPIMATMFRPN>();
                MATERIALSHORTDESCSEL = new SapTable<BAPIMATRAS>();
                MATNRLIST = new SapTable<BAPIMATLST>();
                MATNRSELECTION = new SapTable<BAPIMATRAM>();
                PLANTSELECTION = new SapTable<BAPIMATRAW>();
                RETURN = new SapTable<BAPIRET2>();
                SALESORGANISATIONSELECTION = new SapTable<BAPIMATRASO>();
                STORAGELOCATIONSELECT = new SapTable<BAPIMATRAL>();
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string InvokeJson(string prms)
        {
            string exception = "";
            var input = Newtonsoft.Json.JsonConvert.DeserializeObject<WsInput>(prms);
            WsReturn ret = new WsReturn();
            if (InvokeXml(input.conID, input.user, input.passwd, out exception, input.MAXROWS, ref ret.DISTRIBUTIONCHANNELSELECTION, ref ret.MANUFACTURERPARTNUMB, ref ret.MATERIALSHORTDESCSEL, ref ret.MATNRLIST, ref ret.MATNRSELECTION, ref ret.PLANTSELECTION, ref ret.RETURN, ref ret.SALESORGANISATIONSELECTION, ref ret.STORAGELOCATIONSELECT))
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(ret);
            }
            else
                 return Newtonsoft.Json.JsonConvert.SerializeObject(new { exception = exception });
        }

    }
}