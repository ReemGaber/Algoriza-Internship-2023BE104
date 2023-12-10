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
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace Repository.Reposotries
{
    internal class PatientRepository : IPatientRepository
    {
        private readonly VezeetaDBContext _vezeetacontext;
        public PatientRepository(VezeetaDBContext vezeetacontext)
        {
            _vezeetacontext = vezeetacontext;
        }
        public async Task<bool> Register(PatientRegisterationDto patientRegisteration)
        {
            bool existpatient = await _vezeetacontext.Patients.AnyAsync(e => e.Email == patientRegisteration.Email);
            if (existpatient)
            {
                return false;
            }
            var newPatient = new Patient
            {
                Id = patientRegisteration.Id,
                FirstName = patientRegisteration.Firstname,
                LastName = patientRegisteration.Lastname,
                Email = patientRegisteration.Email,
                Phone = patientRegisteration.Phone,
                Birthdate = patientRegisteration.birthdate,
                Gender = patientRegisteration.Gender
            };
            _vezeetacontext.Patients.Add(newPatient);
            await _vezeetacontext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Login(string Email, string Password)
        {
            try
            {
                var patient = await _vezeetacontext.Patients.FirstOrDefaultAsync(e => e.Email == Email);
                if (patient != null && BCrypt.Net.BCrypt.Verify(Password, patient.Password)) ;
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
        public async Task<List<DoctorDto>> GetAllDoctors(int page, int pagezize, string searchby)
        {
            var doctors = await _vezeetacontext.Doctors
                .Where(d => d.id.Equals(searchby))
                .Skip((page - 1) * pagezize)
                .Take(pagezize)
                .Select(d => new DoctorDto
            {
                Id = d.id,
                FirstName = d.FirstName,
                LastName = d.LastName,
                Gender = d.Gender,
                Specializations = d.Specializations,
                price = d.price,
                Appointements = d.Appointements
            }).ToListAsync();
            return doctors;
        }

        public async Task<bool> BookAppointement(PatientbookingAppointemet booking)
        {
            var appointement = new Appointement
            {
                DoctorId = booking.DoctorId,
                DoctorName = booking.Doctorname,
                PatientId = booking.patientId,
                PatientName = booking.patientname,
                Date = booking.date,
                Day = booking.day,
                price = booking.price,
                Status = booking.status
            };
            _vezeetacontext.Appointments.Add(appointement);
            await _vezeetacontext.SaveChangesAsync();
            return true;
        }
        public async Task<List<AppointmentDto>> GetAllBookings(int patientId)
        {
            var appointement =await _vezeetacontext.Appointments
                .Where(b=>b.PatientId==patientId)
                .ToListAsync();

            var booking = appointement.Select(b => new AppointmentDto
            {
                DoctorName = $"{b.Doctor.FirstName} {b.Doctor.LastName}",
                day = b.Day,
                date = b.Date,
                totalprice = b.Price,
                Status = b.Status,
            }).ToList();
            return booking;

        }

        public async Task<bool> CancelBooking(int bookingid)
        {
            var cancel = await _vezeetacontext.Appointments.FirstOrDefaultAsync(c => c.AppointementId == bookingid);
            if (cancel == null)
            {
                return false;
            }
            cancel.Status = "cancelled";
            await _vezeetacontext.SaveChangesAsync();
            return true;
        }

      

       

       

       
    }
}
