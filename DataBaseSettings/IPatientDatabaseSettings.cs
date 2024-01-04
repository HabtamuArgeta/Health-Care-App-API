namespace HeathCare.DataBaseSettings
{
    public interface IPatientDatabaseSettings
    {
        string PatientCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
