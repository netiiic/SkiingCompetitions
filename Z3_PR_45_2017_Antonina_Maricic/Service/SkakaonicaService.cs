using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z3_PR_45_2017_Antonina_Maricic.DAO;
using Z3_PR_45_2017_Antonina_Maricic.DAO.Impl;
using Z3_PR_45_2017_Antonina_Maricic.Model;

namespace Z3_PR_45_2017_Antonina_Maricic.Service
{
    public class SkakaonicaService
    {
        private static readonly ISkakaoniceDAO skakaoncaDAO = new SkakaoniceDAOImpl();
        public List<Skakaonica> Type(string tip)
        {
            return skakaoncaDAO.Type(tip);
        }

        public decimal AVGLenght(string tip)
        {
            return skakaoncaDAO.AVGLenght(tip);
        }
    }
}
