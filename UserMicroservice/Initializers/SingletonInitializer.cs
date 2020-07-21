using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProfileMicroservice.Services;
using ProfileMicroservice.Services.Implementation;

namespace ProfileMicroservice.Initializers
{

    /**
     * Class that initializes singletons neccesary for DI
     */
    public class SingletonInitializer : IInitializer {

        public void InitializeServices(IServiceCollection services, IConfiguration configuration) {

            // register user service singleton
            services.AddSingleton<IProfileService, UserService>();

        }
    }
}
