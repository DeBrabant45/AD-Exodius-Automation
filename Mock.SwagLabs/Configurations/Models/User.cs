using Mock.SwagLabs.Configurations.Enums;

namespace Mock.SwagLabs.Configurations.Models;

public class User
{
    public string Name { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public ClearanceType ClearanceType { get; set; }
}