using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DE_PR_Brovushka.DeskTopWPF.Service
{
    internal class UserTypeService
    {
        internal static List<DB.Department> GetTypeService()
        {
          using  DB.MsSqlContext msSqlContext = new DB.MsSqlContext();
            return msSqlContext.Departments.OrderBy(x=>x.Name).ToList();
        }
    }
}
