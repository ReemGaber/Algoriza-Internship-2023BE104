using Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.DomainModels
{
    public class Patient
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string? Password { get; set; }
        public Gender Gender { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Birthdate { get; set; }
        public List<Feedback> Feedbacks { get; set; }
        public Admin Admin { get; set; }
        public int AdminId { get; set; }
        public List<Appointement> Appointments { get; set; }
        public List<Discount> DiscountCodes { get; set; }
        public ICollection<DoctorPatient> DoctorPatients { get; set; }
       

    }
}
