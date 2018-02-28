using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;

namespace SAPConIO.Helper
{   
    public class SapConnections
    {
        static DestinationConfiguration connectionInfo = null;
        static SapConnections()
        {
            connectionInfo = new DestinationConfiguration();
            RfcDestinationManager.RegisterDestinationConfiguration(connectionInfo);
        }
       
        public static void Init(ConnectionInformations ci)
        {
            RfcDestination dest = null;
            try
            {
                dest = RfcDestinationManager.GetDestination(ci.Name);
            }
            catch { }
            if (dest == null)
            {
                connectionInfo.AddOrEditDestination(ci);                
                dest = RfcDestinationManager.GetDestination(ci.Name);
            }
            dest.Ping();
        }

        public static RfcDestination Get(string name)
        {
            return RfcDestinationManager.GetDestination(name);
        }

        public static void Delete(string name)
        {
            connectionInfo.RemoveDestination(name);
        }
    }
}
