using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeLadderQuiz.Data.Entities;

namespace SnakeLadderQuiz.Data
{
    public class SoalPilihanMultipleRepo : BaseRepo
    {
        public SoalPilihanMultipleRepo(string connString) : base(connString)  { }

        public int DeleteBySoalId(int soal_id) {
            int result = 0;

            return result;
        }

        public int Insert(SoalPilihanMultiple spm) {
            int result = 0;

            return result;
        }

        public List<SoalPilihanMultiple> GetBySoalId(int soal_id) {
            List<SoalPilihanMultiple> result = new List<SoalPilihanMultiple>();

            return result;
        } 

    }
}
