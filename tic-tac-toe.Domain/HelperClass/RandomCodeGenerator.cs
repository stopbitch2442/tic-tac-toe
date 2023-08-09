using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tic_tac_toe.Domain.HelperClass
{
    public class RandomCodeGenerator
    {
        
        public static int GenerateCode()
        {
            Random rnd = new Random();
            int code = (int)rnd.NextInt64(00000, 99999);
            return code;
        }
    }
}
