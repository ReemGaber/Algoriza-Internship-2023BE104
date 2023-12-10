using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class UpdateDiscountCodeDto
    {
        public int id {  get; set; }
        public string code { get; set; }
        public int numofrequests { get; set; }
        public DiscountType DiscountType { get; set; }
        public float codevalue { get; set; }
    }
}
