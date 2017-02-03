using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using SnakeLadderQuiz.Data.Entities;
using Dapper;

namespace SnakeLadderQuiz.Data
{
    public class SoalRepo
    {
        private string _connString;
                
        public SoalRepo(string connString) {
            _connString = connString;
        }

        public List<Soal> GetAll(int limit , int offset) {
            List<Soal> result = new List<Soal>();
            StringBuilder sb = new StringBuilder();
            sb.Append(" select * from soal limit @limit offset @offset ");
            var conn = new SQLiteConnection(_connString);
            conn.Open();
            result = conn.Query<Soal>(sb.ToString(), new { limit = limit, offset = offset }).ToList();
            return result;
        }

    }
}
