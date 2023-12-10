using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DomainModels
{
    public class Specializations
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<DoctorSpecialization> DoctorSpecializations { get; set; }

    }
}

