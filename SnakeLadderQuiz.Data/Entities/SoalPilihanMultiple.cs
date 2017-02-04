using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLadderQuiz.Data.Entities
{
    public class SoalPilihanMultiple
    {
        public int spm_id { get; set; }
        public int soal_id { get; set; }
        public string spm_pilihan { get; set; }
        public bool spm_pilihanbenar { get; set; }
    }
}
