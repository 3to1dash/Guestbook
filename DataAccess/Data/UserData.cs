using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class UserData : IUserData
    {
        private readonly ISqlDataAccess _db;

        public UserData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task InsertUser(UserModel user) =>
            _db.SaveData("spUser_Insert",
                new { user.FirstName, user.LastName, user.Email });

        public async Task<UserModel?> GetUser(string email)
        {
            var results = await _db.LoadData<UserModel, dynamic>("spUser_GetByEmail",
                new { Email = email });
            return results.FirstOrDefault();
        }
    }
}
