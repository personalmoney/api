using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PersonalMoney.Api.Models;
using PersonalMoney.Api.ViewModels;

namespace PersonalMoney.Api.Services
{
    internal class UserService : IUserService
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;

        public UserService(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        /// <inheritdoc />
        public void CreateUser(UserViewModel user)
        {
            var record = dbContext.Users
                .AsNoTracking()
                .FirstOrDefault(c => c.UserId == user.UserId);

            if (record != null)
            {
                return;
            }

            var model = mapper.Map<User>(user);
            dbContext.Users.Add(model);
            dbContext.SaveChanges();
        }
    }
}