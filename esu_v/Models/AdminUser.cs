using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace esu_v.Models
{
    public class AdminUser : IdentityUser
    {
        public string Gender { get; set; }
    }
}
