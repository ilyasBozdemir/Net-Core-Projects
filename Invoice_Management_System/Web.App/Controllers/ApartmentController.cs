using Application.ViewModels.Apartment;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstracts;

namespace Web.App.Controllers
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
            if (result.Success)
            {
                IEnumerable<GetApartmentsViewModel> obj = _mapper.Map<IEnumerable<GetApartmentsViewModel>>(result.Data);
                return View(obj);
            }
            return BadRequest();
        }

       
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateApartmentViewModel createApartmentVM)
        {
            Apartment model = _mapper.Map<Apartment>(createApartmentVM);
            var result = _apartmentService.Create(model);
            SuccessAlert(result.Message);
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult Delete(Guid id)
        {
            var result = _apartmentService.Delete(id);
            if (result.Success)
            {
                SuccessAlert(result.Message);
                return RedirectToAction("Index");
            }
            DangerAlert(result.Message);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(Guid id)
        {
            var result = _apartmentService.GetById(id);
            if (result.Success)
            {
                UpdateApartmentViewModel model = _mapper.Map<UpdateApartmentViewModel>(result.Data);
                return View(model);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, UpdateApartmentViewModel model)
        {
            Apartment mapObj = _mapper.Map<Apartment>(model);
            var result = _apartmentService.Update(id, mapObj);
            if (result.Success)
            {
                SuccessAlert(result.Message);
                return RedirectToAction("Index");
            }
            DangerAlert(result.Message);
            return View();
        }
    }
}
