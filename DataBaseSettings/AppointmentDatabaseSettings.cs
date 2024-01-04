namespace HeathCare.DataBaseSettings
{
    public class AppointmentDatabaseSettings : IAppointmentDatabaseSettings
    {
       public string AppointmentCollectionName { get; set; } = string.Empty;
       public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
