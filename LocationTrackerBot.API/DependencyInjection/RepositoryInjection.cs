using LocationTrackerBot.DAL.Repositories.Interfaces;
using LocationTrackerBot.DAL.Repositories.Realization;
using Microsoft.Extensions.DependencyInjection;

namespace LocationTrackerBot.API.DependencyInjection
{
    public static class RepositoryInjection
    {
        public static void AddRepositoryInjection(this IServiceCollection services)
        {
            services.AddScoped<IMessageRepository, MessageRepository>();
        }
    }
}
