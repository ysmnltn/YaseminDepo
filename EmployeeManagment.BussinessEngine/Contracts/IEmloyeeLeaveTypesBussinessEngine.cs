using EmployeeManagment.BussinessEngine.ResultModels;
using EmployeeManagment.Common.VModels;
using EmployeeManagment.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagment.BussinessEngine.Contracts
{
    public interface IEmloyeeLeaveTypesBussinessEngine
    {
        Result<List<EmployeeLeaveTypeVM>> GetAllEmployeeLeaveTypes();
        Result<EmployeeLeaveTypeVM> CreateEmployeeLeaveType(EmployeeLeaveTypeVM employeeLeaveTypeVM);

        Result<EmployeeLeaveTypeVM> GetEmployeeLeaveType(int id);
        Result<EmployeeLeaveTypeVM> EditEmployeeLeaveType(EmployeeLeaveTypeVM employeeLeaveTypeVM);
        Result<EmployeeLeaveTypeVM> RemoveEmployeeLeaveType(int id);



    }
}
