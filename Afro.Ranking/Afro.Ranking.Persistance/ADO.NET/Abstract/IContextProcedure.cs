using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Afro.Ranking.Persistance.ADO.NET.Abstract
{
    public interface IContextProcedure : IAsyncDisposable
    {
        public void AddParams(string key, object value);
        public Task<int>ExecuteNonQueryAsync();
        public int ExecuteNonQuery();
        public Task<SqlDataReader> ExecuteSqlDataReaderAsync();
        public SqlDataReader ExecuteSqlDataReader();
        public Task<object?> ExecuteScalarDataAsync();
        public object? ExecuteScalarData();
        public XmlReader ExecuteXmlReader();
        public Task<XmlReader> ExecuteXmlReaderAsync();

    }
}
