using System.Data.SQLite;
using System.Text;
using Dapper;

namespace SnakeLadderQuiz.Data
{
    public class BaseRepo
    {
        internal string _connString;
        internal System.Data.IDbConnection _conn;

        public BaseRepo(string connString)
        {
            _connString = connString;
            _conn = new SQLiteConnection(_connString);
        }

        public int? GetLastSeq(string table_name) {
            int? result = 0;
            StringBuilder sb = new StringBuilder();
            sb.Append(" select seq from sqlite_sequence where trim(upper(name))= trim(upper(@table_name))");

            _conn.Open();
            using (_conn)
            {
                result = _conn.QueryFirstOrDefault<int>(sb.ToString(), new { table_name = table_name });
            }
            return result;
        }


    }
}
