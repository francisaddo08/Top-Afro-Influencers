using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afro.Ranking.Persistance.ADO.NET.ValueObjects
{
    public sealed record ErrorDetail(int number,
            int severity,
            int state,
            string procedure,
            int lineNumber,
            string message
            );

}
