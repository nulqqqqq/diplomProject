using DiplomServer.Interfaces;
using DiplomServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace DiplomServer.Services
{
    public class RegistrationUser:IRegistration
    {
        UserContext db;
        string connectionString = "Server=VLADPC\\SQLEXPRESS;Database=DiplomProject;Trusted_Connection=True;TrustServerCertificate=True";
        public RegistrationUser(UserContext context)
        {
            db = context;
        }

        public async Task<bool> Registration([FromBody] UserModel user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                int count = db.Users.Where(i => i.UserName == user.UserName).Count();
                if (count > 0)
                {
                    return false;
                }
                else
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return true;
                }
            }
        }
    }
}

