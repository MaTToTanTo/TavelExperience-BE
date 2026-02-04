using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExperience.Common;
using TravelExperience.DbContextClass;
using TravelExperience.Entity;
using TravelExperience.Entity.Entity;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddTravelExperienceEntity(this IServiceCollection services)
        {
            services.AddDbContext<TravelExperienceDBContext>(Options =>
            {
                Options.UseSqlServer("\"Server=tcp:reydata.database.windows.net,1433;Initial Catalog=TravelExperienceDB;Persist Security Info=False;User ID=reytanto;Password=1q2w3e4r5t6y!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;\"");//mettere la connection string giusta del database
            });


            services.AddScoped<IStorageServices<UserEntity>, UserStorageServices>();
            services.AddScoped<IStorageServices<HostProfileEntity>, HostProfileStorageServices>();
            services.AddScoped<IStorageServices<SavedExperienceEntity>, SavedExperienceStorageServices>();
            services.AddScoped<IStorageServices<TravelerProfileEntity>, TravelerProfileStorageServices>();
            services.AddScoped<IStorageServices<ExperienceEntity>, ExperienceStorageServices>();
            services.AddScoped<IStorageServices<BookingEntity>, BookingStorageServices>();

            return services;
        }
    }
}
