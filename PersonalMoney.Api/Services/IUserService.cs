using PersonalMoney.Api.Models;

namespace PersonalMoney.Api.Services
{
    /// <summary>
    /// User management service
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        void CreateUser(User user);
    }
}