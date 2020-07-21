using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commons.Services;
using Commons.Services.Implementation;
using Commons.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Commons.Initializers {

    /**
     * Class that initializes singletons neccesary for DI
     */
    public class SingletonInitializer : IInitializer {

        public void InitializeServices(IServiceCollection services, IConfiguration configuration) {

            services.AddSingleton<IAuthService, AuthService>();
            services.AddTransient<JwtGenerator>();

        }
    }
}
