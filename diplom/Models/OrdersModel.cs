namespace diplom.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class OrdersModel
    {
        [Key]
        public int IdOrder { get; set; }

        public int NumberOrd { get; set; }

        public int IdUser { get; set; }

        public int IdFood { get; set; }

        public string Adress { get; set; }
    }
}
