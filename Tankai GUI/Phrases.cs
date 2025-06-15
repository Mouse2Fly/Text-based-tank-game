using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phrases
{
    public class Phrase1 : Celebtarions
    {
        public override string Phrasse => "WINNER WINNER CHICKEN DINNER";

        public override string Cheering()
        {
            return Phrasse;
        }
    }

    public class Phrase2 : Celebtarions
    {
        public override string Phrasse => "YOUR WINNER";

        public override string Cheering()
        {
            return Phrasse;
        }
    }

    public class Phrase3 : Celebtarions
    {
        public override string Phrasse => "you WIN I guess...";
        public override string Cheering()
        {
            return Phrasse;
        }
    }
}
