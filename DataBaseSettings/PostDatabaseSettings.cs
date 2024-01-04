namespace HeathCare.DataBaseSettings
{
    public class PostDatabaseSettings : IPostDatabaseSettings
    {
       public  string PostCollectionName { get; set; }  = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
       public string DatabaseName { get; set; } = string.Empty;
    }
}
