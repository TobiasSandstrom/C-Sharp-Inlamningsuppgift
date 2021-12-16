using C_Sharp_Tenta.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace C_Sharp_Tenta_Tests
{
    
    public class DiscountCodeGeneratorShould
    {
        public void GenerateDiscountCode()
        {
            var _sut = new DiscountCodeGenerator();

            string result = _sut.GenerateDiscountCode();

            Assert.NotEmpty(result);
        }
    }
}
