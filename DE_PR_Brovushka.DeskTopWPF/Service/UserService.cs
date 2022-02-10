using DE_PR_Brovushka.DeskTopWPF.DB;
using Microsoft.EntityFrameworkCore;
using System;
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

        internal static void AddUser(string name , string password, Department ustype, System.Windows.Media.ImageSource source)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"Имя не может быть пустым или содержать только пробел.");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException($"Пароль не может быть пустым или содержать только пробел.");
            }

            using DB.MsSqlContext context = new DB.MsSqlContext();
                    context.Users.Add(new User { Name= name, Password = password, DepartmentID=ustype.DepartmentID ,
                    PathImage= source.ToString()
                    });;
            context.SaveChanges();  
        }

        internal static void ChangeUser(User user)
        {
            using DB.MsSqlContext context = new DB.MsSqlContext();
            context.Users.Update(user);
            context.SaveChanges();
        }

        internal static void DellUser(User user)
        {
            using DB.MsSqlContext context = new DB.MsSqlContext();
            context.Users.Remove(user);
            context.SaveChanges();

            context.OldUsers.Add(new OldUser { Name = user.Name,  UserId=  user.UserID , 
                DateRemove = DateTime.Now  ,
                DepartmentName= user.Department.Name
            }
            );
            context.SaveChanges();
        }
    }
}