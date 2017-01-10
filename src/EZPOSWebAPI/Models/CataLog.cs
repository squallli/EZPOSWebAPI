using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EZPOSWebAPI.Models
{
    public class CataLog
    {
        [Key]
        [MaxLength(3)]
        public string CataLogId { set; get; }

        [MaxLength(20)]
        public string CataLogName { set; get; }
    }
}
