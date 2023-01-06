using System;
using System.ComponentModel.DataAnnotations;
namespace diplom.Models
{
    public class MenuModel
    {
        [Key]
        public int FoodId { get; set; }

        public string FoodName { get; set; }

        public int FoodCount { get; set; }

        public int RestId { get; set; }

        public double Price { get; set; }
    }
}
