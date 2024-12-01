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
       private  SqlCommand  Command;
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

        public int ExecuteNonQuery()
        {
            try
            {
              return  Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw CreateException(ex);
            }
        }
        public Task<int> ExecuteNonQueryAsync()
        {
            try
            {
                return Command.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                throw CreateException(ex);
            }
        }
       
        
        public object ExecuteScalarData() 
        {
            try
            {
                return Command.ExecuteScalar();
            }
            catch (Exception ex)
            { 
            throw CreateException(ex);
            }
        }
        public Task<object?> ExecuteScalarDataAsync() => throw new NotImplementedException();
        public SqlDataReader ExecuteSqlDataReader() => throw new NotImplementedException();
        public Task<SqlDataReader> ExecuteSqlDataReaderAsync() => throw new NotImplementedException();
        public XmlReader ExecuteXmlReader() => throw new NotImplementedException();
        public Task<XmlReader> ExecuteXmlReaderAsync() => throw new NotImplementedException();

        private Exception CreateException(Exception exception)
        {
            Exception ex = new Exception("Failed to execute stored procedure", exception);
            ex.Data.Add("CommandText", Command.CommandText);
            ex.Data.Add("parameters", GetParametersForCommand());

            return ex;

        }

        private string GetParametersForCommand() 
        {
          StringBuilder sb = new StringBuilder();
          foreach( SqlParameter param in Command.Parameters)
          {
                sb.Append($"{param.ParameterName}={param.Value}|");
          }
          return sb.ToString();
        }
        public ValueTask DisposeAsync() => Command.DisposeAsync();
      
    }
}
