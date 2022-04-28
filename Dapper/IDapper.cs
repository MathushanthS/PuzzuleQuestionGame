using Dapper;
using System.Data;
using System.Data.Common;

namespace PuzzuleQuestion.Dapper
{
    
    public interface IDapper : IDisposable
    {
        DbConnection GetDbconnection();
        T Get<T>
            (string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        List<T> GetAll<T>
            (string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        int Execute
            (string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        T Insert<T>
            (string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        T Update<T>
            (string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        int BulkInsert<T>
            (string sp, string type, DataTable records, CommandType commandType = CommandType.StoredProcedure);
        int Delete
            (string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        Task<IEnumerable<T>>
            GetAllAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        Task<T>
            GetAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text);
        Task<T>
            UpdateAsync<T>(string sp, CommandType commandType = CommandType.StoredProcedure, DynamicParameters parms = null);
    }
}
