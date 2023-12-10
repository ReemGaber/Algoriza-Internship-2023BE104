using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public  class DiscountCodeDto
    {
        public string code { get; set; }
        public int numofrequests { get; set; }
        public DiscountType DiscountType { get; set; }
        public String codevalue { get; set; }
        public int AdminId { get; set; }


    }
}
