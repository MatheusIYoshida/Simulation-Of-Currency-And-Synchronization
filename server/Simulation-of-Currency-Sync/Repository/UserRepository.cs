using Simulation_of_Currency_Sync.Models;
using Simulation_of_Currency_Sync.Service;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Simulation_of_Currency_Sync.Repository;

public class UserRepository : IUserRepository
{
    private static List<User> _profiles = new List<User>();
    private readonly IDataService _service;
    private const string FilePath = "Data/profiles.json";
    public UserRepository(IDataService service)
    {
        _service = service;
        _profiles = _service.LoadData<User>(FilePath) ?? new List<User>();
    }

    public IEnumerable<User> GetProfiles()
    {
        return _profiles.ToList();
    }

    public User? GetProfile(string email)
    {
        return _profiles.FirstOrDefault(p => p.Email == email);
    }

    public User CreateProfile(User user)
    {
        if (user is null)
            throw new InvalidOperationException("User is null");

        _profiles.Add(user);
        _service.SaveData(FilePath, _profiles);
        return user;
    }

    public User UpdateProfile(User user)
    {
        var existingProfile = _profiles.FirstOrDefault(p => p.Email == user.Email);

        if (existingProfile is null)
            throw new KeyNotFoundException($"Profile with email {user.Email} not found");

        existingProfile.Name = user.Name;
        existingProfile.Email = user.Email;
        existingProfile.Password = user.Password;
        existingProfile.City = user.City;
        existingProfile.Age = user.Age;
        existingProfile.Admin = user.Admin;

        _service.SaveData(FilePath, _profiles);
        return existingProfile;
    }
}
