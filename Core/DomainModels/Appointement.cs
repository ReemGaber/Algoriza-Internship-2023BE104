using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DomainModels
{
    public class Appointement
    {
        public int AppointementId { get; set; }
        public float Price { get; set; }
        public DateTime Date { get; set; }
        public Days Day { get; set; }
        public Doctor Doctor { get; set; }
        public string DoctorName { get; set; }
        public int DoctorId { get; set; }

        public float price { get; set; }
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        public string PatientName{ get; set; }
        public string Status { get; set; }
        public int DiscountId { get; set; }
        public int time { get; set; }
        public Discount Discount { get; set; }

    }
}
