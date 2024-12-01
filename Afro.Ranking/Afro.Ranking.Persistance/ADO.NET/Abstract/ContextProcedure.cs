using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Afro.Ranking.Persistance.ADO.NET.Abstract
{
    internal class ContextProcedure : IContextProcedure
    {
       private readonly SqlCommand  Command;
       public ContextProcedure( SqlCommand sqlCommand, string procedureName, int timeOut) 
       {
            Command = sqlCommand;
            Command.CommandText = procedureName;
            if (timeOut != 30) 
            {
             Command.CommandText += timeOut;
            }
        
       }
        public void AddParams(string key, object value) 
        {
          Command.Parameters.AddWithValue(key, value);
        }
        public ValueTask DisposeAsync() => throw new NotImplementedException();
        public int ExecuteNonQuery() => throw new NotImplementedException();
        public Task<int> ExecuteNonQueryAsync() => throw new NotImplementedException();
        public object? ExecuteScalarData() => throw new NotImplementedException();
        public Task<object?> ExecuteScalarDataAsync() => throw new NotImplementedException();
        public SqlDataReader ExecuteSqlDataReader() => throw new NotImplementedException();
        public Task<SqlDataReader> ExecuteSqlDataReaderAsync() => throw new NotImplementedException();
        public XmlReader ExecuteXmlReader() => throw new NotImplementedException();
        public Task<XmlReader> ExecuteXmlReaderAsync() => throw new NotImplementedException();
    }
}
