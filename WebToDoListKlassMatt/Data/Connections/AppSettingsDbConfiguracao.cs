using WebToDoListKlassMatt.Models.Entities;

namespace WebToDoListKlassMatt.Data.Connections
{
    public class AppSettingsDbConfiguracao
    {
        public EnumTipoBanco TipoBanco { get; set; }
        public string? ConnectionString { get; set; }
    }
}
