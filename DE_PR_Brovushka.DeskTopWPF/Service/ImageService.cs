using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DE_PR_Brovushka.DeskTopWPF.Service
{
    public class ImageService
    {
        public static List<Model.ImageUsercs> AllImageUrl ()
        {
            using DB.MsSqlContext db = new DB.MsSqlContext ();
            List<Model.ImageUsercs> list = new List<Model.ImageUsercs>();

            foreach (var item in db.Users)
            {
                if (item.PathImage.Contains(@"pack://application:,,,/Image/picture.png"))
                {
                    list.Add(new Model.ImageUsercs { Path = item.PathImage, Name = "Без картинки" });
                    continue;
                }
                list.Add ( new Model.ImageUsercs {  Path= item.PathImage , Name = item.PathImage.Remove(0 ,string.Format(@"pack://application:,,,/Image/").Length) });
            }
            return list;
        }
    }
}
