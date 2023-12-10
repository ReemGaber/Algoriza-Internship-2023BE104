using Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DomainModels
{
    public class Discount
    {
        public int id {  get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public bool IsActive { get; set; }
        public DiscountType type { get; set; }
        public float codevalue {  get; set; }
        public int Completetdrequests { get; set; }
        public Admin Admin { get; set; }
        public int AdminId { get; set; }
        public List<Appointement> Appointments { get; set; }
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
       

    }
}
