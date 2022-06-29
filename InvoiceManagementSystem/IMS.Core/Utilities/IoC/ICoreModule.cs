using Microsoft.Extensions.DependencyInjection;

namespace IMS.Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection services);
    }
}
