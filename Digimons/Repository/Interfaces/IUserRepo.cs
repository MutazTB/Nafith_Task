using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IUserRepo
    {
        public Task Register(RegisterVM viewModel);

        public Task Login(LoginVM viewModel);

        public Task Logout();
    }
}