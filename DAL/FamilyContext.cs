using Identity4Example.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Identity4Example.DAL
{
    public class FamilyContext : DbContext
    {

        public FamilyContext()
            : base("FamilyContext") 
          
    {

        Database.SetInitializer<FamilyContext>(new DropCreateDatabaseIfModelChanges<FamilyContext>());
    }
        
        public DbSet<ScheduleService> ScheduleServices { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Timer> Timers { get; set; }
        public DbSet<FileUploader> FileUploaders { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<FilePath> FilePaths { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

       


    }
}