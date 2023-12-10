﻿using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IAdminRepository
    {
        Task<int> GetNumOfDoctors();
        Task<int> GetNumOfPatients();
        Task<dynamic> GetNumberOfAppointmentRequests();
        Task<dynamic> GetTopFiveSpecializations();
        Task<dynamic> GetTopTenDoctors();

       Task< List<DoctorDto>> GetAllDoctors(int page, int pageSize, string search);
       Task< DoctorDto> GetDoctorById(int id);
        Task<bool> AddDoctor(DoctorDto doctorDto);
        Task<bool> EditDoctor(DoctorDto doctorDto);
        Task<bool> DeleteDoctor(int id);

        Task<List<PatientDto>> GetAllPatients(int page, int pageSize, string search);
        Task<PatientDto> GetPatientById(int id);
        Task<bool> AddDiscountCode(DiscountCodeDto discountCodeDto);
        Task<bool> UpdateDiscountCode(int id, UpdateDiscountCodeDto discountCodeupdated);
        Task<bool> DeleteDiscountCode(int id);
        Task<bool> DeactivateDiscountCode(int id);

    }
}
