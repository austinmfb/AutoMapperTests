using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperConsole.TestClasses.Destinations
{
    public class OuterDest
    {
        public int Value { get; set; }
        public int AdditionalValue { get; set; }

        public DataClass1 DataClass { get; set; }

        public InnerDest Inner { get; set; }
    }

    public class InnerDest
    {
        public int OtherValue { get; set; }
    }
}
