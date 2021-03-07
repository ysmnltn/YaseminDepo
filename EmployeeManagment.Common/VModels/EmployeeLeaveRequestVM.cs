using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeManagment.Common.VModels
{
    public class EmployeeLeaveRequestVM : BaseVM
    {
        //istekte bullanan kullanıcı
        public string RequestEmployeeId { get; set; }
        public EmployeeVM RequestEmployee { get; set; }

        //onaylayan  kullanıcı
        public string ApprovedEmployeeId { get; set; }
        public EmployeeVM ApprovedEmployee { get; set; }

        //kullanıcı izin tipi ile başvuracak
        public int EmployeeLeaveTypeId { get; set; }
        public EmployeeLeaveTypeVM EmployeeLeaveType { get; set; }

        //----------------------------------------------------

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DateRequest { get; set; }
        [Display(Name = "Talep Açıklama")]
        [MaxLength(300,ErrorMessage = "300 karakterden fazla değer girilemez!")]
        public string RequestComment { get; set; }
        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }
    }
}
