using System.Threading.Tasks;
using System;
using LoacationTrackerBot.BLL.Models;
using System.Collections.Generic;

namespace LocationTrackerBot.DAL.Repositories.Interfaces
{
    public interface IMessageRepository
    {
        Task<InformationModel> GetInformationStroll(String emei);
        Task<List<TableModel>> GetTableStroll(String emei);
        Task<String> CheckEMEI(String emai);
    }
}
