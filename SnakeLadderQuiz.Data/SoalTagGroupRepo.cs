using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeLadderQuiz.Data.Entities;

namespace SnakeLadderQuiz.Data
{
    public class SoalTagGroupRepo : BaseRepo
    {

        public SoalTagGroupRepo(string connString) : base(connString)  { }

        public int DeleteBySoalId(int soal_id)
        {
            int result = 0;

            return result;
        }

        public int Insert(SoalTagGroup stg)
        {
            int result = 0;

            return result;
        }

        public List<GroupSoal> GetBySoalId(int soal_id)
        {
            List<GroupSoal> result = new List<GroupSoal>();

            return result;
        }
    }
}
