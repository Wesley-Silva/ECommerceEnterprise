using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECE.Identidade.API.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        // atraves do DbContextOptions passo as options para passar opções na startup
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }
    }
}
