using Microsoft.EntityFrameworkCore;

namespace diplom.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
           : base(options) => Database.EnsureCreated();   
        
            public virtual DbSet<RestaurantsModel> Restaurants { get; set; }
            public virtual DbSet<UserModel> Users { get; set; }
            public virtual DbSet<MenuModel> Menus { get; set; }
            public virtual DbSet<OrdersModel> Orders { get; set; }
  
    }
}
