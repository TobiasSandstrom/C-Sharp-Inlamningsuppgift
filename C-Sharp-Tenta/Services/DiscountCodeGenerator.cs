using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Tenta.Services
{
    public interface iDiscountCodeGenerator
    {
        string GenerateDiscountCode();
    }
    public class DiscountCodeGenerator : iDiscountCodeGenerator
    {
        // Metod som genererar en rabattkod med hjälp av en string + Random.Next
        public string GenerateDiscountCode()
        {
            Random random = new Random();
            int randomNumber = random.Next(10, 26);
            string code = $"Avdrag{randomNumber}";
            return code;
        }
    }
}
