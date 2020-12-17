using System.Linq;
using Microsoft.EntityFrameworkCore;
using PersonalMoney.Api.Models;

namespace PersonalMoney.Api.Services
{
    internal class UserService : IUserService
    {
        private readonly AppDbContext dbContext;

        public UserService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <inheritdoc />
        public void CreateUser(User user)
        {
            var record = dbContext.Users
                .AsNoTracking()
                .FirstOrDefault(c => c.UserId == user.UserId);

            if (record != null)
            {
                return;
            }
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }
    }
}