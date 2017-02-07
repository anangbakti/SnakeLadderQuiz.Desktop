using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeLadderQuiz.Data.Entities;
using Dapper;

namespace SnakeLadderQuiz.Data
{
    public class SoalTagGroupRepo : BaseRepo
    {

        public SoalTagGroupRepo(string connString) : base(connString)  { }

        public int DeleteBySoalId(int soal_id)
        {
            int result = 0;
            StringBuilder sb = new StringBuilder();
            sb.Append(" delete from soal_tag_group where soal_id = @soal_id ");
            _conn.Open();
            using (_conn)
            {
                result = _conn.Execute(sb.ToString(), new { soal_id = soal_id });
            }
            return result;
        }

        public int Insert(SoalTagGroup stg)
        {
            int result = 0;
            StringBuilder sb = new StringBuilder();
            sb.Append(" insert into soal_tag_group (soal_id, gs_id) ");
            sb.Append(" values ( @soal_id,  @gs_id ) ");
            _conn.Open();
            using (_conn)
            {
                result = _conn.Execute(sb.ToString(), new { soal_id = stg.soal_id, gs_id = stg.gs_id });
            }
            return result;
        }

        public List<GroupSoal> GetBySoalId(int soal_id)
        {
            List<GroupSoal> result = new List<GroupSoal>();
            StringBuilder sb = new StringBuilder();
            sb.Append(" select * from group_soal gs join soal_tag_group stg on stg.gs_id = gs.gs_id  ");
            sb.Append(" where stg.soal_id = @soal_id  ");
            _conn.Open();
            using (_conn)
            {
                result = _conn.Query<GroupSoal>(sb.ToString(), new { soal_id = soal_id }).ToList();
            }
            return result;
        }
    }
}
