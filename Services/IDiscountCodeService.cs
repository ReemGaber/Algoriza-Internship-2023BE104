using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IDiscountCodeService
    {
        Task<bool> AddCode(DiscountCodeDto AddDiscount);
        Task<bool> UpdateCode(UpdateDiscountCodeDto UpdateDiscount);
        Task<bool> DeleteCode(int id);
        Task<bool> DeactivateCode(int id);
    }
}
