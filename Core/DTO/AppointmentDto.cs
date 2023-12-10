using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class AppointmentDto
    {
        public string name {  get; set; }
        public string DoctorName { get; set; }
        public string Specialization { get; set; }
        public Days day { get; set; }
        public DateTime date { get; set; }
        public int time { get; set; }
        public string Discount {  get; set; }
        public string Status { get; set; }
        public float totalprice {  get; set; }
        
    }
}
