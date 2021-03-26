using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagment.BussinessEngine.ResultModels
{
    public interface IResult
    {
        bool IsSuccess { get; set; }
        string Message { get; set; }
    }
}
