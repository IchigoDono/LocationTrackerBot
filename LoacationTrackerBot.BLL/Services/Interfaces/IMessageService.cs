using System.Text.Json;
using System.Threading.Tasks;

namespace LoacationTrackerBot.BLL.Services.Interfaces
{
    public interface IMessageService 
    {
        public Task DistributionService(JsonElement json);
    }
}
