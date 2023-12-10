using Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace vezeeta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        [HttpGet("NumbersOfDoctor")]
        public async Task <IActionResult> GetNumOfDoctors()
        {
            var doctors = await _adminService.GetNumOfDoctors();
            return Ok(doctors);
        }
        [HttpGet("NumbersOfPatients")]
        public async Task<IActionResult> GetNumOfPatients()
        {
            var patients = await _adminService.GetNumOfPatients();
            return Ok(patients);
        }
        [HttpGet("NumbersOfRequests")]
        public async Task<IActionResult> GetNumberOfAppointmentRequests()
        {
            var requests = await _adminService.GetNumberOfAppointmentRequests();
            return Ok(requests);

        }
        [HttpGet("AllDoctors")]
        public async Task<IActionResult> GetAllDoctors(int page, int pageSize, string search)
        {
            var alldoctors = await _adminService.GetAllDoctors(page,page,search);
            return Ok(alldoctors);
        }
        [HttpGet("GetDoctor by id/{id}")]
        public async Task<IActionResult> GetDoctorById([FromRoute] int id)
        {
            var doctorbyid = await _adminService.GetDoctorById(id);
            if (doctorbyid == null)
            {
                return NotFound();
            }
            return Ok(doctorbyid);
        }
        [HttpPost("AddDoctor")]
        public async Task<IActionResult> AddDoctor(DoctorDto doctorDto)
        {
            var AddDoctor = await _adminService.AddDoctor(doctorDto);
            return Ok(AddDoctor);
        }
        [HttpPut("EditDoctor")]
        public async Task<IActionResult> EditDoctor(DoctorDto doctorDto)
        {
            var EditDoctor = await _adminService.EditDoctor(doctorDto);
            return Ok(EditDoctor);
        }
        [HttpDelete("deleteDoctor/{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var DeleteDoctor= await _adminService.DeleteDoctor(id);
            return Ok(DeleteDoctor);
        }
        [HttpGet("AllPatients")]
        public async Task<IActionResult> GetAllPatients(int page, int pageSize, string search)
        {
            var allpatients = await _adminService.GetAllDoctors(page, page, search);
            return Ok(allpatients);
        }
        [HttpGet("Get Patient by id/{id}")]
        public async Task<IActionResult> GetPatientById([FromRoute] int id)
        {
            var patientbyid = await _adminService.GetPatientById(id);
            if (patientbyid == null)
            {
                return NotFound();
            }
            return Ok(patientbyid);
        }
        [HttpPost("Add Code")]
        public async Task<IActionResult> AddDiscountCode(DiscountCodeDto discountCodeDto)
        {
            var addcode= await _adminService.AddDiscountCode(discountCodeDto);
            return Ok(addcode);
        }
        [HttpPut("Add Code")]
        public async Task<IActionResult>  UpdateDiscountCode(int id, DiscountCodeDto discountCodeDto)
        {
            var updatecode = await _adminService.UpdateDiscountCode(id,discountCodeDto);
            return Ok(updatecode);
        }
        [HttpDelete("deletecode/{id}")]
        public async Task<IActionResult> DeleteDiscountCode(int id)
        {
            var DeleteCode = await _adminService.DeleteDiscountCode(id);
            return Ok(DeleteCode);
        }
        [HttpDelete("DeactivateDiscountCode/{id}")]
        public async Task<IActionResult> DeactivateDiscountCode(int id)
        {
            var DeactivateCode = await _adminService.DeactivateDiscountCode(id);
            return Ok(DeactivateCode);
        }

    }
}
