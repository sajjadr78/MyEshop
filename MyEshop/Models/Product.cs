using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyEshop.Models
{
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ItemId { get; set; }
        [MaxLength(6)]
        public string FileExtension { get; set; }

        public ICollection<CategoryToProduct> CategoryToProducts { get; set; }
        public Item Item { get; set; }


        public List<OrderDetail> OrderDetails { get; set; }

    }
}
