using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EZPOSWebAPI.Models
{
    public class Inventory
    {
        [Key]
        public string ProductNo { set; get; }

        [MaxLength(200)]
        public string Desc { set; get; }

        public byte[] Img { set; get; }

        [MaxLength(50)]
        public string ProductName { set; get; }

        public int SaleQty { set; get; }

        public int StartQty { set; get; }

        public float UnitPrice { set; get; }

        public string CatalogId { set; get; }
    }
}
