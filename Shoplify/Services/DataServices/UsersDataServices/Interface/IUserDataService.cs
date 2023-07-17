using Shoplify.Models;

namespace Shoplify.Services.DataServices.UsersDataServices.Interface
{
    public interface IUserDataService
    {
        public bool CreateUser(Users users);
        public bool ModifyUser(Users users);
        public Users GetUser(string userName);
    }
}
