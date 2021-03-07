using EmployeeManagment.Data.Contracts;
using EmployeeManagment.Data.DataContext;
using EmployeeManagment.Data.DbModels;

namespace EmployeeManagment.Data.Implementation
{
    public class EmployeeLeaveAllocationRepository : Repository<EmployeeLeaveAllocation>, IEmployeeLeaveAllocationRepository
    {
        private EmployeeManagmentContext _ctx;
        public EmployeeLeaveAllocationRepository(EmployeeManagmentContext ctx): base(ctx)
        {
            _ctx = ctx;
        }
    }
}
