using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class DoctorAppointementDto
    {
        public int DoctorId { get; set; }
        public String DoctorName { get; set; }
        public int PatientId { get; set; }
        public String PatientName { get; set; }

        public DateTime Date { get; set; }
        public Days Day { get; set; }
        public float Price { get; set; }
     
    }
}
