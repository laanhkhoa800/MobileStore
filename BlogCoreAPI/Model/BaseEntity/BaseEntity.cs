using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCoreAPI.Model.BaseEntity
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public bool IsDelete { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
    }
}
