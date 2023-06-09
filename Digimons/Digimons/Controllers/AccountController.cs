using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;

namespace Digimons.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepo _user;

        public AccountController(IUserRepo user)
        {
            _user = user;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                await _user.Register(viewModel);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View();
            }

            return View("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                await _user.Login(viewModel);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _user.Logout();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return RedirectToAction("Login");
        }

    }
}