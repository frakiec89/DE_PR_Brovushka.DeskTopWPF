
using System;
using System.ComponentModel.DataAnnotations;


namespace DE_PR_Brovushka.DeskTopWPF.DB
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        public string Name { get; set; }

        public int DepartmentID { get; set; }

        public  string  Password { get; set;}
        
        public Department Department 
        { get; set; }



        private string _pathImage; 
        public string PathImage { get => string.IsNullOrEmpty(_pathImage) ? Service.ImageService.ImageNameSpase : _pathImage;
            set => _pathImage = value; }
    }
}
