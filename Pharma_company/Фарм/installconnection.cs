using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Фарм
{
    class installconnection
    { 
        public string connection;
        public string connection1;
        public installconnection()
        {
            connection = "c:/Program Files/Microsoft SQL Server/MSSQL.1/MSSQL/DATA/Firma.mdf";
            connection1 = @"data source=.\LH-Q07WRANS3M63\SQLEXPRESS; User Instance=true;Integrated Security=SSPI;AttachDBFilename=";
        }

    
    }
}
