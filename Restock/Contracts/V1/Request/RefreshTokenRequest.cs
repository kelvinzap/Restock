namespace Restock.Contracts.V1.Request;
public class RefreshTokenRequest
{
    public required string Token { get; set; }
    public required string RefreshToken { get; set; }
}
