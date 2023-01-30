using DiplomServer.Interfaces;
using DiplomServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace DiplomServer.Services
{
    public class LoginScreenWindow : ILoginScreen
    {
        UserContext db;
        string connectionString = "Server=VLADPC\\SQLEXPRESS;Database=DiplomProject;Trusted_Connection=True;TrustServerCertificate=True";
        int IdIccount;
        public static string name;
        public LoginScreenWindow(UserContext context)
        {
            db = context;
        }

        public async Task<int> LoginScreen([FromBody] UserModel idUser)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                foreach (var value in db.Users.ToList())
                {
                    if (idUser.UserName == value.UserName && idUser.Password == value.Password)
                    {
                        IdIccount = value.UserModelId;
                        name = value.UserName;
                    }
                }
                return IdIccount;
            }
        }
    }
}
