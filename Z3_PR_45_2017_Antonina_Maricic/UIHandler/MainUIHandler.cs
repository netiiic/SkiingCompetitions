using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z3_PR_45_2017_Antonina_Maricic.Model;
using Z3_PR_45_2017_Antonina_Maricic.Service;

namespace Z3_PR_45_2017_Antonina_Maricic.UIHandler
{
    public class MainUIHandler
    {
        private readonly SkakacUIHandler skakacUIHandler = new SkakacUIHandler();
        private readonly ComplexQueryUIHandler complexQueryUIHandler = new ComplexQueryUIHandler();
        private static readonly SkakaonicaService skakaonciaService = new SkakaonicaService();


        public void HandleMainMenu()
        {
            string answer;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Odaberite opciju:");
                Console.WriteLine("1 - Rukovanje skakacem");
                Console.WriteLine("2 - Kompleksni upiti");
                Console.WriteLine("3 - Sve skakonice tipa kog zelite i prosecna duzina.");

                Console.WriteLine("X - Izlazak iz programa");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        skakacUIHandler.HandleSkakacMenu();
                        break;
                    case "2":
                        complexQueryUIHandler.HandleComplexQueryMenu();
                        break;
                    case "3":
                        TypeAndAVGLenght();
                        break;
                }

            } while (!answer.ToUpper().Equals("X"));

            
        }

        public void TypeAndAVGLenght()
        {
            Console.WriteLine("Unesite tip skakonice: (normalna/srednja/velika)");
            string type = Console.ReadLine();

            List<Skakaonica> skakaonice = skakaonciaService.Type(type);
            Console.WriteLine("Skakonice: ");
            Console.WriteLine(Skakaonica.GetFormattedHeader());
            foreach (Skakaonica s in skakaonice)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine($"\nProsecna duzina skakaonice tipa {type}: {skakaonciaService.AVGLenght(type)}");


        }
    }
}
