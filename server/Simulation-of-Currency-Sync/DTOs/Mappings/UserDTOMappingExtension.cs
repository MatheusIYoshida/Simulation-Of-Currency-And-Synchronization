using Simulation_of_Currency_Sync.Models;

namespace Simulation_of_Currency_Sync.DTOs.Mappings;

public static class UserDTOMappingExtension
{
    public static UserDTO? ToUserDTO(this User user)
    {
        if (user is null)
            return null;

        return new UserDTO
        {
            Email = user.Email,
            Password = user.Password,
        };
    }
}
