using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EDGE.Data;
using EDGE.Data.Entities;
using EDGE.Models.User;

namespace EDGE.Services.User;

public class UserService : IUserService
{
    private readonly AppDbContext _ctx;
    private readonly UserManager<UserEntity> _userManager;
    private readonly SignInManager<UserEntity> _signInManager;

    public UserService(
        AppDbContext ctx,
        UserManager<UserEntity> userManager,
        SignInManager<UserEntity> signInManager)
    {
        _ctx = ctx;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<bool> RegisterUserAsync(UserRegister model)
    {
        if (await UserExistAsync(model.Email, model.Username))
            return false;
        UserEntity user = new()
        {
            UserName = model.Username,
            Email = model.Email
        };

        var User = await _userManager.FindByNameAsync(model.Username);
        if (user is null)
            return false;
        var isValidPassword = await _userManager.CheckPasswordAsync(user, model.Password);
        if (isValidPassword == false)
            return false;

        await _signInManager.SignInAsync(user, true);
        return true;
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