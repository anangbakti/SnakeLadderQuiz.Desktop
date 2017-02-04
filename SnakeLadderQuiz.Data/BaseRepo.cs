using System.Data.SQLite;

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
    }
}
