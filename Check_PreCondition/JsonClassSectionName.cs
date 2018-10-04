using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check_PreCondition_v2
{
    class JsonClassSectionName
    {
        public class RootObject
        {
            public int suite_id { get; set; }
            public string name { get; set; }
            public object description { get; set; }
            public object parent_id { get; set; }

        }
    }
}
