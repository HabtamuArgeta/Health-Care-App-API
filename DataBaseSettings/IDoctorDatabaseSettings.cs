namespace HeathCare.DataBaseSettings
{
    public interface IDoctorDatabaseSettings
    {
        string DoctorCollectionName { get; set; } 
         string ConnectionString { get; set; } 
        string DatabaseName { get; set; } 
    }
}
