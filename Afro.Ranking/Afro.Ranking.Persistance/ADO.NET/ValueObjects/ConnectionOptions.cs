using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afro.Ranking.Persistance.ADO.NET.ValueObjects
{
    public sealed record ConnectionOptions(string Source, string ConnectionString);
  
}
