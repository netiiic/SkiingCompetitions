using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z3_PR_45_2017_Antonina_Maricic.Model;

namespace Z3_PR_45_2017_Antonina_Maricic.DAO
{
    public interface ISkakaoniceDAO : ICRUDDao<Skakaonica, int>
    {
        List<Skok> SkokList (string tip);
        int Ukupan(string s);
        int Razlicit(string s);
        List<Skakaonica> Type(string tip);
        decimal AVGLenght(string tip);

    }
}
