using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z3_PR_45_2017_Antonina_Maricic.Model
{
    public class Skakaonica
    {
        public string IdSA { get; set; }
        public string NazivSA { get; set; }
        public int DuzinaSA { get; set; }
        public string TipSA { get; set; }
        public string IDD { get; set; }

        public Skakaonica() { }

        public Skakaonica(string idSA, string nazivSA, int duzinaSA, string tipSA, string iDD)
        {
            IdSA = idSA;
            NazivSA = nazivSA;
            DuzinaSA = duzinaSA;
            TipSA = tipSA;
            IDD = iDD;
        }

        public override string ToString()
        {
            return string.Format("{0,-8} {1,-18} {2,-9} {3,-10} {4,-4}", IdSA, NazivSA, DuzinaSA, IDD, TipSA);
        }

        public static string GetFormattedHeader()
        {
            return string.Format("{0,-8} {1,-18} {2,-9} {3,-10} {4,-4}",
                "IDSA", "NAZIVSA", "DUZINASA", "IDD", "TIPSA");
        }
    }
}
