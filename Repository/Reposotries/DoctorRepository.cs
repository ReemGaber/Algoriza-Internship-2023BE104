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
using BCrypt.Net;

namespace Repository.Reposotries
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly VezeetaDBContext _vezeetacontext;
        public DoctorRepository(VezeetaDBContext vezeetacontext)
        {
            _vezeetacontext = vezeetacontext;
        }
        public async Task<bool> Login(string Email, string Password)
        {
            try
            {
                var doctor = await _vezeetacontext.Doctors.FirstOrDefaultAsync(e => e.Email == Email);
                if (doctor != null && BCrypt.Net.BCrypt.Verify(Password, doctor.password)) ;
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }
        public async Task<List<AppointmentDto>> GetAllBookingsForDoctor(int DoctorId, int pageSize, int PageNum, string searchby)
        {
            try
            {
                var doctor = await _vezeetacontext.Doctors.FirstOrDefaultAsync(e => e.id == DoctorId);
                var listofappointements = await _vezeetacontext.Appointments
                 .Where(a => a.DoctorId == DoctorId && (string.IsNullOrEmpty(searchby)))
                 .Skip((PageNum - 1) * pageSize)
                 .Take(pageSize)
                 .Select(a => new AppointmentDto
                 {
                     DoctorName = $"{doctor.FirstName} {doctor.LastName}",
                     day = a.Day,
                     date = a.Date,
                     totalprice = a.Price
                 })
                 .ToListAsync();
                return listofappointements;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\"An error occurred while fetching appointments: {ex.Message}");
                throw;
            }
        }
        public async Task<bool> confirmcheckup(int BookingId)
        {
            var check = await _vezeetacontext.Appointments.FirstOrDefaultAsync(c => c.AppointementId == BookingId);
            if (check == null)
            {
                return false;
            }
            check.Status = "Confirm";
            await _vezeetacontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddDoctorAppointement(DoctorAppointementDto doctorapoointement)
        {
            var addappointement = new Appointement
            {
                DoctorId = doctorapoointement.DoctorId,
                DoctorName= doctorapoointement.DoctorName,
                PatientId = doctorapoointement.PatientId,
                PatientName= doctorapoointement.PatientName,
                Day = doctorapoointement.Day,
                Date = doctorapoointement.Date,
                price = doctorapoointement.Price,

            };
            _vezeetacontext.Appointments.Add(addappointement);
            await _vezeetacontext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateDoctorAppointement(int DoctorId, int time)
        {
            var updateappointement= await _vezeetacontext.Appointments.FirstOrDefaultAsync(u=>u.DoctorId == DoctorId&& u.time==time);
            if (updateappointement==null)
            {
                return false;
            }
            updateappointement.Status = "upadte_successflly";
            await _vezeetacontext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteDoctorAppointement(int DoctorId, int time)
        {

            var Deleteappointement = await _vezeetacontext.Appointments.FirstOrDefaultAsync(u => u.DoctorId == DoctorId && u.time == time);
            if (Deleteappointement == null)
            {
                return false;
            }
            _vezeetacontext.Appointments.Remove(Deleteappointement);
            Deleteappointement.Status = "Deleted_successflly";
            await _vezeetacontext.SaveChangesAsync();
            return true;
        }
       
    }
}
