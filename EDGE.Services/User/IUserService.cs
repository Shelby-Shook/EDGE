using EDGE.Models.User;

namespace EDGE.Services.User;

public interface IUserService
{
    Task<bool> RegisterUserAsync(UserRegister model);

    Task LogoutAsync();

    Task<bool> SignInAsync(UserLogin model);
}
