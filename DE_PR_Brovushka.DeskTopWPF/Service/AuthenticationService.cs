using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DE_PR_Brovushka.DeskTopWPF.Service
{
    internal class AuthenticationService
    {
        internal static bool IsTry(string login, string password)
        {
            using DB.MsSqlContext db = new DB.MsSqlContext();
            return   db.Users.Any(x => x.Name == login && x.Password == password);
        }

        internal static string GetUserType(string login, string password)
        {
           try
            {
                using DB.MsSqlContext db = new DB.MsSqlContext();
                return db.Users.Include(x => x.Department).FirstOrDefault(x => x.Name == login && x.Password == password).Department.Name;
            }
            catch (ArgumentException ex)
           {
                throw new Exception("Пользователь не найден");
           }
           catch (Exception ex)
           {
                throw new Exception(ex.Message);
           }
        }
    }
}
