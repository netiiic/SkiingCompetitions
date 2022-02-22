using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z3_PR_45_2017_Antonina_Maricic.Model
{
    public class Skakac
    {
        public int IdSC { get; set; }
        public string ImeSC { get; set; }
        public string PrzSC { get; set; }
        public string IDD { get; set; }
        public int Titule { get; set; }
        public float PbSC { get; set; }

        public Skakac() { }

        public Skakac (int idsc, string imeSC, string przSC, string idd, int titule, float pbSC)
        {
            this.IdSC = idsc;
            this.ImeSC = imeSC;
            this.PrzSC = przSC;
            this.IDD = idd;
            this.Titule = titule;
            this.PbSC = pbSC;
        }

        public override string ToString()
        {
            return string.Format("{0,-3} {1,-10} {2,-10} {3,-4} {4,-3} {5,-6}", IdSC, ImeSC, PrzSC, IDD, Titule, PbSC);
        }

        public static string GetFormattedHeader()
        {
            return string.Format("{0,-3} {1,-10} {2,-10} {3,-4} {4,-3} {5,-6}",
                "IDSC", "IMESC", "PRZSC", "IDD", "TITULE", "PBSC");
        }
    }
}
