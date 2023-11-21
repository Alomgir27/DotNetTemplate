

namespace SuperHeroApiDotNet7.Services.UserService
{
    public class UserService : IUserService
    {
        public readonly DataContext _dataContext;
        public UserService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<User>> AddUser(User user)
        {
            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();
            return await _dataContext.Users.ToListAsync();
        }

        public async Task<User?> DeleteUser(int id)
        {
            var user = await _dataContext.Users.FindAsync(id);
            if (user != null)
            {
                _dataContext.Users.Remove(user);
                await _dataContext.SaveChangesAsync();
                return user;
            }

            return null;


        }

        public async Task<User?> GetUserByEmail(string email)
        {
            var user = await _dataContext.Users.FirstAsync(x => x.Email == email);
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public async Task<User?> GetUserById(int id)
        {
            var user = await _dataContext.Users.FindAsync(id);
            if(user != null)
            {
                return user;
            }
            return null;
        }

        public async Task<List<User>> GetUserByName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var users = await _dataContext.Users
                    .Where(u => u.Name == name)
                    .ToListAsync();

                return users;
            }
            else
            {
                // If the name is null or empty, you might want to handle it accordingly.
                // Here, I'm returning an empty list, but you can adjust this part based on your requirements.
                return new List<User>();
            }
        }


        public async Task<List<User>> GetUsers()
        {
            var users = await _dataContext.Users.ToListAsync();
            return users;
        }

        public async Task<User?> UpdateUser(int id, User response) 
        {
            var user = await _dataContext.Users.FindAsync(id);
            if (user != null)
            {
                user.Name = response.Name;
                user.Email = response.Email;
                user.Password = response.Password;
                user.Address = response.Address;
                user.City = response.City;
                user.PostalCode = response.PostalCode;
                user.Country = response.Country;
                user.HomePage = response.HomePage;
                user.PhoneNumber = response.PhoneNumber;
                await _dataContext.SaveChangesAsync();
                return user;
            }
            return null;
        }
    }
}
