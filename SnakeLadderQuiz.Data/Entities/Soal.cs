using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLadderQuiz.Data.Entities
{
    public class Soal
    {
        public double Soal_Id { get; set; }
        public string Soal_Jenis { get; set; }
        public string Soal_Tanya { get; set; }
        public string Soal_Jawab { get; set; }
        public DateTime Soal_CreateDate { get; set; }
        public DateTime Soal_LastUpdate { get; set; }
    }
}
