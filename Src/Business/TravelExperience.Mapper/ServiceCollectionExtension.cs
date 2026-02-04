using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExperience.Booking;
using TravelExperience.Common;
using TravelExperience.Entity.Entity;
using TravelExperience.Experience;
using TravelExperience.Mapper;
using TravelExperience.User;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {

        public static IServiceCollection AddTravelExperienceMapper(this IServiceCollection services)
        {
            services.AddScoped<IMapperServices<UserEntity, UserDTO>>();
            services.AddScoped<IMapperServices<HostProfileEntity, HostProfileDTO>>();
            services.AddScoped<IMapperServices<SavedExperienceEntity, SavedExperienceDTO>>();
            services.AddScoped<IMapperServices<TravelerProfileEntity, TravelerProfileDTO>>();
            services.AddScoped<IMapperServices<ExperienceEntity, ExperienceDTO>>();
            services.AddScoped<IMapperServices<BookingEntity, BookingDTO>>();
            return services;
            
        }
    }
}
