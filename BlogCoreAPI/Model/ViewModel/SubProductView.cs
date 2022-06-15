using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCoreAPI.Model.ViewModel
{
    public class SubProductView
    {
        public int? SubProductId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int StatusId { get; set; }
    }
}
