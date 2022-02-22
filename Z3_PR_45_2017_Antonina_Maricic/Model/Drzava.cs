using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z3_PR_45_2017_Antonina_Maricic.Model
{
    public class Drzava
    {
        public string IDD { get; set; }
        public string NazivD { get; set; }

        public Drzava() { }

        public Drzava(string iDD, string nazivD)
        {
            IDD = iDD;
            NazivD = nazivD;
        }

        public override string ToString()
        {
            return string.Format("{0,-4} {1,-8}", IDD, NazivD);
        }

        public static string GetFormattedHeader()
        {
            return string.Format("{0,-4} {1,-8}", "IDD", "NAZIVD");
        }
    }
}
