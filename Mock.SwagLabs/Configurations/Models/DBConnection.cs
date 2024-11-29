using Mock.SwagLabs.Configurations.Enums;

namespace Mock.SwagLabs.Configurations.Models;

public class DBConnection
{
    public string? ServerName { get; set; }

    public string? ServerId { get; set; }

    public string? ServerPassword { get; set; }

    public string? DatabaseName { get; set; }

    public string? DatabaseType { get; set; }

    public Directive Directive { get; set; }
}