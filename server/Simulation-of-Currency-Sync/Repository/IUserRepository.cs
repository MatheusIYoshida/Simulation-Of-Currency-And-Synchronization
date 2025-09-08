using Simulation_of_Currency_Sync.Models;

namespace Simulation_of_Currency_Sync.Repository;

public interface IUserRepository
{
    IEnumerable<User> GetProfiles();
    public User? GetProfile(string email);
    User CreateProfile(User user);
    User UpdateProfile(User user);
}
