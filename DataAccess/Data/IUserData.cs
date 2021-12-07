using DataAccess.Models;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public interface IUserData
    {
        Task<int> InsertUser(UserModel user);
        Task<UserModel?> GetUser(string email);
    }
}