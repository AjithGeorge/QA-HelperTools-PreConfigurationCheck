using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check_PreCondition_v2
{
    class JsonClassTestCases
    {
        public class RootObject
        {
            public int id { get; set; }
            public int case_id { get; set; }
            public int run_id { get; set; }
            public string title { get; set; }
            public int template_id { get; set; }
            public int type_id { get; set; }
            public string refs { get; set; }
            public object custom_req { get; set; }
            public string custom_automated_test_id { get; set; }
            public string custom_description { get; set; }
            public object custom_functionaltc { get; set; }
            public string custom_preconds { get; set; }
            public string custom_steps { get; set; }

        }
    }
}
