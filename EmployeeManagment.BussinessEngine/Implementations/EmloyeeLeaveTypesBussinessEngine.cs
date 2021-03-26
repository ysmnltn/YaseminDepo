using AutoMapper;
using EmployeeManagment.BussinessEngine.Contracts;
using EmployeeManagment.BussinessEngine.ResultModels;
using EmployeeManagment.Common.VModels;
using EmployeeManagment.Data.Contracts;
using EmployeeManagment.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeManagment.BussinessEngine.Implementations
{
    public class EmloyeeLeaveTypesBussinessEngine : IEmloyeeLeaveTypesBussinessEngine
    {
        #region Properties
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor
        public EmloyeeLeaveTypesBussinessEngine(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }


        public Result<List<EmployeeLeaveTypeVM>> GetAllEmployeeLeaveTypes()
        {
            var data = _unitOfWork.employeeLeaveTypeRepository.GetAll(e => e.IsActive == true).ToList();

            #region 1.Yöntem

            //if (data != null)
            //{
            //    List<EmployeeLeaveType> _returnData = new List<EmployeeLeaveType>();
            //    foreach (var item in data)
            //    {
            //        _returnData.Add(new EmployeeLeaveType
            //        {
            //            Id = item.Id,
            //            Name = item.Name,
            //            DateCreated = item.DateCreated,
            //            DefaultDays = item.DefaultDays
            //        });
            //    }

            //    return new Result<List<EmployeeLeaveType>>(true, "İşlem başarılı!", _returnData);
            //}
            //else
            //{
            //    return new Result<List<EmployeeLeaveType>>(false, "İşlem başarısız");
            //} 
            #endregion

            #region 2.Yöntem
            var leaveTypes = _mapper.Map<List<EmployeeLeaveType>, List<EmployeeLeaveTypeVM>>(data);
            return new Result<List<EmployeeLeaveTypeVM>>(true, "İşlem başarılı!", leaveTypes); 
            #endregion


        }
        #endregion


        /// <summary>
        /// Yeni izin tipi oluştur
        /// </summary>
        /// <param name="employeeLeaveTypeVM"></param>
        /// <returns></returns>
        public Result<EmployeeLeaveTypeVM> CreateEmployeeLeaveType(EmployeeLeaveTypeVM employeeLeaveTypeVM)
        {

            if (employeeLeaveTypeVM != null)
            {
                try
                {
                    var leaveType = _mapper.Map<EmployeeLeaveTypeVM, EmployeeLeaveType>(employeeLeaveTypeVM);
                    leaveType.DateCreated = DateTime.Now;
                    leaveType.IsActive = true;
                    _unitOfWork.employeeLeaveTypeRepository.Add(leaveType);
                    _unitOfWork.Save();
                    return new Result<EmployeeLeaveTypeVM>(true, "Kayıt başarıyla gerçekleşti!");
                }
                catch (Exception ex)
                {
                    return new Result<EmployeeLeaveTypeVM>(false, "Kayıt işlemi yapılırken bir hata oluştu" + "=>" + ex.Message);
                }
                
            }
            else
            {
                return new Result<EmployeeLeaveTypeVM>(false, "Lütfen zorunlu alanları doldurun!");
            }
        }

        public Result<EmployeeLeaveTypeVM> GetEmployeeLeaveType(int id)
        {
            var data = _unitOfWork.employeeLeaveTypeRepository.Get(id);
            if (data != null)
            {
                var leaveType = _mapper.Map<EmployeeLeaveType, EmployeeLeaveTypeVM>(data);
                return new Result<EmployeeLeaveTypeVM>(true, "Kayıt işlemi başarıyla gerçekleşti", leaveType);

            }
            else
            {
                return new Result<EmployeeLeaveTypeVM>(true, "Kayıt işlemi yapılırken bir hata oluştu");

            }
        }

        public Result<EmployeeLeaveTypeVM> EditEmployeeLeaveType(EmployeeLeaveTypeVM employeeLeaveTypeVM)
        {
            if (employeeLeaveTypeVM != null)
            {
                try
                {
                    var leaveType = _mapper.Map<EmployeeLeaveTypeVM, EmployeeLeaveType>(employeeLeaveTypeVM);
                    _unitOfWork.employeeLeaveTypeRepository.Update(leaveType);
                    _unitOfWork.Save();
                    return new Result<EmployeeLeaveTypeVM>(true, "Kayıt başarıyla gerçekleşti!");
                }
                catch (Exception ex)
                {
                    return new Result<EmployeeLeaveTypeVM>(false, "Kayıt işlemi yapılırken bir hata oluştu" + "=>" + ex.Message);
                }

            }
            else
            {
                return new Result<EmployeeLeaveTypeVM>(false, "Lütfen zorunlu alanları doldurun!");
            }
        }

        public Result<EmployeeLeaveTypeVM> RemoveEmployeeLeaveType(int id)
        {
            var data = _unitOfWork.employeeLeaveTypeRepository.Get(id);
            if (data != null)
            {
                data.IsActive = false;
                _unitOfWork.employeeLeaveTypeRepository.Update(data);
                _unitOfWork.Save();
                return new Result<EmployeeLeaveTypeVM>(true, "Kayıt silindi!");
            }
            else
            {
                return new Result<EmployeeLeaveTypeVM>(true, "Kayıt silinirken bir hata oluştu!");

            }
        }
    }
}
