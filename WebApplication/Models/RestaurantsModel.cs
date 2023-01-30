using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class RestaurantsModel
    {
        [Key]
        public int RestId { get; set; }

        public string? RestName { get; set; }

        public string? RestSourse { get; set; }

    }
}
