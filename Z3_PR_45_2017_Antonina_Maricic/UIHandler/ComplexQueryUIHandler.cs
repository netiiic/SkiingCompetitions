using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z3_PR_45_2017_Antonina_Maricic.DTO;
using Z3_PR_45_2017_Antonina_Maricic.Model;
using Z3_PR_45_2017_Antonina_Maricic.Service;

namespace Z3_PR_45_2017_Antonina_Maricic.UIHandler
{
    public class ComplexQueryUIHandler
    {
        private static readonly ComplexFuncionalityService complexService = new ComplexFuncionalityService();

        public void HandleComplexQueryMenu()
        {
            String answer;
            do
            {
                Console.WriteLine("\nOdaberite funkcionalnost:");
                Console.WriteLine(
                        "\n1  - Prikazati tipve skakaonica, sa ukupnim brojem skokova i brojem razlicitih skakaca.");
                Console.WriteLine("\nX  - Izlazak iz kompleksnih upita");

                answer = Console.ReadLine();

                switch(answer)
                {
                    case "1":
                        TipSkakaonice();
                        break;
                    

                }
            } while (!answer.ToUpper().Equals("X")) ;
        }

        
        public void TipSkakaonice()
        {
            string normalne = "normalna";
            string srednje = "srednja";
            string visoke = "velika";
            try
            {
                List<SkakaoniceDTO> list = complexService.SkokList(normalne);
                Console.WriteLine("Skokovi na normalnim skakaonicama: ");
                Console.WriteLine(Skok.GetFormattedHeader());
                foreach (SkakaoniceDTO dto in list)
                {
                    foreach(Skok s in dto.skokList)
                    {
                        Console.WriteLine(s);
                    }
                }
                Console.WriteLine("Ukupan broj skokova: " + complexService.Ukupno(normalne));
                Console.WriteLine("Ukupan broj razlicitih skakaca: " + complexService.Razlicit(normalne));

                List<SkakaoniceDTO> list1 = complexService.SkokList(srednje);
                Console.WriteLine("\n\nSkokovi na srednjim skakaonicama: ");
                Console.WriteLine(Skok.GetFormattedHeader());
                foreach (SkakaoniceDTO dto in list1)
                {
                    foreach (Skok s in dto.skokList)
                    {
                        Console.WriteLine(s);
                    }
                }
                Console.WriteLine("Ukupan broj skokova: " + complexService.Ukupno(srednje));
                Console.WriteLine("Ukupan broj razlicitih skakaca: " + complexService.Razlicit(srednje));

                List<SkakaoniceDTO> list2 = complexService.SkokList(visoke);
                Console.WriteLine("\n\nSkokovi na visokim skakaonicama: ");
                Console.WriteLine(Skok.GetFormattedHeader());
                foreach (SkakaoniceDTO dto in list2)
                {
                    foreach (Skok s in dto.skokList)
                    {
                        Console.WriteLine(s);
                    }
                }
                Console.WriteLine("Ukupan broj skokova: " + complexService.Ukupno(visoke));
                Console.WriteLine("Ukupan broj razlicitih skakaca: " + complexService.Razlicit(visoke));

            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }


}
