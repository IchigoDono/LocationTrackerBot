using LocationTrackerBot.DAL.Repositories.Interfaces;
using System.Threading.Tasks;
using System;
using System.Data;
using Skinhealth.DAL.Extensions.Queries;
using System.Data.SqlClient;
using Dapper;
using LoacationTrackerBot.BLL.Models;
using System.Collections.Generic;

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
                InformationModel result = await connection.QuerySingleAsync(InformationStrollQueries.Get, paramsValues);
                return result;
            }

            
        }
        public async Task<List<TableModel>> GetTableStroll(String emei)
        {
            using (var connection = new SqlConnection(GetConnection()))
            {
                connection.Open();
                var paramsValues = new { emei = emei };
                List<TableModel> result = await connection.QuerySingleAsync(InformationStrollQueries.GetTable, paramsValues);
                return result;
            }
        }

        public async Task<String> CheckEMEI(String emei)
        {
            using (var connection = new SqlConnection(GetConnection()))
            {
                connection.Open();
                var paramsValues = new { emei = emei };
                String result = await connection.QuerySingleAsync(InformationStrollQueries.GetEmei, paramsValues);
                return result;
            }
        }

        private String GetConnection()
        {
            return Environment.GetEnvironmentVariable("ConnectionString");
        }
    }
}
