using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCRUDOps.Shared
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        [Required]
        public string ProductCategory { get; set; }
        [Required]
        public double ProductPrice { get; set; }
        [Required]
        public double ProductQuantity { get; set; }
    }
}
