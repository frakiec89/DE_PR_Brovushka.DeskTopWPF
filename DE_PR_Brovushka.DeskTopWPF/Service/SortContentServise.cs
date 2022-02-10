using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DE_PR_Brovushka.DeskTopWPF.Service
{
    public  class SortContentServise
    {
        public static List<string> SortUser()
        {
            return new List<string> { "Без сортировки", "по возрастанию", "по убыванию" };
        }

        internal static IEnumerable FiltreUser()
        {
            return new List<string> { "Без фильтра" };
        }
    }
    
}
