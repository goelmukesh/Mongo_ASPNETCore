namespace AuthServer.Services
{
    public interface ITokenGenerator
    {
        string GetJWTToken(string userId);
    }
}
