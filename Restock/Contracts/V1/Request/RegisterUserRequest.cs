using System.ComponentModel.DataAnnotations;

namespace Restock.Contracts.V1.Request;
public class RegisterUserRequest
{
    [EmailAddress]
    public required string Email { get; set; }
    public required string Password  { get; set; }
}
