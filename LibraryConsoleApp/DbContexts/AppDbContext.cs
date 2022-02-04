using LibraryConsoleApp.models;
using Microsoft.EntityFrameworkCore;


namespace LibraryConsoleApp.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<BookLog> BookLog { get; set; }
        public virtual DbSet<Member> Member { get; set; }

        
        // public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)  
        // {   
        // }  
        // public AppDbContext() : base(new DbContextOptions<AppDbContext>())
        // {
        // }
        //
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=virtuallibrary;user=root;password=qwe123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            base.OnModelCreating(modelBuilder);
        }
        

    }
}
