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
    public class SkakacService
    {
        private static readonly ISkakacDAO skakacDAO = new SkakacDAOImpl();
        private static readonly IShowByIDDDAO showBy = new ShowByIDD();

        public List<Skakac> FindByIDD(string idd)
        {
            return showBy.FindByIDD(idd).ToList();
        }

        public int BrojTitula(string idd)
        {
            return showBy.BrojTitula(idd);
        }

        public List<Skakac> FindAll()
        {
            return skakacDAO.FindAll().ToList();
        }

        public Skakac FindById(int id)
        {
            return skakacDAO.FindById(id);
        }

        public int Save(Skakac p)
        {
            return skakacDAO.Save(p);
        }

        public bool ExistsById(int id)
        {
            return skakacDAO.ExistsById(id);
        }

        public int DeleteById(int id)
        {
            return skakacDAO.DeleteById(id);
        }
        public int SaveAll(List<Skakac> skakacList)
        {
            return skakacDAO.SaveAll(skakacList);
        }
    }
}
