using EmployeeManagment.Data.Contracts;
using EmployeeManagment.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagment.Data.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmployeeManagmentContext _ctx;
        public UnitOfWork(EmployeeManagmentContext ctx)
        {
            _ctx = ctx;
            employeeLeaveAllocationRepository = new EmployeeLeaveAllocationRepository(_ctx);
            employeeLeaveRequestRepository = new EmployeeLeaveRequestRepository(_ctx);
            employeeLeaveTypeRepository = new EmployeeLeaveTypeRepository(_ctx);

        }

        public IEmployeeLeaveAllocationRepository employeeLeaveAllocationRepository { get; private set; }
        public IEmployeeLeaveRequestRepository employeeLeaveRequestRepository { get; private set; }
        public IEmployeeLeaveTypeRepository employeeLeaveTypeRepository { get; private set; }

        public void Save()
        {
            _ctx.SaveChanges();
        }


        public void Dispose()
        {
            _ctx.Dispose();
        }

        
    }
}
