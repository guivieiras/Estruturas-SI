using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFSC.MultiList
{
    public class AlunosInvertedContinuousCollection : ListaContinuaInvertida<int, Aluno>
    {
        public AlunosInvertedContinuousCollection(double range, double firstSmaller) : base(range, firstSmaller)
        {

        }


        public override int GetKey(Aluno item)
        {
            return item.Id;
        }

    
    }
}
