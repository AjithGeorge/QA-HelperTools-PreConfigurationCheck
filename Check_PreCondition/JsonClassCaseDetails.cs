using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check_PreCondition_v2
{
    class JsonClassCaseDetails
    {
        public class RootObject
        {
            public int id { get; set; }
            public string title { get; set; }
            public int section_id { get; set; }
            public int template_id { get; set; }
            public int type_id { get; set; }

            public int suite_id { get; set; }
            public object custom_req { get; set; }
            public List<int> custom_carrier { get; set; }
            public string custom_automated { get; set; }
            public string custom_release { get; set; }

            public string custom_automated_test_id { get; set; }

            public string custom_description { get; set; }
            public object custom_functionaltc { get; set; }
            public string custom_preconds { get; set; }

        }
    }
}
