using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IPatientService
    {
        Task<bool> Register(PatientRegisterationDto patientRegisteration);
        Task<bool> Login(String Email, String Password);
        Task<List<DoctorDto>> GetAllDoctors(int page, int pagezize, string searchby);
        Task<bool> BookAppointement(PatientbookingAppointemet booking);
        Task<List<AppointmentDto>> GetAllBookings(int patientId);
        Task<bool> CancelBooking(int bookingid);
    }
}
