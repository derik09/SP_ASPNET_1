using Microsoft.AspNet.Identity.EntityFramework;
using SP_ASPNET_1.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SP_ASPNET_1.DbFiles.Contexts
{
    public class IceCreamBlogContext : IdentityDbContext<AppUser>
    {
        public IceCreamBlogContext() : base("name=IceCreamBlogDB")
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<ProductLine> ProductLines { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<IdentityDbContext>(null);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<SP_ASPNET_1.Models.AppRole> IdentityRoles { get; set; }
    }
}