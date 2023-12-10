using Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace vezeeta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] string email, string password)
        {
            bool isAuthenticated = await _doctorService.Login(email, password);

            if (isAuthenticated)
            {
                return Ok("Login successful");
            }

            return Unauthorized("Invalid email or password");
        }
        [HttpGet("{doctorId}/appointments")]
        public async Task<IActionResult> GetAllAppointmentsForDoctor(int doctorId, int pageSize, int pageNum, string searchBy)
        {
            var appointments = await _doctorService.GetAllBookingsForDoctor(doctorId, pageSize, pageNum, searchBy);
            return Ok(appointments);
        }
        [HttpPost("confirm-checkup/{bookingId}")]
        public async Task<IActionResult> ConfirmCheckup([FromBody] int bookingId)
        {
            bool isConfirmed = await _doctorService.confirmcheckup(bookingId);

            if (isConfirmed)
            {
                return Ok("Checkup confirmed successfully");

            }
            return BadRequest("Failed to confirm checkup");
        }

        [HttpPost("add-appointment")]
        public async Task<IActionResult> AddDoctorAppointment([FromBody] DoctorAppointementDto doctorAppointment)
        {

            bool appointmentAdded = await _doctorService.AddDoctorAppointement(doctorAppointment);

            if (appointmentAdded)
            {
                return Ok("Appointment added successfully");
            }

            return BadRequest("Failed to add appointment");
        }

        [HttpPut("updateAppointment")]
        public async Task<IActionResult> UpdateAppointment(int doctorId, int time)
        {
            bool appointmentUpdated = await _doctorService.UpdateDoctorAppointement(doctorId, time);

            if (appointmentUpdated)
            {
                return Ok("Appointment updated successfully");
            }

            return BadRequest("Failed to update appointment");
        }
        [HttpDelete("delete-appointment")]
        public async Task<IActionResult> DeleteDoctorAppointment(int doctorId, int time)
        {
            bool appointmentDeleted = await _doctorService.DeleteDoctorAppointement(doctorId, time);

            if (appointmentDeleted)
            {
                return Ok("Appointment deleted successfully");
            }

            return BadRequest("Failed to delete appointment");
        }  

    }
}