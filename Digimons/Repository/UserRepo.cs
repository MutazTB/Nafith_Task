using Domain.ViewModels;
using Domain;
using Microsoft.AspNetCore.Identity;
using Repository.Interfaces;

namespace Repository
{
    public class UserRepo : IUserRepo
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;

        public UserRepo(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task Login(LoginVM viewModel)
        {
            var result = await _signInManager.PasswordSignInAsync(viewModel.UserName, viewModel.Password, true, false);

            if (!result.Succeeded)
            {
                throw new Exception("Wrong username or password!");
            }
        }

        public async Task Register(RegisterVM model)
        {
            if (await _userManager.FindByNameAsync(model.UserName) != null)
            {
                throw new Exception("Username is used before.");
            }

            if (await _userManager.FindByEmailAsync(model.Email) != null)
            {
                throw new Exception("Email is used before.");
            }

            var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                throw new Exception("Something went wrong!\nMake sure the password has small letters, capital letters, numbers, and symbols!");
            }
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}