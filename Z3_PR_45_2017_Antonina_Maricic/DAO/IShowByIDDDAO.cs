using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z3_PR_45_2017_Antonina_Maricic.Model;

namespace Z3_PR_45_2017_Antonina_Maricic.DAO
{
    interface IShowByIDDDAO : ICRUDDao<Skakac, int>
    {
        List<Skakac> FindByIDD(string idd);
        int BrojTitula(string idd);
    }
}
