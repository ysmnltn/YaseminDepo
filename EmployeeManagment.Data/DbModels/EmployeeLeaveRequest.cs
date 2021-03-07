using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeeManagment.Data.DbModels
{
    public class EmployeeLeaveRequest : BaseEntity
    {
        //istekte bullanan kullanıcı
        public string RequestEmployeeId { get; set; }
        [ForeignKey("RequestEmployeeId")]
        public Employee RequestEmployee { get; set; }

        //onaylayan  kullanıcı
        public string ApprovedEmployeeId { get; set; }
        [ForeignKey("ApprovedEmployeeId")]
        public Employee ApprovedEmployee { get; set; }

        //kullanıcı izin tipi ile başvuracak
        public int EmployeeLeaveTypeId { get; set; }
        [ForeignKey("EmployeeLeaveTypeId")]
        public EmployeeLeaveType EmployeeLeaveType { get; set; }

        //----------------------------------------------------

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DateRequest { get; set; }
        public string RequestComment { get; set; }
        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }

    }
}
