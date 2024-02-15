using BTmsApi.DataTransferObjects;
using BTmsApi.Enums;

namespace BTmsApi.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string? Password { get; set; }
    public Byte[]? Salt { get; set; }
    public string Token { get; set; }
    public bool SignedUp { get; set; }
    public DateTime? TokenExpiration { get; set; }
    public Role Role { get; set; }

    public AuthPas getAuthPas()
    {
        return new AuthPas();
    }
}
