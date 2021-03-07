using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagment.Common.VModels
{
    public class EmployeeVM
    {
        public string Id { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        public string User { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TaxId { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
