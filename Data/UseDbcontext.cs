using Microsoft.EntityFrameworkCore;

namespace Web_Report.Data
{
    public class UseDbcontext:DbContext
    {
  
        public UseDbcontext(DbContextOptions<UseDbcontext> options)
                   : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
 
        }
    }
}
