using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ProfileMicroservice.Initializers
{
    public interface IInitializer {
        void InitializeServices(IServiceCollection services, IConfiguration configuration);
    }
}
