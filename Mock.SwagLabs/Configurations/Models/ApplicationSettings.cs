using Mock.SwagLabs.Configurations.Enums;

namespace Mock.SwagLabs.Configurations.Models;

public class ApplicationSettings
{
    public string BaseUrl => EnvironmentUrls.Single(x => x.Name == Directive.ToString()).Value;

    public required List<EnvironmentUrl> EnvironmentUrls { get; set; }

    public required string LoginUrl { get; set; } = string.Empty;

    public required Directive Directive { get; set; }

    public List<DBConnection> DBConnections { get; set; } = [];

    public required List<User> Users { get; set; }
}
