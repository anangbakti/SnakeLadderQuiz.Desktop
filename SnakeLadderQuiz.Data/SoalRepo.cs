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

        public List<Soal> GetByPertanyaanDanNamaGroup(string tanya, string namaGroup,int limit, int offset) {
            List<Soal> result = new List<Soal>();
            StringBuilder sb = new StringBuilder();
            sb.Append(" select s.* from soal s ");
            if (!string.IsNullOrEmpty(namaGroup)) {
                sb.Append(" inner join soal_tag_group stg ");
                sb.Append(" inner join group_soal gs ");
            }
            sb.Append(" where  trim(upper(s.soal_tanya)) like trim(upper(@soal_tanya)) ");
            if (!string.IsNullOrEmpty(namaGroup))
            {
                sb.Append(" and s.SOAL_ID = stg.SOAL_ID and stg.GS_ID = gs.GS_ID  ");
                sb.Append(" and trim(upper(gs.GS_NAME)) like trim(upper(@gs_name)) ");
            }
            sb.Append(" limit @limit offset @offset ");
            _conn.Open();
            using (_conn) {
                if (!string.IsNullOrEmpty(namaGroup))
                {
                    result = _conn.Query<Soal>(sb.ToString(), new { soal_tanya = "%" + tanya + "%",
                        gs_name = "%" + namaGroup + "%",
                        limit = limit,
                        offset = offset }).ToList();
                }
                else {
                    result = _conn.Query<Soal>(sb.ToString(), new { soal_tanya = "%" + tanya + "%",
                        limit = limit, offset = offset }).ToList();
                }
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

        public List<Soal> GetByGroupId(int groupId) {
            List<Soal> result = new List<Soal>();
            StringBuilder sb = new StringBuilder();
            sb.Append(" select s.* from soal s  ");
            sb.Append(" join group_soal gs on s.soal_id = stg.soal_id  ");
            sb.Append(" join soal_tag_group stg on stg.gs_id = gs.gs_id  ");
            sb.Append(" where gs.GS_ID = @gs_id ");
            _conn.Open();
            using (_conn) {
                result = _conn.Query<Soal>(sb.ToString(), new { gs_id = groupId }).ToList();
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
                    soal_jawab = soal.Soal_Jawab,
                    soal_id = soal.Soal_Id
                });
            }
            return result;
        }

        public int Delete(int soal_id)
        {
            int result = 0;
            StringBuilder sb = new StringBuilder();
            sb.Append(" delete from soal where soal_id = @soal_id ");
            _conn.Open();
            using (_conn)
            {
                result = _conn.Execute(sb.ToString(), new { soal_id = soal_id });
            }
            return result;
        }


    }
}
