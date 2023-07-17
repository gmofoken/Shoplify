using Shoplify.Models.DTOs;

namespace Shoplify.Ochestration.UsersOchestration.Interface
{
    public interface IUserOchestration
    {
        public string ModifyUser(UserModify user);
        public string CreateUser(User user);
    }
}
