namespace DefaultNamespace;

using Npgsql;
public class DbContext(ApplicationConfig config)
{
    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(config.Connstring);
    }
}