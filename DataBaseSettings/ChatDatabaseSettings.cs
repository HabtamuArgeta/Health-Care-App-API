namespace HeathCare.DataBaseSettings
{
    public class ChatDatabaseSettings : IChatDatabaseSettings
    {
        public  string ChatCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;    
        public string DatabaseName { get; set; } = string.Empty;
    }
}
