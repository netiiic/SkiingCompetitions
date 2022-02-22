using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z3_PR_45_2017_Antonina_Maricic.DAO.Impl;
using Z3_PR_45_2017_Antonina_Maricic.UIHandler;

namespace Z3_PR_45_2017_Antonina_Maricic
{
    class Program
    {
        private static readonly MainUIHandler mainUIHandler = new MainUIHandler();

        static void Main(string[] args)
        {
            /*SkakacDAOImpl s = new SkakacDAOImpl();
            Console.WriteLine(s.Count());
            Console.WriteLine("ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine(s.ExistsById(id));
            Console.ReadLine();*/

            mainUIHandler.HandleMainMenu();
        }

       
    }
}
