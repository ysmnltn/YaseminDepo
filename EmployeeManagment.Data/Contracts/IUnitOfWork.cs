using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagment.Data.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
