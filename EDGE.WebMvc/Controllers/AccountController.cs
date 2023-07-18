//Reference the final code "AccountController" 
using Microsoft.AspNetCore.Mvc;
using EDGE.Models.User;
using EDGE.Services.User;
using EDGE.Data;
using EDGE.Models;

namespace EDGE.WebMvc.Controllers;

public class AccountController : Controller
{
    private readonly IUserService _userService;
    public AccountController(IUserService userService)
    {
        _userService = userService;
    }

    //GET Action for Register -> Returns the view to the user

    public IActionResult Register()
    {
        return View();
    }

    //POST Action for Register -> When the user submits their data from their view
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(UserRegister model)
    {
        // First validate the request model, reject if invalid
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        //Try to register the user, reject if failed
        var registerResult = await _userService.RegisterUserAsync(model);
        if (registerResult == false)
        {
            return View(model);
        }

        Users loginModel = new()
        {
            Name = model.Username,
            Email = model.Password
        };
        await _userService.SignInAsync();
        return RedirectToAction("Index", "Home");
    }

    //GET Login
    public IActionResult Login()
    {
        return View();
    }

    //POST Login
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(UserLogin model)
    {
        var loginResult = await _userService.SignInAsync();
        if (loginResult == false)
        {
             return View(model);
        }

        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> Logout()
    {
        await _userService.LogoutAsync();
        return RedirectToAction("Index", "Home");
    }
}
