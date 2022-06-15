using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCoreAPI.Model
{
    public class Style
    {
        public int StyleId { get; set; }
        public string Name { get; set; }
        public bool IsDelete { get; set; } = false;
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }

    }
}
