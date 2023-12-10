using Core.DomainModels;
using Core.DTO;
using Core.Services;
using Core.Enum;
using Microsoft.EntityFrameworkCore;
using Repository.DbContextfolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Repository.Reposotries
{
    public class DiscountRepository : IDiscountCodeRepository
    {
        private readonly VezeetaDBContext _vezeetacontext;
        public DiscountRepository(VezeetaDBContext vezeetacontext)
        {
            _vezeetacontext = vezeetacontext;
        }
        public async Task<bool> AddCode(DiscountCodeDto AddDiscount)
        {
            var addedcode = new Discount
            {
                code = AddDiscount.code,
                Completetdrequests = AddDiscount.numofrequests,
                type = AddDiscount.DiscountType,
                AdminId = AddDiscount.AdminId

            };
            _vezeetacontext.DiscountCodes.Add(addedcode);
            await _vezeetacontext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateCode(UpdateDiscountCodeDto UpdateDiscount)
        {
            var updatedcode = await _vezeetacontext.DiscountCodes.FindAsync(UpdateDiscount.id);
            if (updatedcode == null)
            {
                return false;
            }
            updatedcode.code = UpdateDiscount.code;
            updatedcode.Completetdrequests = UpdateDiscount.numofrequests;
            updatedcode.type = UpdateDiscount.DiscountType;

            _vezeetacontext.DiscountCodes.Update(updatedcode);
            await _vezeetacontext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteCode(int id)
        {
            var Deletedcode = await _vezeetacontext.DiscountCodes.FindAsync(id);
            if (Deletedcode == null)
            {
                return false;
            }
            _vezeetacontext.DiscountCodes.Remove(Deletedcode);
            await _vezeetacontext.SaveChangesAsync();
            return true;


        }
        public async Task<bool> DeactivateCode(int id)
        {

            var Deactivatedcode = await _vezeetacontext.DiscountCodes.FindAsync(id);
            if (Deactivatedcode == null)
            {
                return false;
            }
            Deactivatedcode.IsActive = false;
            _vezeetacontext.DiscountCodes.Update(Deactivatedcode);
            await _vezeetacontext.SaveChangesAsync();
            return true;
        }

        


    }
}
