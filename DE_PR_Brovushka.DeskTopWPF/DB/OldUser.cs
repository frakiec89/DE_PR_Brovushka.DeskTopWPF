using System;
using System.ComponentModel.DataAnnotations;

namespace DE_PR_Brovushka.DeskTopWPF.DB
{
    public class OldUser 
    {
       [Key]
       public  int OldUserId { get; set; }
       public int UserId { get; set; }
       public DateTime  DateRemove { get; set; }
       public string Name { get; set; }
       public string DepartmentName { get; set; }

    }
}