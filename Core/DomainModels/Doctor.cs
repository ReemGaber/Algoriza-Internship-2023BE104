using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DomainModels
{
    public class Doctor
    {
        public int id   { get; set; }
        public string password { get; set; }
        public string Image { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime birthofdate { get; set; }
        public Admin Admin { get; set; }
        public int AdminId { get; set; }
        public List<Appointement> Appointements { get; set;}
        public List<Feedback> Feedbacks { get; set;}    
        public Specializations Specializations { get; set;}
        public int SpecializationsId { get; set;}
        public float price { get; set; }
        public ICollection<DoctorPatient> DoctorPatients { get; set; }
        public IEnumerable<DoctorSpecialization> DoctorSpecializations { get; set; }




    }
}
