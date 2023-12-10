using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DomainModels
{
    public class DoctorSpecialization
    {
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public int SpecializationId { get; set; }
        public Specializations Specialization { get; set; }
    }
}
