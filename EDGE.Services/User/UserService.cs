using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EDGE.Data;
using EDGE.Data.Entities;
using EDGE.Models.User;

namespace EDGE.Services.User;

public class UserService : IUserService
{
    private readonly EdgeDbContext _ctx;
    private readonly UserManager<UserEntity> _userManager;
    private readonly SignInManager<UserEntity> _signInManager;

    public UserService(
        EdgeDbContext ctx,
        UserManager<UserEntity> userManager,
        SignInManager<UserEntity> signInManager)
    {
        _ctx = ctx;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<bool> RegisterUserAsync(UserRegister model)
    {
          
       // if (await UserExistAsync(model.Email, model.Username))
           // return false;
        UserEntity user = new()
        {
            Username = model.Username,
            Email = model.Email
        };
       
        var passwordHasher = new PasswordHasher<UserEntity>();
        user.Password = passwordHasher.HashPassword(user, model.Password);
        var createResults = await _userManager.CreateAsync(user);
         Console.WriteLine(user.Username);
        foreach(var e in createResults.Errors) Console.WriteLine(e.Description);
        return createResults.Succeeded;
    }

    public async Task LogoutAsync() => await _signInManager.SignOutAsync();

    private async Task<bool> UserExistAsync(string email, string username)
    {
        var normalizedEmail = _userManager.NormalizeEmail(email);
        var normalizedUsername = _userManager.NormalizeName(username);

        return await _ctx.Users.AnyAsync(u =>
        u.NormalizedEmail == normalizedEmail ||
        u.NormalizedUserName == normalizedUsername
        
        );
    }

    public Task<bool> SignInAsync(UserLogin model)
    {
        throw new NotImplementedException();
    }
}