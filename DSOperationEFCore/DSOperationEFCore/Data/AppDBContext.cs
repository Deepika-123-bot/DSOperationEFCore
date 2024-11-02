using Microsoft.EntityFrameworkCore;

namespace DSOperationEFCore.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) :base(options)
        { 
        }
    }
}
