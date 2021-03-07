using System.ComponentModel.DataAnnotations;

namespace EmployeeManagment.Data.DbModels
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
