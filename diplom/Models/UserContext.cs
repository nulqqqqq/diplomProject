using Microsoft.EntityFrameworkCore;

namespace diplom.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
           : base(options) => Database.EnsureCreated();   
        
            public virtual DbSet<RestaurantsModel> restaurants { get; set; }
            public virtual DbSet<UserModel> users { get; set; }
            public virtual DbSet<MenuModel> menu { get; set; }
            public virtual DbSet<OrdersModel> orders { get; set; }
  
    }
}
