using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z3_PR_45_2017_Antonina_Maricic.Model;
using Z3_PR_45_2017_Antonina_Maricic.Service;

namespace Z3_PR_45_2017_Antonina_Maricic.UIHandler
{
    public class SkakacUIHandler
    {
        private static readonly SkakacService skakacService = new SkakacService();

        public void HandleSkakacMenu()
        {
            String answer;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Odaberite opciju za rad nad skakacima:");
                Console.WriteLine("1 - Prikaz svih");
                Console.WriteLine("2 - Prikaz po identifikatoru");
                Console.WriteLine("3 - Unos jednog skakaca");
                Console.WriteLine("4 - Unos vise skakaca");
                Console.WriteLine("5 - Izmena po identifikatoru");
                Console.WriteLine("6 - Brisanje po identifikatoru");
                Console.WriteLine("7 - Prikaz skakaca po drzavi");
                Console.WriteLine("X - Izlazak iz rukovanja skakacima");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        ShowAll();
                        break;
                    case "2":
                        ShowById();
                        break;
                    case "3":
                        HandleSingleInsert();
                        break;
                    case "4":
                        HandleMultipleInserts();
                        break;
                    case "5":
                        HandleUpdate();
                        break;
                    case "6":
                        HandleDelete();
                        break;
                    case "7":
                        ShowIDD();
                        break;

                }

            } while (!answer.ToUpper().Equals("X"));
        }

        private void ShowIDD()
        {
            Console.WriteLine("IDD: ");
            string idd = Console.ReadLine();

            try
            {
                List<Skakac> skakac = skakacService.FindByIDD(idd);

                Console.WriteLine(Skakac.GetFormattedHeader());
                foreach(Skakac s in skakac)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine("---------Broj titula drzave---------");
                Console.WriteLine(skakacService.BrojTitula(idd));
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ShowAll()
        {
            Console.WriteLine(Skakac.GetFormattedHeader());

            try
            {
                foreach (Skakac skakac in skakacService.FindAll())
                {
                    Console.WriteLine(skakac);
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void ShowById()
        {
            Console.WriteLine("IDSC: ");
            int id = int.Parse(Console.ReadLine());

            try
            {
                Skakac skakac = skakacService.FindById(id);

                Console.WriteLine(Skakac.GetFormattedHeader());
                Console.WriteLine(skakac);
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void HandleSingleInsert()
        {
            Console.WriteLine("IDSC: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Ime: ");
            string imeSC = Console.ReadLine();

            Console.WriteLine("Prezime: ");
            string przSC = Console.ReadLine();

            Console.WriteLine("ID drzave: ");
            string idd = Console.ReadLine();

            Console.WriteLine("Titule: ");
            int titule = int.Parse(Console.ReadLine());

            Console.WriteLine("Broj bodova: ");
            float pbsc = float.Parse(Console.ReadLine());

            try
            {
                int inserted = skakacService.Save(new Skakac(id, imeSC, przSC, idd, titule, pbsc));
                if (inserted != 0)
                {
                    Console.WriteLine("Skakac \"{0}\" uspešno uneto.", imeSC);
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void HandleUpdate()
        {
            Console.WriteLine("IDSC: ");
            int id = int.Parse(Console.ReadLine());

            try
            {
                if (!skakacService.ExistsById(id))
                {
                    Console.WriteLine("Uneta vrednost ne postoji!");
                    return;
                }

                Console.WriteLine("Ime: ");
                string imeSC = Console.ReadLine();

                Console.WriteLine("Prezime: ");
                string przSC = Console.ReadLine();

                Console.WriteLine("ID drzave: ");
                string idd = Console.ReadLine();

                Console.WriteLine("Titule: ");
                int titule = int.Parse(Console.ReadLine());

                Console.WriteLine("Broj bodova: ");
                float pbsc = float.Parse(Console.ReadLine());

                int updated = skakacService.Save(new Skakac(id, imeSC, przSC, idd, titule, pbsc));
                if (updated != 0)
                {
                    Console.WriteLine("Skakac \"{0}\" uspešno izmenjeno.", id);
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void HandleDelete()
        {
            Console.WriteLine("IDSC: ");
            int id = int.Parse(Console.ReadLine());

            try
            {
                int deleted = skakacService.DeleteById(id);
                if (deleted != 0)
                {
                    Console.WriteLine("Skakac sa šifrom \"{0}\" uspešno obrisano.", id);
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void HandleMultipleInserts()
        {
            List<Skakac> skakacList = new List<Skakac>();
            String answer;
            do
            {
                Console.WriteLine("IDSC: ");
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine("Ime: ");
                string imeSC = Console.ReadLine();

                Console.WriteLine("Prezime: ");
                string przSC = Console.ReadLine();

                Console.WriteLine("ID drzave: ");
                string idd = Console.ReadLine();

                Console.WriteLine("Titule: ");
                int titule = int.Parse(Console.ReadLine());

                Console.WriteLine("Broj bodova: ");
                float pbsc = float.Parse(Console.ReadLine());

                skakacList.Add(new Skakac(id, imeSC, przSC, idd, titule, pbsc));

                Console.WriteLine("Unesi još jednog skakaca? (ENTER za potvrdu, X za odustanak)");
                answer = Console.ReadLine();
            } while (!answer.ToUpper().Equals("X"));

            try
            {
                int numInserted = skakacService.SaveAll(skakacList);
                Console.WriteLine("Uspešno uneto {0} skakaca.", numInserted);
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
