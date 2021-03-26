using EmployeeManagment.BussinessEngine.Contracts;
using EmployeeManagment.Common.VModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.UI.Controllers
{
    public class EmployeeLeaveTypesController : Controller
    {
        private IEmloyeeLeaveTypesBussinessEngine _emloyeeLeaveTypesBussinessEngine;
        public EmployeeLeaveTypesController(IEmloyeeLeaveTypesBussinessEngine emloyeeLeaveTypesBussinessEngine)
        {
            _emloyeeLeaveTypesBussinessEngine = emloyeeLeaveTypesBussinessEngine;
        }
        public IActionResult Index()
        {
            var data = _emloyeeLeaveTypesBussinessEngine.GetAllEmployeeLeaveTypes();
            if (data.IsSuccess)
            {
                var result = data.Data;
                return View(result);
            }
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeLeaveTypeVM employeeLeaveTypeVM)
        {
            if (ModelState.IsValid)
            {
                var data = _emloyeeLeaveTypesBussinessEngine.CreateEmployeeLeaveType(employeeLeaveTypeVM);
                if (data.IsSuccess)
                {
                    return RedirectToAction("Index");

                }
                return View(employeeLeaveTypeVM);
            }
            else
            {
                return View(employeeLeaveTypeVM);

            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id < 0)
            {
                return View();
            }

            var data = _emloyeeLeaveTypesBussinessEngine.GetEmployeeLeaveType(id);
            if (data.IsSuccess)
            {
                return View(data.Data);
            }
            return View(data.Data);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(EmployeeLeaveTypeVM employeeLeaveTypeVM)
        {
            if (ModelState.IsValid)
            {
                var data = _emloyeeLeaveTypesBussinessEngine.EditEmployeeLeaveType(employeeLeaveTypeVM);
                if (data.IsSuccess)
                {
                    return RedirectToAction("Index");

                }
                return View(employeeLeaveTypeVM);
            }
            else
            {
                return View(employeeLeaveTypeVM);

            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return Json(new { success = false, message = "Silmek için lütfen bir kayıt seçin" });
            }

            var data = _emloyeeLeaveTypesBussinessEngine.RemoveEmployeeLeaveType(id);
            if (data.IsSuccess)
            {
                return Json(new { success = data.IsSuccess, message = data.Message });
            }
            else
            {
                return Json(new { success = data.IsSuccess, message = data.Message });
            }

        }
    }
}
