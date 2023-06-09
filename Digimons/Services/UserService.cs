using Domain.ViewModels;
using Repository.Interfaces;
using Services.Interfaces;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _UserRepo;
        public UserService(IUserRepo userRepo)
        {
            _UserRepo = userRepo;
        }

        public async Task Login(LoginVM login)
        {
            await _UserRepo.Login(login);
        }

        public async Task Register(RegisterVM register)
        {
            await _UserRepo.Register(register);
        }

        public async Task Logout()
        {
            await _UserRepo.Logout();
        }
    }
}
