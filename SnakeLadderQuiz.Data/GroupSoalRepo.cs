using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeLadderQuiz.Data.Entities;
using Dapper;
using DapperExtensions;

namespace SnakeLadderQuiz.Data
{
    public class GroupSoalRepo : BaseRepo
    {

        public GroupSoalRepo(string connString) : base(connString) { }

        public List<Group_Soal> GetAll() {
            List<Group_Soal> result = new List<Group_Soal>();
            StringBuilder sb = new StringBuilder();
            sb.Append(" select * from group_soal ");

            _conn.Open();
            using (_conn)
            {
                result = _conn.Query<Group_Soal>(sb.ToString()).ToList();
            }

            return result;
        }

        public List<Group_Soal> GetAllByName(string groupName) {
            List<Group_Soal> result = new List<Group_Soal>();
            StringBuilder sb = new StringBuilder();
            sb.Append(" select * from group_soal where upper(trim(gs_name)) like upper(trim(@gs_name))");

            _conn.Open();
            using (_conn)
            {
                result = _conn.Query<Group_Soal>(sb.ToString(), new { gs_name = "%" + groupName + "%" }).ToList().ToList();
            }

            return result;
        }

        public bool NameExist(string groupName)
        {
            bool result = false;
            StringBuilder sb = new StringBuilder();
            sb.Append(" select * from group_soal where upper(trim(gs_name)) = upper(trim(@gs_name))");

            _conn.Open();
            using (_conn)
            {
                result = _conn.Query<Group_Soal>(sb.ToString(), new { gs_name = groupName }).ToList().Count> 0;
            }

            return result;
        }

        public int Insert(string groupName) {
            int result = 0;
            StringBuilder sb = new StringBuilder();
            sb.Append(" insert into group_soal (gs_name) values (@gs_name) ");
            _conn.Open();
            using (_conn)
            {
                result = _conn.Execute(sb.ToString(), new { gs_name = groupName.ToUpper() });
            }
            return result;
        }

        public int Delete(int gsId) {
            int result = 0;
            StringBuilder sb = new StringBuilder();
            sb.Append(" delete from group_soal where gs_id = @gs_id ");

            StringBuilder sb2 = new StringBuilder();
            sb2.Append(" delete from soal_tag_group where gs_id = @gs_id ");

            _conn.Open();
            using (_conn)
            {
                using (var trans = _conn.BeginTransaction())
                {
                    try
                    {
                        result = _conn.Execute(sb.ToString(), new { gs_id = gsId }, trans);
                        result += _conn.Execute(sb2.ToString(), new { gs_id = gsId }, trans);

                        trans.Commit();
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                    }
                }                
            }
            return result;
        }

        public List<Group_Soal> GetBySoalId(int soal_id)
        {
            List<Group_Soal> result = new List<Group_Soal>();
            StringBuilder sb = new StringBuilder();
            sb.Append(" select * from group_soal gs join soal_tag_group stg on stg.gs_id = gs.gs_id  ");
            sb.Append(" where stg.soal_id = @soal_id  ");
            _conn.Open();
            using (_conn)
            {
                result = _conn.Query<Group_Soal>(sb.ToString(), new { soal_id = soal_id }).ToList();
            }
            return result;
        }

        public int Count() {
            int result = 0;
            _conn.Open();
            using (_conn) {
                result = _conn.Count<Group_Soal>(null);

            }
            return result;
        }

    }
}
