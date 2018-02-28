using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections.Specialized;
using SAP.Middleware.Connector;

namespace SAPConIO.Helper
{

    public class DestinationConfiguration : IDestinationConfiguration
    {
        Dictionary<string, RfcConfigParameters> availableDestinations;
        RfcDestinationManager.ConfigurationChangeHandler changeHandler;
 
        public DestinationConfiguration()
        {
            availableDestinations=new Dictionary<string, RfcConfigParameters>();
        }
 
        public RfcConfigParameters GetParameters(string destinationName)
        {
            RfcConfigParameters foundDestination;
            availableDestinations.TryGetValue(destinationName, out foundDestination);
            return foundDestination;
        }
 
        //our configuration supports events
        public bool ChangeEventsSupported()
        {
            return true;
        }
 
        public event RfcDestinationManager.ConfigurationChangeHandler ConfigurationChanged
        {
            add
            {
                changeHandler=value;
            }
            remove
            {
                //do nothing
            }
        }
 
        //removes the destination that is known under the given name
        public void RemoveDestination(string name)
        {
            if (name != null && availableDestinations.Remove(name))
            {   
                changeHandler(name, new RfcConfigurationEventArgs(RfcConfigParameters.EventType.DELETED));
            }
        }
 
        //allows adding or modifying a destination for a specific application server
        public void AddOrEditDestination(ConnectionInformations ci)
        {
            //in productive code the given parameters should be checked for validity, e.g. that name is not null
            //as this is not relevant for the example, we omit it here
            RfcConfigParameters par = new RfcConfigParameters();
            par.Add(RfcConfigParameters.Name, ci.Name);
            par.Add(RfcConfigParameters.AppServerHost, ci.AppServerHost);
            par.Add(RfcConfigParameters.SystemNumber, ci.SystemNumber);
            par.Add(RfcConfigParameters.SystemID, ci.SystemID);
            par.Add(RfcConfigParameters.User, ci.User);
            par.Add(RfcConfigParameters.Password, ci.Password);
            par.Add(RfcConfigParameters.Client, ci.Client);
            par.Add(RfcConfigParameters.Language, ci.Language);
            par.Add(RfcConfigParameters.PoolSize, ci.PoolSize);
            par.Add(RfcConfigParameters.MaxPoolSize, ci.MaxPoolSize);
            par.Add(RfcConfigParameters.IdleTimeout, ci.IdleTimeout);
            par.Add(RfcConfigParameters.SAPRouter, ci.SAPRouter);
            RfcConfigParameters existingConfiguration;
 
            //if a destination of that name existed before, we need to fire a change event
            if (availableDestinations.TryGetValue(ci.Name, out existingConfiguration))
            {
                availableDestinations[ci.Name] = par;
                RfcConfigurationEventArgs eventArgs = new RfcConfigurationEventArgs(RfcConfigParameters.EventType.CHANGED, par);
                if(changeHandler != null)
                    changeHandler(ci.Name, eventArgs);
            }
            else
            {
                availableDestinations[ci.Name] = par;
            }
        }
    }



    public class ConnectionInformations
    {
        public string Name = "";
        public string AppServerHost = "";
        public string SystemNumber = "";
        public string SystemID = "";
        public string User = "";
        public string Password = "";
        public string Client = "";
        public string Language = "";
        public string PoolSize = "";
        public string MaxPoolSize = "";
        public string IdleTimeout = "";
        public string SAPRouter = "";

        public static ConnectionInformations ReadFromAppConfig()
        {
            ConnectionInformations ci = new ConnectionInformations();
            ci.Name = ConfigurationManager.AppSettings["Name"];
            ci.AppServerHost = ConfigurationManager.AppSettings["AppServerHost"];
            ci.SystemNumber = ConfigurationManager.AppSettings["SystemNumber"];
            ci.SystemID = ConfigurationManager.AppSettings["SystemID"];
            ci.User = ConfigurationManager.AppSettings["User"];
            ci.Password = ConfigurationManager.AppSettings["Password"];
            ci.Client = ConfigurationManager.AppSettings["Client"];
            ci.Language = ConfigurationManager.AppSettings["Language"];
            ci.PoolSize = ConfigurationManager.AppSettings["PoolSize"];
            ci.MaxPoolSize = ConfigurationManager.AppSettings["MaxPoolSize"];
            ci.IdleTimeout = ConfigurationManager.AppSettings["IdleTimeout"];
            ci.SAPRouter = ConfigurationManager.AppSettings["SAPRouter"];
            return ci;
        }
    }
}
