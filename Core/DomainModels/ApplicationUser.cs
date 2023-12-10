using Core.Enum;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DomainModels
{
    internal class ApplicationUser:IdentityUser
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string email { get; set; }
        public Gender Gender { get; set; }
        public int ? age { get; set; }  



    }
}
