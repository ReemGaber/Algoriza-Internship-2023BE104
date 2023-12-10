using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class PatientRegisterationDto
    {
        public int Id { get; set; }
        public String Image {  get; set; }
        public String Firstname { get; set; }
        public String Lastname { get; set; }
        public string Email { get; set; }
        public String Phone {  get; set; }
        public Gender Gender { get; set; }
        public DateTime birthdate { get; set; }

    }
}
