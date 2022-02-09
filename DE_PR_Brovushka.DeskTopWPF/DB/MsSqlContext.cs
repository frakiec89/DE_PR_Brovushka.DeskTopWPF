using Microsoft.EntityFrameworkCore;


namespace DE_PR_Brovushka.DeskTopWPF.DB
{
    public class MsSqlContext : DbContext
    {
        string connectionString =
            "server=192.168.10.134;" +
            "database=Ahtyamov_DE_PR_Brovushka;" +
            "User id=stud;" +
            "password=stud;";



        public DbSet<Department> Departments 
        { get; set; }

        public DbSet<User> Users
        { get; set; }

        public DbSet<OldUser> OldUsers
        { get; set; }


        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                (connectionString);
        }

    }
}
//update - database
// add - Migration