using Application.Interfaces.Services;
using Application.Interfaces.UnitOfWork;
using AutoMapper;

namespace Services.Concretes
{
    public class AuthManager: IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


    }
}
