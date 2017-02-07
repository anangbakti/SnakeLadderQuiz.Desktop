using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLadderQuiz.Data
{
    public class Factory
    {
        string _connString;

        public Factory(string connString) {
            _connString = connString;
        }

        public BaseRepo GetBase()
        {
            return new BaseRepo(_connString);
        }

        public SoalRepo GetSoal() {
            return new SoalRepo(_connString);
        }

        public GroupSoalRepo GetGroupSoal()
        {
            return new GroupSoalRepo(_connString);
        }

        public SoalPilihanMultipleRepo GetSoalPilihanMultiple()
        {
            return new SoalPilihanMultipleRepo(_connString);
        }

        public SoalTagGroupRepo GetSoalTagGroup()
        {
            return new SoalTagGroupRepo(_connString);
        }

    }
}
