namespace HeathCare.DataBaseSettings
{
    public class PatientDatabaseSettings : IPatientDatabaseSettings
    {
       public string PatientCollectionName { get; set; } = string.Empty;
       public string ConnectionString { get; set; } = string.Empty;
       public string DatabaseName { get; set; } = string.Empty;
    }
}
