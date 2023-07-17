using Microsoft.EntityFrameworkCore;
using Shoplify.Data;
using Shoplify.Models;
using Shoplify.Services.DataServices.UsersDataServices.Interface;

namespace Shoplify.Services.DataServices.UsersDataServices.Implementation
{
    public class UserDataService : IUserDataService
    {
        public readonly DbContextOptionsBuilder<ShoplifyContext> _DataContext;
        public readonly IConfiguration _Configuration;

        public UserDataService(IConfiguration configuration)
        {
            _Configuration = configuration;
            _DataContext = new DbContextOptionsBuilder<ShoplifyContext>();
            _DataContext.UseSqlServer(_Configuration.GetConnectionString("DefaultConnection"));
        }

        public bool CreateUser(Users users)
        {
            using (ShoplifyContext context = new ShoplifyContext(_DataContext.Options))
            {
                context.Users.Add(users);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool ModifyUser(Users users)
        {
            using (ShoplifyContext context = new ShoplifyContext(_DataContext.Options))
            {
                context.Users.Update(users);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Users GetUser(string userName)
        {
            using (ShoplifyContext context = new ShoplifyContext(_DataContext.Options))
            {
                return context.Users.Where(x => x.Username == userName).FirstOrDefault();
            }
        }
    }
}
