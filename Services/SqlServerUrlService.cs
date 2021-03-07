using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace BlazorApp.Services {
    public class SqlServerUrlService : IUrlService {
        
        private readonly SqlConnection Connection;

        public SqlServerUrlService(IConfiguration configuration) {
            var config = configuration ?? throw new ArgumentNullException(nameof(configuration));
            Connection = new SqlConnection(config[Constants.ConfigurationConnectionStringKey]);
        }

        public async Task<string> GetUrlAlias(string url, string generatedAlias) {
            var parameters = new [] {
                GenerateNvarCharParameter(Constants.UrlParamName, Constants.UrlParamSize, url),
                GenerateNvarCharParameter(Constants.GeneratedAliasParamName, Constants.AliasParamSize, generatedAlias)
            };
            return await CallDb(Constants.GetAliasProcedure, parameters);
        }

        public async Task<string> GetFullUrl(string alias) {
            var parameters = new [] {
                GenerateNvarCharParameter(Constants.AliasParamName, Constants.AliasParamSize, alias)
            };
            return await CallDb(Constants.GetUrlProcedure, parameters);
        }

        private async Task<string> CallDb(string procedureName, SqlParameter[] parameters) {
            string result;
            await using var command = Connection.CreateCommand();
            
            try {
                command.Connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = procedureName;
                command.Parameters.AddRange(parameters);
                result = command.ExecuteScalar().ToString();
            }
            
            finally {
                command.Connection.Close();
            }
            command.Connection.Close();

            return result;
        }

        private SqlParameter GenerateNvarCharParameter(string name, int size, string value) {
           return new() {
               SqlDbType = SqlDbType.NVarChar, 
               Size = size, 
               Value = value, 
               ParameterName = name
           };
        }
    }
}