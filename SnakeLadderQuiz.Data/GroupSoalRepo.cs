using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeLadderQuiz.Data.Entities;
using Dapper;

namespace SnakeLadderQuiz.Data
{
    public class GroupSoalRepo : BaseRepo
    {

        public GroupSoalRepo(string connString) : base(connString) { }

        public List<GroupSoal> GetAll() {
            List<GroupSoal> result = new List<GroupSoal>();
            StringBuilder sb = new StringBuilder();
            sb.Append(" select * from group_soal ");

            _conn.Open();
            using (_conn)
            {
                result = _conn.Query<GroupSoal>(sb.ToString()).ToList();
            }

            return result;
        }

        public List<GroupSoal> GetAllByName(string groupName) {
            List<GroupSoal> result = new List<GroupSoal>();
            StringBuilder sb = new StringBuilder();
            sb.Append(" select * from group_soal where upper(trim(gs_name)) like upper(trim(@gs_name))");

            _conn.Open();
            using (_conn)
            {
                result = _conn.Query<GroupSoal>(sb.ToString(), new { gs_name = "%" + groupName + "%" }).ToList().ToList();
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
                result = _conn.Query<GroupSoal>(sb.ToString(), new { gs_name = groupName }).ToList().Count> 0;
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

    }
}
