using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;

namespace PuzzuleQuestion.Dapper
{
    public class Dapper_: IDapper
    {

        private readonly IConfiguration _config;
        private string Connectionstring = "DefaultConnection";

        public Dapper_(IConfiguration config)
        {
            _config = config;
        }

        public DbConnection GetDbconnection()
        {
            return new MySqlConnection(_config.GetConnectionString(Connectionstring));
        }

        public int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text)
        {
            // using IDbConnection db = new MSqlConnection(_config.GetConnectionString(Connectionstring));

            return GetDbconnection().Query<T>(sp, parms, commandType: commandType).FirstOrDefault();
        }

        public async Task<T> GetAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text)
        {
            // using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            return await GetDbconnection().QuerySingleAsync<T>(sp, parms, commandType: commandType);
        }

        public List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            // using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            return GetDbconnection().Query<T>(sp, parms, commandType: commandType).ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            return await GetDbconnection().QueryAsync<T>(sp, parms, commandType: commandType);
        }

        public T Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            //using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            using IDbConnection db = GetDbconnection();

            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return result;
        }

        public T Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            // using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            using IDbConnection db = GetDbconnection();
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return result;
        }
        public async Task<T> UpdateAsync<T>(string sp, CommandType commandType = CommandType.StoredProcedure, DynamicParameters parms = null)
        {
            T result;
            // using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            using IDbConnection db = GetDbconnection();
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    result = await db.QuerySingleAsync<T>(sp, parms, commandType: commandType, transaction: tran);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return result;
        }
        public int Delete(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            int result;
            //using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            using IDbConnection db = GetDbconnection();
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    result = db.Execute(sp, parms, commandType: commandType, transaction: tran);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return result;
        }
        public int BulkInsert<T>(string sp, string type, DataTable records, CommandType commandType = CommandType.StoredProcedure)
        {
            int result = 0;
            //using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            using IDbConnection db = GetDbconnection();
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    var d = new
                    {
                        List = records.AsTableValuedParameter(type)
                    };

                    //result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
                    result = db.Execute(sp, d, commandType: commandType, transaction: tran);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return result;
        }

        public void Dispose()
        {

        }
    }

}
