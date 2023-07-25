using Microsoft.AspNetCore.Identity;

namespace EDGE.Data.Entities;

public class UserEntity : IdentityUser<int>
{
    public string Username {get; set; } = null!;

    public override string UserName => Username;

}
