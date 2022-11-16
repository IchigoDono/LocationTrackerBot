using LocationTrackerBot.DAL.Repositories.Interfaces;
using System.Threading.Tasks;
using System;
using System.Data;
using Skinhealth.DAL.Extensions.Queries;
using System.Data.SqlClient;
using Dapper;
using LoacationTrackerBot.BLL.Models;
using System.Collections.Generic;
using System.Linq;

namespace LocationTrackerBot.DAL.Repositories.Realization
{
    public class MessageRepository : IMessageRepository
    {
        public async Task<InformationModel> GetInformationStroll(String emei)
        {
            using (var connection = new SqlConnection(GetConnection()))
            {
                connection.Open();
                var paramsValues = new { emei = emei };
                IEnumerable<InformationModel> result = await connection.QueryAsync<InformationModel>(InformationStrollQueries.Get, paramsValues);
                return result.FirstOrDefault();
            }

            
        }
        public async Task<List<TableModel>> GetTableStroll(String emei)
        {
            using (var connection = new SqlConnection(GetConnection()))
            {
                connection.Open();
                var paramsValues = new { emei = emei };
                IEnumerable<TableModel> result = await connection.QueryAsync<TableModel>(InformationStrollQueries.GetTable, paramsValues);
                return result.ToList();
            }
        }

        public async Task<String> CheckEMEI(String emei)
        {
            using (var connection = new SqlConnection(GetConnection()))
            {
                connection.Open();
                var paramsValues = new { emei = emei };
                IEnumerable<string> result = await connection.QueryAsync<String>(InformationStrollQueries.GetEmei, paramsValues);
                return result.FirstOrDefault();
            }
        }

        private String GetConnection()
        {
            return Environment.GetEnvironmentVariable("ConnectionString");
        }
    }
}
