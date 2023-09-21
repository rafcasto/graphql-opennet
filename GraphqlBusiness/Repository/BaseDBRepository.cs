using GraphqlDomain.Models;
using GraphqlDomain.Models.Domain.ePortal.Requests;
using GraphqlDomain.Models.Domain.ePortal.Response;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphqlBusiness.Repository
{
    public class BaseDBRepository
    {
        private Settings settings;
        public BaseDBRepository(IConfiguration configuration) 
        {
            this.settings = new Settings(configuration);
        }


        public DBResponse ExecuteNonQueryDelete(string deleteSQL) 
        {
            DBResponse response = new DBResponse();
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(settings.ConnectionStrings))
                {
                    connection.Open();
                    using (NpgsqlCommand command = new NpgsqlCommand(deleteSQL, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                response.error = ex.Message;
                response.stacktrace = ex.StackTrace;
            }
            return response;

        }
        public DBResponse ExecuteNonQueryInsert(string insertSQL,string retriveRecordSQL)
        {
            DBResponse response = new DBResponse();
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(settings.ConnectionStrings))
                {
                    connection.Open();
                    using (NpgsqlCommand command = new NpgsqlCommand(insertSQL, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    using (NpgsqlCommand command = new NpgsqlCommand(retriveRecordSQL, connection))
                    {
                        response.Id = (int)command.ExecuteScalar();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                response.error = ex.Message;
                response.stacktrace = ex.StackTrace;
            }
            return response;
        }

        public BaseResponse DeleteRecord(BaseTemplateRequest<object> request, string sql)
        {
            BaseResponse response = new BaseResponse();
            response.dBResponses = new List<DBResponse>();
            response.dBResponses.Add(ExecuteNonQueryDelete(
                   string.Format(sql, request.Schema)));
            return response;
        }

        public BaseResponse InsertTemplate<T>(BaseTemplateRequest<T> request, Func<T, string> buildSql, string sqlRetrieveLastId)
        {
            BaseResponse response = new BaseResponse();
            response.dBResponses = new List<DBResponse>();

            while (request.Quantity >= 1)
            {
                var sql = String.Format(buildSql(request.template), request.Schema);
                response.dBResponses.Add(ExecuteNonQueryInsert(sql, string.Format(sqlRetrieveLastId, request.Schema)));
                request.Quantity--;
            }

            return response;
        }



    }
}
