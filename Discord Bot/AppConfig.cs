using Npgsql;

namespace Discord_Bot;

public static class AppConfig
{
    public static string Token => Environment.GetEnvironmentVariable("TOKEN") ?? string.Empty;

    public static string ConnectionString;

    static AppConfig()
    {
        ConnectionString = ConvertDatabaseUrlToConnectionString(Environment.GetEnvironmentVariable("DATABASE_URL") ?? string.Empty);
    }

    private static string ConvertDatabaseUrlToConnectionString(string databaseUrl)
    {
        var databaseUri = new Uri(databaseUrl);
        var userInfo = databaseUri.UserInfo.Split(':');

        var builder = new NpgsqlConnectionStringBuilder
        {
            Host = databaseUri.Host,
            Port = databaseUri.Port,
            Username = userInfo[0],
            Password = userInfo[1],
            Database = databaseUri.LocalPath.TrimStart('/')
        };

        return builder.ToString();
    }
}
