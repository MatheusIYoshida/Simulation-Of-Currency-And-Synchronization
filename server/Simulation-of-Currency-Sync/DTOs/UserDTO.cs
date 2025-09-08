using System.ComponentModel.DataAnnotations;

namespace Simulation_of_Currency_Sync.DTOs;

public class UserDTO
{
    [Required]
    public string Email { get; set; }

    [Required] 
    public string Password { get; set; }
}
