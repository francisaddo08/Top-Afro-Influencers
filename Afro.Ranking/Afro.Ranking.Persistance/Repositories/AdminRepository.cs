using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afro.Ranking.Persistance
{
    public class AdminRepository
    {
    private readonly ApplicationContext _cxt;
    public AdminRepository(ApplicationContext context)
    {  
       _cxt = context;
     }
     
     public void Save()
     {

     }
    }
}
