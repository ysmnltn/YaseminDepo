using AutoMapper;
using EmployeeManagment.Common.VModels;
using EmployeeManagment.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagment.Common.Mapping
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<EmployeeLeaveType, EmployeeLeaveTypeVM>().ReverseMap();
            CreateMap<EmployeeLeaveAllocation, EmplooyeLeaveAllocationVM>().ReverseMap();
            CreateMap<EmployeeLeaveRequest, EmployeeLeaveRequestVM>().ReverseMap();
            CreateMap<Employee, EmployeeVM>().ReverseMap();
        }
    }
}
