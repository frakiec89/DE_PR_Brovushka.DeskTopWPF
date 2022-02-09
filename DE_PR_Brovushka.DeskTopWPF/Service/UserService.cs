using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;

namespace DE_PR_Brovushka.DeskTopWPF.Service
{
    internal class UserService
    {
        internal static List<DB.User> GetUser(int count , int  ofset )
        {
            using DB.MsSqlContext mycontext = new DB.MsSqlContext();
            return mycontext.Users.Include(c=>c.Department).Take(ofset).Skip(count).ToList();
        }
    }
}