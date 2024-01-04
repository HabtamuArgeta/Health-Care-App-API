namespace HeathCare.DataBaseSettings
{
    public class AdminDatabaseSettings : IAdminDatabaseSettings
    {
        public string AdminCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
