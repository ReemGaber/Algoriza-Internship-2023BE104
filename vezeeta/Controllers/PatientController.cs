using Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace vezeeta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] PatientRegisterationDto patientRegistration)
        {

            bool registrationSuccess = await _patientService.Register(patientRegistration);

            if (registrationSuccess)
            {
                return Ok("Patient registered successfully");
            }

            return BadRequest("Failed to register patient");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] string email, string password)
        {
            bool isAuthenticated = await _patientService.Login(email, password);

            if (isAuthenticated)
            {
                return Ok("Login successful");
            }

            return Unauthorized("Invalid email or password");
        }
        [HttpGet("doctors")]
        public async Task<IActionResult> GetAllDoctors(int page, int pageSize, string searchBy)
        {

            var doctors = await _patientService.GetAllDoctors(page, pageSize, searchBy);
            return Ok(doctors);
        }
        [HttpPost("book-appointment")]
        public async Task<IActionResult> BookAppointment( [FromBody] PatientbookingAppointemet booking)
        {

            bool appointmentBooked = await _patientService.BookAppointement(booking);

            if (appointmentBooked)
            {
                return Ok("Appointment booked successfully");
            }

            return BadRequest("Failed to book appointment");
        }
        [HttpGet("bookings/{patientId}")]
        public async Task<IActionResult> GetAllBookings( [FromBody] int patientId)
        {
            var bookings = await _patientService.GetAllBookings(patientId);
            return Ok(bookings);
        }
        [HttpDelete("cancel-booking/{bookingId}")]
        public async Task<IActionResult> CancelBooking([FromBody] int bookingId)
        {
            bool bookingCanceled = await _patientService.CancelBooking(bookingId);

            if (bookingCanceled)
            {
                return Ok("Booking canceled successfully");
            }

            return BadRequest("Failed to cancel booking");

        }
    }
}
