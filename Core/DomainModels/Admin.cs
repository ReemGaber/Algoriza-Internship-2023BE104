using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Core.DomainModels
{
    public class Admin
    {
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string AdminEmail { get; set; }
        public string AdminPassword { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List< Patient> Patients { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<Discount> Discountcodes { get; set; }
    }
}
