using LoacationTrackerBot.BLL.Services.Interfaces;
using LoacationTrackerBot.BLL.Services.Realization;
using Microsoft.Extensions.DependencyInjection;

namespace LocationTrackerBot.BLL
{
    public static class ServiceInjection
    {
        public static void AddServiceInjection(this IServiceCollection services)
        {
            services.AddScoped<IMessageService, MessageService>();
        }
    }
}