using Google.Apis.Admin.Directory.directory_v1.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api_Test.Services
{
    public class UserService
    {
        private readonly List<User> _users = new()
        {
            new User { Username = "anas", Password = "1234" },
            new User { Username = "admin", Password = "admin" }
        };

        public User ValidateUser(string username, string password)
        {
            return _users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
