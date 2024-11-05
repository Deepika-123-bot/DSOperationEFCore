using Microsoft.EntityFrameworkCore;

namespace DSOperationEFCore.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) :base(options)
        { 
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurrencyType>().HasData(
                new CurrencyType() { Id=1,Title="INR", Description="Indian Currecny"},
                new CurrencyType() { Id=2,Title="Dollar", Description= "Dollar Currecny" },
                new CurrencyType() { Id=3,Title="Euro", Description= "Euro Currecny" },
                new CurrencyType() { Id=4,Title="Dinar", Description= "Dinar Currecny" }
                );
            modelBuilder.Entity<Language>().HasData(
               new Language() { Id = 1, Title = "Hindi", Description = "Hindi" },
               new Language() { Id = 2, Title = "Tamil", Description = "Tamil" },
               new Language() { Id = 3, Title = "Punjabi", Description = "Punjabi" },
               new Language() { Id = 4, Title = "Urdu", Description = "Urdu" }
               );


        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<BookPrice> BookPrices { get; set; }
        public DbSet<CurrencyType> CurrencyTypes { get; set; }
    }
}
