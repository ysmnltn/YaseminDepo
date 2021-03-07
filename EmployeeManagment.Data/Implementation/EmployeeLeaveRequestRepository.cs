using EmployeeManagment.Data.Contracts;
using EmployeeManagment.Data.DataContext;
using EmployeeManagment.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagment.Data.Implementation
{
    public class EmployeeLeaveRequestRepository: Repository<EmployeeLeaveRequest>, IEmployeeLeaveRequestRepository
    {
        private readonly EmployeeManagmentContext _ctx;
        public EmployeeLeaveRequestRepository(EmployeeManagmentContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
