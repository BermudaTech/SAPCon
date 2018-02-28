# SAPCon.IO
SAP RFC Connector and Code Generator

SAP NCo 3 is the current version of SAP's development environment for communication between the Microsoft .NET platform and SAP systems. This connector supports RFCs and Web services. It allows you to write different applications such as Web form, Windows form, or console applications in the Microsoft Visual Studio.Net.
With the SAP .NET Connector, you can use all common programming languages, such as Visual Basic. NET, C#, or Managed C++.

SAPCon is a helper library for SAP NCo 3 and utility tool like (svcutil.exe) that generates service model code from SAP RFC metadata. You can easily call RFC by this generated client code without knowing any information about RFC metada.
It also generates RFC metadata documentation as parameter description that makes the code easy to use and makes it displayed in IntelliSense, the Object Browser, and in the Code Comment Web Report.

Library supports all deep structures, SAP Date and Time > .NET DateTime, import export parameters and tables.

This code is Test() function (also auto generated) to Invoke generated code for BAPI_USER_GETLIST

```C#
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

```

This is an auto generated structure used in RFC call.
```C#
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
    
 ```

```SapTable<T>``` is a class derived from ```List<T>``` so you can use all Linq operations! 

# SAPConIO (Web Generator - app.sapcon.io) and SAPConIO.Generator 
This tool is developed as an internal tool to reduce our development time and effort. I am doing a little make up on generator project before opening the code :)

# How to Use
Download SAPConIO.Base project to start or test your generated code.

You can try the generator online: http://app.sapcon.io/

[![SAPCon.IO Codegen](https://i.ytimg.com/vi/OvJWFu9CRiY/hqdefault.jpg?sqp=-oaymwEZCPYBEIoBSFXyq4qpAwsIARUAAIhCGAFwAQ==&rs=AOn4CLB8eauucS03-07DtRwV3skRCDzg1w)](https://www.youtube.com/watch?v=OvJWFu9CRiY)

[![SAPCon.IO Codegen](https://i.ytimg.com/vi/6QaLZadawjM/hqdefault.jpg?sqp=-oaymwEZCPYBEIoBSFXyq4qpAwsIARUAAIhCGAFwAQ==&rs=AOn4CLC9PjIItMXikYV3PY31VKwx-OhnyQ)](https://www.youtube.com/watch?v=6QaLZadawjM)
