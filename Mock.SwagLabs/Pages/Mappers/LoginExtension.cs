using Mock.SwagLabs.Configurations.Models;
using Mock.SwagLabs.Pages.Models;

namespace Mock.SwagLabs.Pages.Mappers;

public static class LoginExtension
{
    public static Login ToLogin(this User user)
    {
        return new Login
        {
            Username = user.UserName,
            Password = user.Password,
        };
    }
}
