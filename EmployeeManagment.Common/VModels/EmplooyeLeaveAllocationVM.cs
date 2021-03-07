using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagment.Common.VModels
{
    public class EmplooyeLeaveAllocationVM : BaseVM
    {
        public int NumberOfDays { get; set; }
        public DateTime DateCreated { get; set; }
        public int Period { get; set; }

        public string EmployeeId { get; set; }
        public EmployeeVM Employee { get; set; }


        public int EmployeeLeaveTypeId { get; set; }
        public EmployeeLeaveTypeVM EmployeeLeaveType { get; set; }
    }
}
