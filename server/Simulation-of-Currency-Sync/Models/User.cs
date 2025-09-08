using System.ComponentModel.DataAnnotations;

namespace Simulation_of_Currency_Sync.Models;

public class User
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Email { get; set; }

    [Required] 
    public string Password { get; set; }

    [Required]
    public int Age { get; set; }

    [Required]
    public string City { get; set; }

    [Required]
    public bool Admin { get; set; } 
}
