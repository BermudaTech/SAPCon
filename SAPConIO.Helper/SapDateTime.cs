using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace SAPConIO.Helper
{
    public class SapDateTimeJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        public override bool CanRead
        {
            get { return true; }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return new SapDateTime(reader.Value.ToString()); 
        }
    }

    [JsonConverter(typeof(SapDateTimeJsonConverter))]
    public class SapDateTime
    {  
        public DateTime? Value;
        public DataType Type;

        public enum DataType { Date, Time };

        public static SapDateTime Empty
        {
            get { return new SapDateTime(); }
        }

        public SapDateTime(string s, DataType t)
        {
            try
            {
                Value = TryParse(s);
                Type = t;
            }
            catch
            {
            }
        }

        private DateTime? TryParse(string s)
        {
            DateTime val = new DateTime();
            if (DateTime.TryParse(s, out val))
                return val;
            else
                return null;
        }

        public SapDateTime(string s)
        {
            try
            {   
                Value = TryParse(s);
                if (Value.Value.Year != 1) //FIXME: "12:00:00" Year is assigned as current year.
                    Type = DataType.Date;
                else
                    Type = DataType.Time;
            }
            catch
            {
            }
        }

        public SapDateTime(DateTime d, DataType t)
        {
            try
            {
                Type = t;
                Value = d;
            }
            catch
            {
            }
        }

        public SapDateTime()
        {
        }

        public override string ToString()
        {
            if (!Value.HasValue)
                return "";

            if (Type == DataType.Time)
                return Value.Value.ToString("HH:mm:ss");
            else
                return Value.Value.ToShortDateString();
        }

        public DateTime? ToDateTime()
        {
            return Value;
        }

        public DateTime ToSapObject()
        {
            return Value.Value;
        }

        public DateTime ToSapObject(string name) //to make a same interface with RfcStructure
        {
            return Value.Value;
        }
    }
}
