using Shoplify.Models.DTOs;

namespace Shoplify.Ochestration.UsersOchestration.Interface
{
    public interface IUserOchestration
    {
        public string ModifyUser(UserModify user, string username);
        public string CreateUser(User user, string username);
    }
}
