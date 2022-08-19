using BusTicket.DataAccess.Infrastructure;
using BusTicket.DataAccess.Repositories;
using BusTicketBooking.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusTicketBookingApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BusController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BusController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult GetAllBus()
        {
            var bus = _unitOfWork.BusRepository.GetAll();
            return Json(new { data = bus });
        }

        public IActionResult CreateUpdate(int? id)
        {
            BusVm vm = new BusVm();

            if(id == null || id == 0)
            {
                return View(vm);
            }
            else
            {
                vm.Bus = _unitOfWork.BusRepository.GetFirstOrDefault(x => x.Id == id);
                if(vm.Bus ==  null)
                {
                    return NotFound();
                }
                else
                {
                    return View(vm);
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdate(BusVm vm)
        {
            if(ModelState.IsValid)
            {
                if(vm.Bus.Id == 0)
                {
                    _unitOfWork.BusRepository.Insert(vm.Bus);
                    TempData["success"] = "Bus Created Done!";
                }
                else
                {
                    _unitOfWork.BusRepository.Update(vm.Bus);
                    TempData["success"] = "Bus Update Done!";
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var bus = _unitOfWork.BusRepository.GetFirstOrDefault(x => x.Id == id);
            if(bus == null)
            {
                return Json(new { success = false, message = "Error in fetching data" });
            }
            else
            {
                _unitOfWork.BusRepository.Delete(bus);
                _unitOfWork.Save();
                return Json(new { success = true, message = "Bus Deleted" });
            }
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
