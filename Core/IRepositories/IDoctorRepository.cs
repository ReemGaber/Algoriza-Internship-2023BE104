using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IDoctorRepository
    {
        Task<bool> Login(String Email,String Password);
        Task<List<AppointmentDto>> GetAllBookingsForDoctor(int DoctorId,int pageSize,int PageNum , string searchby);
        Task<bool> confirmcheckup(int BookingId);
        Task<bool> AddDoctorAppointement(DoctorAppointementDto doctorapoointement);
        Task<bool> UpdateDoctorAppointement(int DoctorId,int time);
         Task<bool> DeleteDoctorAppointement(int DoctorId, int time);
    }
}
