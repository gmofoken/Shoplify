using AutoMapper;
using Shoplify.Models;
using Shoplify.Models.DTOs;
using Shoplify.Ochestration.UsersOchestration.Interface;
using Shoplify.Services.DataServices.UsersDataServices.Interface;

namespace Shoplify.Ochestration.UsersOchestration.Implementation
{
    public class UsersOchestration : IUserOchestration
    {
        private readonly IUserDataService _UsersDataService;
        private readonly IMapper _Mapper;

        public UsersOchestration(IUserDataService userDataService, IMapper mapper)
        {
            _UsersDataService = userDataService;
            _Mapper = mapper;
        }

        public string CreateUser(User user)
        {
            if (!user.Username.ToLower().Equals(_UsersDataService.GetUser(user.Username.ToLower())))
            {
                var users = _Mapper.Map<Users>(user);

                if (_UsersDataService.CreateUser(users))
                    return $"Succesfully created user{user.Username}";
            }
            return $"Unable to create user: {user.Username}";
        }

        public string ModifyUser(UserModify user)
        {
            var users = _UsersDataService.GetUser(user.Username);

            if (user.Username.ToLower().Equals(users.Username.ToLower()))
            {
                users.IsAdmin = user.IsAdmin;
                users.Active = user.IsActive;

                if (_UsersDataService.ModifyUser(users))
                    return $"Succesfully modified user{user.Username}";
            }
            return $"Unable to modify user: {user.Username}";
        }
    }
}
