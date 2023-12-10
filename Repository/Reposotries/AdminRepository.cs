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
    internal class AdminRepository : IAdminRepository
    {
        private readonly VezeetaDBContext _vezeetacontext;
        public AdminRepository(VezeetaDBContext vezeetacontext)
        {
            _vezeetacontext=vezeetacontext;
        }

        public async Task<int> GetNumOfDoctors()
        {
            var NumOfDoctors=await _vezeetacontext.Doctors.CountAsync();
            return NumOfDoctors;
        }
        public async Task<int> GetNumOfPatients()
        {
            var NumOfPatients = await _vezeetacontext.Patients.CountAsync();
            return NumOfPatients;
        }
        public async Task<dynamic> GetNumberOfAppointmentRequests()
        {
            var NumberOfAppointmentRequests = await _vezeetacontext.Appointments.CountAsync();
            var NumberOfPendingRequests = await _vezeetacontext.Appointments.CountAsync(p => p.Status == "Pending");
            var NumberOfCompletedRequests = await _vezeetacontext.Appointments.CountAsync(c => c.Status == "complete");
            var NumberOfCancelledRequests = await _vezeetacontext.Appointments.CountAsync(c => c.Status == "cancel");

            var allrequests = new
            {
                NumberOfAppointment = NumberOfAppointmentRequests,
                NumberOfPending = NumberOfPendingRequests,
                NumberOfCompleted = NumberOfCompletedRequests,
                NumberOfCancelled = NumberOfCancelledRequests
            };
            return allrequests;
        }
        public  async Task<dynamic> GetTopFiveSpecializations()
        {
            var TopFiveSpecializations = await _vezeetacontext.Specializations
                  .OrderByDescending(s => s.Doctors.SelectMany(a => a.Appointements).Count()).Take(5)
                  .Select(s=>s.Name).ToListAsync();
            return TopFiveSpecializations;
        }
        public  async Task<dynamic> GetTopTenDoctors()
        {
           var topdoctors = await  _vezeetacontext.Doctors
             .OrderByDescending(d => d.Appointements.Count())
                    .Take(10)
                    .Select(d => new
                    {
                        FullName = d.FirstName + " " + d.LastName,
                        NumberOfAppointments = d.Appointements.Count()
                    })
                    .ToListAsync();
            return topdoctors;
        }
        public async Task<List<DoctorDto>> GetAllDoctors(int page, int pageSize, string search)
        {
            var query = _vezeetacontext.Doctors
                .Where(a => String.IsNullOrEmpty(search) ||
                a.FirstName.Contains(search) ||
                a.LastName.Contains(search) ||
                a.Email.Contains(search) ||
                a.Phone.Contains(search));
               

            var listofDoctors = await query.OrderBy(d => d.id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(d => new DoctorDto
                {
                    Id = d.id,
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    Email = d.Email,
                    Gender = d.Gender,
                    Specializations = d.Specializations
                })
                .ToListAsync();
            return listofDoctors;
        }
        public async Task<DoctorDto> GetDoctorById(int id)
        {
            var doctor = await _vezeetacontext.Doctors
             .Where(d => d.id == id)
             .Select(d => new DoctorDto
             {
                 Id = d.id,
                 FirstName = d.FirstName,
                 LastName = d.LastName,
                 Email = d.Email,
                 Gender = d.Gender,
                 Specializations = d.Specializations
             }).FirstOrDefaultAsync();
            if (doctor==null)
            {
                return null;
            }
            return doctor;
        }
        public async Task<bool> AddDoctor(DoctorDto doctorDto)
        {
            var newdoctor = new Doctor
            {
                FirstName = doctorDto.FirstName,
                LastName = doctorDto.LastName,
                Email = doctorDto.Email,
                Phone = doctorDto.Phone,
                Gender = doctorDto.Gender,
                Specializations = doctorDto.Specializations,
                birthofdate = doctorDto.birthofdate
            };
            _vezeetacontext.Doctors.Add(newdoctor);
            await _vezeetacontext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> EditDoctor(DoctorDto doctorDto)
        {
            var doctor = await _vezeetacontext.Doctors.FindAsync(doctorDto.Id);

            if (doctor != null)
            { 
                doctor.FirstName = doctorDto.FirstName;
                doctor.LastName = doctorDto.LastName;
                doctor.Email = doctorDto.Email;
                doctor.Phone = doctorDto.Phone;
                doctor.Gender = doctorDto.Gender;
                doctor.Specializations = doctorDto.Specializations;
                doctor.birthofdate = doctorDto.birthofdate;

                _vezeetacontext.Doctors.Update(doctor);
              
                await _vezeetacontext.SaveChangesAsync();
                return true;  
            }
            else return false;
        }
        public async Task<bool> DeleteDoctor(int id)
        {
            var doctor = await _vezeetacontext.Doctors.FindAsync(id);
            if (doctor != null)
            {
                return true;
            }
            if (_vezeetacontext.Appointments.Any(appointment => appointment.DoctorId == id))
            {
                return false;
            }
            _vezeetacontext.Doctors.Remove(doctor);
            await _vezeetacontext.SaveChangesAsync();
            return true;
        }
        public async Task<List<PatientDto>> GetAllPatients(int page, int pageSize, string search)
        {
            var query = _vezeetacontext.Patients
                .Where(a => String.IsNullOrEmpty(search) ||
                a.FirstName.Contains(search) ||
                a.LastName.Contains(search) ||
                a.Email.Contains(search) ||
                a.Phone.Contains(search));

            var listofPatients = await query.OrderBy(d => d.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new PatientDto
                {
                    Id = p.Id,
                    FullName = p.FirstName + " " + p.LastName,
                    email = p.Email,
                    Phone = p.Phone,
                    gender = p.Gender,
                    birthdata = p.Birthdate

                }).ToListAsync();
            return listofPatients;
        }
        public async Task<PatientDto> GetPatientById(int id)
        {
            var patient = await _vezeetacontext.Patients.FindAsync(id);
            var PatientById = new PatientDto
            {
                Id = patient.Id,
                FullName = patient.FirstName + " " + patient.LastName,
                email = patient.Email,
                Phone = patient.Phone,
                gender = patient.Gender,
                birthdata = patient.Birthdate
            };
            return PatientById;
        }
        public async Task<bool> AddDiscountCode(DiscountCodeDto discountCodeDto)
        {
            var newcode = new Discount
            {
                code = discountCodeDto.code,
                Completetdrequests = discountCodeDto.numofrequests,
                type = discountCodeDto.DiscountType

            };
            if (await _vezeetacontext.DiscountCodes.AnyAsync(dc => dc.code == discountCodeDto.code))
            { 
                return false;
            }
            _vezeetacontext.DiscountCodes.Add(newcode);
            await _vezeetacontext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateDiscountCode(int id, UpdateDiscountCodeDto discountCodeupdated)
        {
            var code = await _vezeetacontext.DiscountCodes.FindAsync(discountCodeupdated.id);
            if (code==null )
            {
                return false;
            }
            code.code=discountCodeupdated.code;
            code.Completetdrequests = discountCodeupdated.numofrequests;
            code.codevalue = discountCodeupdated.codevalue;
            await _vezeetacontext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteDiscountCode(int id)
        {
            var code = await _vezeetacontext.DiscountCodes.FindAsync(id);
            if (code == null)
            {
                return false;
            }
            if (_vezeetacontext.Appointments.Any(appointment => appointment.DiscountId == id))
            {
                return false;
            }
            _vezeetacontext.DiscountCodes.Remove(code);
            await _vezeetacontext.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeactivateDiscountCode(int id)
        {
            var code = await _vezeetacontext.DiscountCodes.FindAsync(id);
            if (code == null)
            {
                return false;
            }
            code.IsActive = false;
            _vezeetacontext.DiscountCodes.Update(code);
            await _vezeetacontext.SaveChangesAsync();
            return true;
        }

       
      

        

       
    }
}
