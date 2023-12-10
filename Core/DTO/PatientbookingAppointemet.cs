using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class PatientbookingAppointemet
    {
        public string name {  get; set; }
        public int patientId { get; set; }
        public string patientname { get; set; }
        public int DoctorId { get; set; }
        public string Doctorname { get; set; }
        public DateTime date { get; set; }
        public Days day { get; set; }
        public float price { get; set; }
        public string status { get; set; }  
        public string DiscountCode { get; set; }

    }
}
