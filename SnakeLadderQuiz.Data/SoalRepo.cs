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
    public class SoalRepo : BaseRepo
    {        
                
        public SoalRepo(string connString) : base(connString)  {}

        public List<Soal> GetAll(int limit , int offset) {
            List<Soal> result = new List<Soal>();
            StringBuilder sb = new StringBuilder();
            sb.Append(" select * from soal limit @limit offset @offset ");
            
            _conn.Open();
            using (_conn) {
                result = _conn.Query<Soal>(sb.ToString(), new { limit = limit, offset = offset }).ToList();
            }

            return result;
        }

        public Soal GetById(int soalId) {
            Soal result = null;
            StringBuilder sb = new StringBuilder();
            sb.Append(" select * from soal where soal_id = :soal_id ");

            _conn.Open();
            using (_conn) {
                result = _conn.QueryFirstOrDefault<Soal>(sb.ToString(), new { soal_id = soalId });
            }
            return result;
        }

        public int Insert(Soal soal) {
            int result = 0;
            StringBuilder sb = new StringBuilder();
            sb.Append(" insert into soal (soal_jenis, soal_tanya, soal_jawab) values (@soal_jenis, @soal_tanya, @soal_jawab) ");
            _conn.Open();
            using (_conn)
            {
                result = _conn.Execute(sb.ToString(), new { soal_jenis = soal.Soal_Jenis,
                    soal_tanya = soal.Soal_Tanya,
                    soal_jawab = soal.Soal_Jawab
                });
            }
            return result;
        }

        public int Update(Soal soal)
        {
            int result = 0;
            StringBuilder sb = new StringBuilder();
            sb.Append(" update soal  set soal_jenis=@soal_jenis, soal_tanya=@soal_tanya, soal_jawab=@soal_jawab ");
            sb.Append("  where soal_id=@soal_id ");
            _conn.Open();
            using (_conn)
            {
                result = _conn.Execute(sb.ToString(), new
                {
                    soal_jenis = soal.Soal_Jenis,
                    soal_tanya = soal.Soal_Tanya,
                    soal_jawab = soal.Soal_Jawab
                });
            }
            return result;
        }


    }
}
