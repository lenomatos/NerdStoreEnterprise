using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSE.Identidade.API.Data;
using NSE.Identidade.API.Extensions;
using NSE.WebAPI.Core.Identidade;

namespace NSE.Identidade.API.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, IConfiguration contiguration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(contiguration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>()
               .AddRoles<IdentityRole>()
               .AddErrorDescriber<IdentityMensagensPortugues>()
               .AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultTokenProviders();
            services.AddJwtConfiguration(contiguration);
            return services;
        }

    }
}
