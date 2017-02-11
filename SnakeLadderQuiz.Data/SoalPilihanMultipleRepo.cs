using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeLadderQuiz.Data.Entities;
using Dapper;

namespace SnakeLadderQuiz.Data
{
    public class SoalPilihanMultipleRepo : BaseRepo
    {
        public SoalPilihanMultipleRepo(string connString) : base(connString)  { }

        public int DeleteBySoalId(int soal_id) {
            int result = 0;
            StringBuilder sb = new StringBuilder();
            sb.Append(" delete from soal_pilihan_multiple where soal_id = @soal_id ");
            _conn.Open();
            using (_conn) {
                result = _conn.Execute(sb.ToString(), new { soal_id = soal_id });
            }

            return result;
        }

        public int Insert(SoalPilihanMultiple spm) {
            int result = 0;
            StringBuilder sb = new StringBuilder();
            sb.Append(" insert into soal_pilihan_multiple (soal_id, spm_pilihan, spm_pilihanbenar) ");
            sb.Append(" values ( ");
            sb.Append("  @soal_id,  @spm_pilihan, @spm_pilihanbenar ");
            sb.Append("  ) ");
            _conn.Open();
            using (_conn)
            {
                result = _conn.Execute(sb.ToString(), new { soal_id = spm.soal_id, spm_pilihan = spm.spm_pilihan, spm_pilihanbenar = spm.spm_pilihanbenar });
            }

            return result;
        }

        public List<SoalPilihanMultiple> GetBySoalId(int soal_id) {
            List<SoalPilihanMultiple> result = new List<SoalPilihanMultiple>();
            StringBuilder sb = new StringBuilder();
            sb.Append(" select * from soal_pilihan_multiple where soal_id = @soal_id ");
            _conn.Open();
            using (_conn) {
                result = _conn.Query<SoalPilihanMultiple>(sb.ToString(), new { soal_id = soal_id }).ToList();
            }
            return result;
        } 

    }
}
