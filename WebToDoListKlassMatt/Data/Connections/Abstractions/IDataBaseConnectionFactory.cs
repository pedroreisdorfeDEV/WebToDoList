using WebToDoListKlassMatt.Data.Contexts;

namespace WebToDoListKlassMatt.Data.Connections.Abstractions
{
    public interface IDataBaseConnectionFactory
    {
        DataBaseContext ObterContexto(string AppSettingsSection);
    }
}
