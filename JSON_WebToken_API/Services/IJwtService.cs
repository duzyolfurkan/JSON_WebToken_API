using JSON_WebToken_API.Models;

namespace JSON_WebToken_API.Services
{
    public interface IJwtService
    {
        string GetJwtToken(User user);
    }
}
