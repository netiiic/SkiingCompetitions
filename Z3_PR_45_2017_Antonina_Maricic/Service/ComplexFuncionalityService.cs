using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z3_PR_45_2017_Antonina_Maricic.DAO;
using Z3_PR_45_2017_Antonina_Maricic.DAO.Impl;
using Z3_PR_45_2017_Antonina_Maricic.DTO;
using Z3_PR_45_2017_Antonina_Maricic.Model;

namespace Z3_PR_45_2017_Antonina_Maricic.Service
{
    public class ComplexFuncionalityService
    {
        private static readonly ISkakaoniceDAO skakaoniceDAO = new SkakaoniceDAOImpl();

        public int Ukupno(string s)
        {
            return skakaoniceDAO.Ukupan(s);
        }        

        public int Razlicit(string s)
        {
            return skakaoniceDAO.Razlicit(s);
        }

        public List<SkakaoniceDTO> SkokList(string tip)
        {
            List<SkakaoniceDTO> list = new List<SkakaoniceDTO>();


            SkakaoniceDTO dto = new SkakaoniceDTO();
            dto.skokList = skakaoniceDAO.SkokList(tip);
            list.Add(dto);
            /*foreach (Skakaonica s in skakaoniceDAO.FindAll())
            {
                SkakaoniceDTO dto = new SkakaoniceDTO();
                dto.skokList = skakaoniceDAO.SkokList(tip);                
                list.Add(dto);
            }*/
            return list;
        }

    }
}
