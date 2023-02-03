using JSON_WebToken_API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JSON_WebToken_API.Context
{
    public class JwtDbContext : IdentityDbContext<User>
    {
        public JwtDbContext(DbContextOptions<JwtDbContext> options): base(options)
        { }

    }
}
