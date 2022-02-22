using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z3_PR_45_2017_Antonina_Maricic.Model
{
    public class Skok
    {
        public string IdSK { get; set; }
        public int IdSC { get; set; }
        public string IdSA { get; set; }
        public float Bduzina { get; set; }
        public float Bstil { get; set; }
        public int Bvetar { get; set; }

        public Skok() { }

        public Skok(string idSK, int idSC, string idSA, float bduzina, float bstil, int bvetar)
        {
            IdSK = idSK;
            IdSC = idSC;
            IdSA = idSA;
            Bduzina = bduzina;
            Bstil = bstil;
            Bvetar = bvetar;
        }

        public override string ToString()
        {
            return string.Format("{0,-3} {1,-4} {2,-4} {3,-7} {4,-6} {5,-2}", IdSK, IdSC, IdSA, Bduzina, Bstil, Bvetar);
        }

        public static string GetFormattedHeader()
        {
            return string.Format("{0,-3} {1,-4} {2,-4} {3,-7} {4,-6} {5,-2}",
                "IDSK", "IDSC", "IDSA", "BDUZINA", "BSTIL", "BVETAR");
        }
    }
}
