namespace HeathCare.DataBaseSettings
{
    public interface IAdminDatabaseSettings
    {
         string AdminCollectionName { get; set; } 
         string ConnectionString { get; set; } 
        string  DatabaseName { get; set; }
    }
}
