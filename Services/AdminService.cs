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

        public Admin Get(string setntVal)
        {
            Admin admin;
            admin = _admins.Find(admin => admin.UserName == setntVal).FirstOrDefault();
            if (admin != null)
            {
              return admin;
            }
            return _admins.Find(a => a.Id == setntVal).FirstOrDefault();

          
        }
        public Admin Authenticate(string username, string password)
        {
            var admin = _admins.Find(a => a.UserName == username).FirstOrDefault();

            if (admin != null && admin.Password == password)
            {
                // Authentication successful, return the admin details
                return admin;
            }

            // If the username or password is incorrect, return null
            return null;
        }

        //public Admin GetByUserName(string username)
        //{
        //    var admin = _admins.Find(a => a.UserName == username).FirstOrDefault();

        //    if (admin != null)
        //    {

        //        return admin;
        //    }
        //    return null;
        //}

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

