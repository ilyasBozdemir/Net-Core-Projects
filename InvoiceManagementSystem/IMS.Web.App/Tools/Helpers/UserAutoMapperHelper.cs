using AutoMapper;
using IMS.Core.Entities.Concretes;
using IMS.Entities.Concrete;
using IMS.Entities.DTOs;
using IMS.Web.App.Models.Apartment;
using IMS.Web.App.Models.ApartmentType;
using IMS.Web.App.Models.Auth;
using IMS.Web.App.Models.House;
using IMS.Web.App.Models.Invoice;
using IMS.Web.App.Models.InvoiceType;
using IMS.Web.App.Models.Payment;
using IMS.Web.App.Models.Resident;
using IMS.Web.App.Models.User;
using IMS.Web.App.Models.UserPanel;

namespace IMS.Web.App.Tools.Helpers
{
    public class UserAutoMapperHelper : Profile
    {
        public UserAutoMapperHelper()
        {
            CreateMap<Apartment, GetApartmentsViewModel>().ReverseMap();
            CreateMap<Apartment, GetApartmentViewModel>();
            CreateMap<Apartment, UpdateApartmentViewModel>();
            CreateMap<CreateApartmentViewModel, Apartment>();
            CreateMap<UpdateApartmentViewModel, Apartment>();

            CreateMap<ApartmentType, GetApartmentTypesViewModel>();
            CreateMap<ApartmentType, UpdateApartmentTypeViewModel>();

            CreateMap<CreateApartmentTypeViewModel, ApartmentType>();
            CreateMap<UpdateApartmentTypeViewModel, ApartmentType>();

            CreateMap<HouseDto, GetHousesDetailViewModel>();
            CreateMap<CreateHouseViewModel, House>();
            CreateMap<House, UpdateHouseViewModel>();
            CreateMap<UpdateHouseViewModel, House>();

            CreateMap<InvoiceType, GetInvoiceTypesViewModel>();
            CreateMap<InvoiceType, UpdateInvoiceTypeViewModel>();
            CreateMap<CreateInvoiceTypeViewModel, InvoiceType>();
            CreateMap<UpdateInvoiceTypeViewModel, InvoiceType>();

            CreateMap<ResidentDto, GetResidentsViewModel>();
            CreateMap<Resident, UpdateResidentViewModel>();
            CreateMap<CreateResidentViewModel, Resident>();
            CreateMap<UpdateResidentViewModel, Resident>();

            CreateMap<LoginViewModel, LoginDto>();
            CreateMap<RegisterViewModel, RegisterDto>();

            CreateMap<Invoice, GetInvoiceViewModel>();
            CreateMap<InvoiceDto, GetInvoicesViewModel>();
            CreateMap<Invoice, UpdateInvoiceViewModel>();
            CreateMap<CreateInvoiceViewModel, Invoice>();
            CreateMap<UpdateInvoiceViewModel, Invoice>();

            CreateMap<CreatePayOrderViewModel, PayOrderDto>();

            CreateMap<UserDto, GetUserViewModel>();
            CreateMap<UserDto, UpdateUserViewModel>();
            CreateMap<UpdateUserViewModel, User>();

            CreateMap<InvoiceDto, GetUserInvoicesViewModel>();
        }
    }
}
