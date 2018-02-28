using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;

namespace SAPConIO.Helper
{
    public interface ISapStructure
    {
        IRfcStructure ToSapObject(string name);
        ISapStructure FromSapObject(IRfcStructure s);
    }
}
