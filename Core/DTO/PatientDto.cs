using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class PatientDto
    {
        public int Id {  get; set; }
        public string FullName { get; set; }
        public string? Password { get; set; }
        public Gender gender { get; set; }
        public DateTime birthdata { get; set; }
        public string email { get; set; }
        public String Phone { get; set; }
    }
}
