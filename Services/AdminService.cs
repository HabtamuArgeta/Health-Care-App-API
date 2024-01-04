using HeathCare.DataBaseSettings;
using HeathCare.Models;
using MongoDB.Driver;

namespace HeathCare.Services
{
    public class AdminService : IAdminService
    {
        private readonly IMongoCollection<Admin> _admins;

        public AdminService(IAdminDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _admins = database.GetCollection<Admin>(settings.AdminCollectionName);
        }

        public Admin Create(Admin admin)
        {
            _admins.InsertOne(admin);
            return admin;
        }

        public List<Admin> Get()
        {
            return _admins.Find(admin => true).ToList();
        }

        public Admin Get(string id)
        {
            return _admins.Find(admin => admin.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _admins.DeleteOne(admin => admin.Id == id);
        }

        public void Update(string id, Admin updatedAdmin)
        {
            updatedAdmin.Id = id;
            _admins.ReplaceOne(admin => admin.Id == id, updatedAdmin);
        }
    }
}

