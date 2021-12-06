using DataAccess.Models;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public interface IUserData
    {
        Task InsertUser(UserModel user);
    }
}