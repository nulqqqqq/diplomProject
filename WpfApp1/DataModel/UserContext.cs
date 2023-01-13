namespace WpfApp1
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;
    using System.Windows.Controls;

    public class UserContext : DbContext
    {
        public UserContext()
            : base("UserContext")
        {
        }

        public virtual DbSet<Restaurants> restaurants { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Orders> orders { get; set; }

    }

    public class User
    {
        [Key]
        public int UserModelId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }

    public class Restaurants
    {
        [Key]
        public int RestId { get; set; }

        public string RestName { get; set; }

        public string RestSourse { get; set; }

         
    }
    public class Menu
    {
        [Key]
        public int FoodId { get; set; }

        public string FoodName { get; set; }

        public int FoodCount { get; set; }

        public int RestId { get; set; }

        public double Price { get; set; }
    }
    public class Orders
    {
        [Key]
        public int IdOrder { get; set; }
        
        public int NumberOrd { get; set; }

        public int IdUser { get; set; }

        public int IdFood { get; set; }

        public string Adress { get; set; }
    }
}