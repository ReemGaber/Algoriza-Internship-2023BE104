using Core.DomainModels;
using Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class DoctorDto
    {
        public int Id {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime birthofdate { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }   
        public float price { get; set; }
        public string password { get; set; }
        [Required]
        public Specializations Specializations { get; set; }
        public List<Appointement> Appointements { get; set; }

        
    }
}
