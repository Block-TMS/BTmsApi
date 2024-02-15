namespace BTmsApi.DataTransferObjects;

public class AuthPas
{
    public string Token { get; set; }
    public DateOnly TokenExpiration { get; set; }
}
