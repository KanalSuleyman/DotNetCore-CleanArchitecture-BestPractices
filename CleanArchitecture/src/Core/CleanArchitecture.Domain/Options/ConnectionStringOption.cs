namespace CleanArchitecture.Domain.Options;

/// <summary>
/// Represents configuration options for database connection strings.
/// This class is used to bind connection string settings from configuration files.
/// </summary>
public class ConnectionStringOption
{
    /// <summary>
    /// The configuration key for the connection strings section.
    /// </summary>
    public const string Key = "ConnectionStrings";

    /// <summary>
    /// Gets or sets the SQL Server connection string.
    /// </summary>
    public string SqlServer { get; set; } = default!;
}