using Microsoft.EntityFrameworkCore;

namespace Digify.Data.Entity
{
    public partial class DigifyContext:DbContext
    {
        public DigifyContext(DbContextOptions<DigifyContext>options)
            :base (options) { }

        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    }
}
