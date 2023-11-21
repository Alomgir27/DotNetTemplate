namespace SuperHeroApiDotNet7.Services.UserService
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<User?> GetUserById(int id);
        Task<List<User?>> GetUserByName(string name);
        Task<User?> GetUserByEmail(string email);
        Task<List<User>> AddUser(User user);
        Task<User?> UpdateUser(int id, User user);
        Task<User?> DeleteUser(int id);
    }
}
