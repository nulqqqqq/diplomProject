using System.ComponentModel.DataAnnotations;
using System;

namespace Diplom.Domain.Core
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