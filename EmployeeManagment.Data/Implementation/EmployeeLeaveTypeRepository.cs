using EmployeeManagment.Data.Contracts;
using EmployeeManagment.Data.DataContext;
using EmployeeManagment.Data.DbModels;

namespace EmployeeManagment.Data.Implementation
{
    public class EmployeeLeaveTypeRepository : Repository<EmployeeLeaveType>, IEmployeeLeaveTypeRepository
    {
        private readonly EmployeeManagmentContext _ctx;
        public EmployeeLeaveTypeRepository(EmployeeManagmentContext ctx): base(ctx)
        {
            _ctx = ctx;
        }
    }
}
