namespace HeathCare.DataBaseSettings
{
    public class DoctorDatabaseSettings : IDoctorDatabaseSettings
    {
        public string DoctorCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
