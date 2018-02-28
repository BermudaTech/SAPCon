using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;

namespace SAPConIO.Helper
{
    public class SapTable<T> : List<T>
    {
        public IRfcTable ToSapObject(string name)
        {
            Type type = typeof(T);
            RfcStructureMetadata sMeta = SapConnections.Get(name).Repository.GetStructureMetadata(typeof(T).Name);
            RfcTableMetadata tMeta = new RfcTableMetadata("", sMeta);
            IRfcTable t = tMeta.CreateTable();
            for (int i = 0; i < this.Count; i++)
            { 
                t.Insert( ((ISapStructure) this[i]).ToSapObject(name));
            }
            return t;
        }
        public SapTable<T> FromSapObject(IRfcTable t)
        {
            this.Clear();
            for (int i = 0; i < t.RowCount; i++)
            {   
                T obj = Activator.CreateInstance<T>();
                this.Add((T)((ISapStructure) obj).FromSapObject(t[i]));
            }
            return this;
        }
    }
}
