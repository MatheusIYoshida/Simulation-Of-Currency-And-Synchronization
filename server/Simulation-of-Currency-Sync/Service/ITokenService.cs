using Simulation_of_Currency_Sync.DTOs;

namespace Simulation_of_Currency_Sync.Service;

public interface ITokenService
{
    string GenerateTokenJWT(UserDTO userDTO);
}
