using AutoMapper;
using PersonalMoney.Api.Models;

namespace PersonalMoney.Api.ViewModels.Mapper
{
    /// <summary>
    /// User mapper
    /// </summary>
    /// <seealso cref="Profile" />
    public class UserMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserMapper"/> class.
        /// </summary>
        public UserMapper()
        {
            CreateMap<User, UserViewModel>()
                .ReverseMap();
        }
    }
}