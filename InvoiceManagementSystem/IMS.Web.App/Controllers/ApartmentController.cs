using AutoMapper;
using IMS.Business.Services.Abstracts;
using IMS.Core.Entities.Concretes;
using IMS.Entities.Concrete;
using IMS.Web.App.Models.Apartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IMS.Web.App.Controllers
{
    public class ApartmentController : BaseController
    {
        private readonly IApartmentService _apartmentService;
        private readonly IMapper _mapper;
        public ApartmentController(IApartmentService apartmentService, IMapper mapper)
        {
            _apartmentService = apartmentService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var result = _apartmentService.GetAll();
            if (result._success)
            {
                IEnumerable<GetApartmentsViewModel> obj = 
                    _mapper.Map<IEnumerable<GetApartmentsViewModel>>(result.Data);
                return View(obj);
            }
            return View();

        }

        [Authorize(Roles = OperationClaims.Admin)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = OperationClaims.Admin)]
        public IActionResult Create(CreateApartmentViewModel createApartmentVM)
        {
            Apartment model = _mapper.Map<Apartment>(createApartmentVM);
            var result = _apartmentService.Create(model);
            SuccessAlert(result._message);
            return Redirect(Request.Headers["Referer"].ToString());
        }

        [Authorize(Roles = OperationClaims.Admin)]
        public IActionResult Delete(int id)
        {
            var result = _apartmentService.Delete(id);
            if (result._success)
            {
                SuccessAlert(result._message);
                return RedirectToAction("Index");
            }
            DangerAlert(result._message);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = OperationClaims.Admin)]
        public IActionResult Edit(int id)
        {
            var result = _apartmentService.GetById(id);
            if (result._success)
            {
                UpdateApartmentViewModel model = _mapper.Map<UpdateApartmentViewModel>(result.Data);
                return View(model);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = OperationClaims.Admin)]
        public IActionResult Edit(int id, UpdateApartmentViewModel model)
        {
            Apartment mapObj = _mapper.Map<Apartment>(model);
            var result = _apartmentService.Update(id, mapObj);
            if (result._success)
            {
                SuccessAlert(result._message);
                return RedirectToAction("Index");
            }
            DangerAlert(result._message);
            return View();
        }
    }
}
