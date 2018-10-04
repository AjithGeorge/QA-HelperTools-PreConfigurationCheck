using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check_PreCondition_v2
{
    class JsonClass_SuiteId
    {
        public class RootObject
        {
            public int id { get; set; }
            public int suite_id { get; set; }
            public string name { get; set; }
            public object description { get; set; }
            public int plan_id { get; set; }

        }
    }
}
