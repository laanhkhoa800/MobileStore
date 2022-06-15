using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlogCoreAPI.Model
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public int StatusUserId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        [Required]
        public string Passwork { get; set; }
        public string NumberPhone { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool IsDelete { get; set; } = false;
        public string Roles { get; set; }

        public StatusUser StatusUser { get; set; }
       
        public ICollection<Order> Orders { get; set; }
    }
}
