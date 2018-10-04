using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Check_PreCondition_v2
{
    public partial class Form1 : Form
    {
        public string baseurl = "https://korewireless.testrail.com/index.php?/";
        public string username;
        public string password;
        public string endpoint;
        public string TestRunID;
        public string Path;

        public Form1()
        {
            InitializeComponent();

            chkbx_rememberMe.Checked = Properties.Settings.Default.RememberMe;

            if (Properties.Settings.Default.RememberMe)
            {
                txtbx_usrname.Text = Properties.Settings.Default.Username;
                txtbx_password.Text = Properties.Settings.Default.Password;

            }

        }

        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Saving the user details on Form Close Event
            if (chkbx_rememberMe.Checked)
            {
                Properties.Settings.Default.Username = txtbx_usrname.Text;
                Properties.Settings.Default.Password = txtbx_password.Text;
                Properties.Settings.Default.RememberMe = true;
                Properties.Settings.Default.Save();
            }


            if (!chkbx_rememberMe.Checked)
            {
                Properties.Settings.Default.Username = null;
                Properties.Settings.Default.Password = null;
                Properties.Settings.Default.RememberMe = false;
                Properties.Settings.Default.Save();
            }


        }

        private void chkbx_TogglePassword_CheckedChanged(object sender, EventArgs e)

        {
            if (chkbx_TogglePassword.Checked)
            { txtbx_password.UseSystemPasswordChar = false; }

            else if (!chkbx_TogglePassword.Checked)
            { txtbx_password.UseSystemPasswordChar = true; }


        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            //      Adding FormClosing Event.
            FormClosing += new FormClosingEventHandler(Form1_FormClosing);

        }

        private void btn_validate_Click(object sender, EventArgs e)
        {
            TestRunID = txtbx_TesRunID.Text;
            username = txtbx_usrname.Text;
            password = txtbx_password.Text;


            try
            {
                Cursor.Current = Cursors.WaitCursor;

                endpoint = "api/v2/get_plan/" + TestRunID;
                GetRequest SuiteIDs = new GetRequest();
                string responseFromServer = SuiteIDs.get(username, password, baseurl, endpoint);

                //rtb_Console.Text = responseFromServer;


                rtb_Console.Text = "Plan Loaded Successfully!!";
                Application.DoEvents();


                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(responseFromServer);
                int i = 0;

                StringBuilder sb = new StringBuilder();
                List<string> List_suiteIds = new List<string>();

                foreach (JObject entry in jsonObj["entries"])
                {
                    foreach (JObject runs in jsonObj["entries"][i]["runs"])

                    {
                        string s = runs.ToString();

                        sb.Clear();
                        sb.Append(s);
                        i++;
                        JsonClass_SuiteId.RootObject Obj = JsonConvert.DeserializeObject<JsonClass_SuiteId.RootObject>(sb.ToString());

                        var RunId = Obj.id.ToString();
                        List_suiteIds.Add(RunId.ToString());
                    }

                }
                rtb_Console.AppendText(Environment.NewLine + "TestSuites Identified Successfully!!");
                Application.DoEvents();
                rtb_Console.AppendText(Environment.NewLine + "Feching Test Cases...");
                Application.DoEvents();



                List<string> List_TestCases = new List<string>();
                foreach (var suite in List_suiteIds)
                { if (suite != "469")
                    {

                        endpoint = "api/v2/get_tests/" + suite;
                        GetRequest TestCases = new GetRequest();
                        string responseFromServer1 = TestCases.get(username, password, baseurl, endpoint);
                        //rtb_Console.Text = responseFromServer1;

                        var Obj = JsonConvert.DeserializeObject<List<JsonClassTestCases.RootObject>>(responseFromServer1);
                        foreach (JsonClassTestCases.RootObject item in Obj)
                        {
                            List_TestCases.Add(item.case_id.ToString());
                        }
                    }
                }
                rtb_Console.AppendText(Environment.NewLine + "TestCases Loaded Succesfully!!");
                Application.DoEvents();
                rtb_Console.AppendText(Environment.NewLine + "Fetching Preconditions...");
                Application.DoEvents();

                List <string> List_PreConditions = new List<string>();
                List<string> List_PreConditionDetails = new List<string>();


                foreach (var TestCase in List_TestCases)
                {
                    endpoint = "api/v2/get_case/" + TestCase;
                    GetRequest PreConditions = new GetRequest();
                    string responseFromServer2 = PreConditions.get(username, password, baseurl, endpoint);
                    //rtb_Console.Text = responseFromServer2;
                    JsonClassPreConditions.RootObject Obj = JsonConvert.DeserializeObject<JsonClassPreConditions.RootObject>(responseFromServer2);
                    if (Obj.custom_preconds != null)
                    {

                        var preconditons = Obj.custom_preconds.ToString();


                        var pattern = @"\[C(.*?)\]";
                        var matches = Regex.Matches(preconditons, pattern);


                        foreach (Match m in matches)
                        {
                            List_PreConditions.Add(m.Groups[1].ToString());
                            List_PreConditionDetails.Add(  "C" + Obj.id.ToString()+ "," + "C" + m.Groups[1].ToString()+",");


                        }
                    }

                }

                List_PreConditions = List_PreConditions.Distinct().ToList(); //making List Unique.
                rtb_Console.AppendText(Environment.NewLine + "PreConditions Loaded Successfully!!");
                Application.DoEvents();
                rtb_Console.AppendText(Environment.NewLine + "Fetching Missing Preconditions..");
                Application.DoEvents();


                var result = List_PreConditions.Except(List_TestCases);

                if (result.Count() == 0)
                {
                    rtb_Console.AppendText("No Missing Preconditions Identified!!");
                    MessageBox.Show("No Missing Preconditions Identified!", "Completed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    List<List<string>> List_MissingPreConditionDetails = new List<List<string>>();

                    foreach (var item in result)
                    {

                        List_MissingPreConditionDetails.Add(List_PreConditionDetails.FindAll(delegate (string s) { return s.Contains(",C" + item + ","); }));

                    }

                    List<string> List1 = new List<string>();
                    List1 = List_MissingPreConditionDetails.SelectMany(x => x).ToList(); //Converting List<List> to List

                    rtb_Console.AppendText(Environment.NewLine + "Missing Preconditions Loaded Successfully!!");
                    Application.DoEvents();


                    List<string> FinalList = new List<string>();


                    string path0 = string.Concat(Environment.CurrentDirectory, @"\Output\");


                    if (!Directory.Exists(path0))  // if it doesn't exist, create
                        Directory.CreateDirectory(path0);

                    /*TextWriter ParentDetails = new StreamWriter(path0 + "PreCondition Parent Details" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt");


                    int k = List_MissingPreConditionDetails.Count();
                    ParentDetails.WriteLine("Missing Precondition|Parent Test Case|Description");
                    for (i = 0; i < k; i++)
                    {

                        foreach (String s in (List_MissingPreConditionDetails[i]))

                        { ParentDetails.WriteLine(s); }
                    }

                    ParentDetails.Close();
                    rtb_Console.AppendText(Environment.NewLine + "Successfully Exported Details of Missing PreConditions to: PreCondition_Parent_Details.txt");
                    Application.DoEvents();*/


                    rtb_Console.AppendText(Environment.NewLine + "Fetching Missing Precondition path details..");
                    Application.DoEvents();

                    List<string> List_MissingDetails = new List<string>();
                    Dictionary<string, string> myDict = new Dictionary<string, string>();

                    foreach (var item in result)

                        try

                        {
                            endpoint = "api/v2/get_case/" + item;
                            GetRequest test = new GetRequest();
                            string responseFromServer3 = test.get(username, password, baseurl, endpoint);
                            //rtb_Console.Text = responseFromServer3;
                            JsonClassCaseDetails.RootObject Obj = JsonConvert.DeserializeObject<JsonClassCaseDetails.RootObject>(responseFromServer3);

                            string suiteID = Obj.suite_id.ToString();
                            string AutomationID = "Not Provided";
                            if (Obj.custom_automated_test_id != null)
                            {
                                AutomationID = Obj.custom_automated_test_id.ToString();
                            }

                            string Automated = "Not Provided";
                            if (Obj.custom_automated != null)
                            {
                                string Automated_int = Obj.custom_automated;

                                switch (Automated_int)
                                {
                                    case "1":
                                        Automated = "No";
                                        break;
                                    case "2":
                                        Automated = "Yes";
                                        break;
                                    case "3":
                                        Automated = "Yes-Requires Update";
                                        break;
                                    case "4":
                                        Automated = "Candidate for Automation";
                                        break;
                                    case "5":
                                        Automated = "No-Reason in Comment";
                                        break;
                                    default:
                                        Automated = "Not Provided";
                                        break;
                                }
                            }
                            string ReleaseOk = "Not Provided";
                            if (Obj.custom_release != null)
                            {
                                string ready = Obj.custom_release;
                                if (ready == "1")
                                {
                                    ReleaseOk = "Yes";
                                }
                                else if (ready == "2")
                                {
                                    ReleaseOk = "No";
                                }
                            }


                            endpoint = "api/v2/get_suite/" + suiteID;
                            GetRequest suite = new GetRequest();
                            string responseFromServer4 = suite.get(username, password, baseurl, endpoint);
                            //rtb_Console.Text = responseFromServer4;
                            JsonClass_SuitesName.RootObject Obj2 = JsonConvert.DeserializeObject<JsonClass_SuitesName.RootObject>(responseFromServer4);

                            string SuiteName = Obj2.name.ToString();
                            string sectionID = Obj.section_id.ToString();

                            string PathName = GetPath(sectionID);

                            myDict.Add(item,SuiteName + "," + PathName +"," + AutomationID+","+Automated+","+ReleaseOk);


                        }
                        catch (WebException Innerexeption)
                        {
                            using (var stream = Innerexeption.Response.GetResponseStream())
                            using (var reader = new StreamReader(stream))
                            {
                                myDict.Add(item, "Invalid Test Case");

                            }
                        }

                    if (myDict!= null)
                    {
                        foreach(string entry in List1)
                        {
                            var preconditon = entry;

                            var pattern = @"\,C(.*?)\,";
                            var matches = Regex.Matches(preconditon, pattern);

                            foreach (Match m in matches)
                            {
                                string path3 = myDict[m.Groups[1].ToString()];
                                FinalList.Add(entry + path3);

                            }
                        }


                        string path = string.Concat(Environment.CurrentDirectory, @"\Output\"+ "Missing PreCondition Path Details" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv");

                        TextWriter tw = new StreamWriter(path);
                        tw.WriteLine("Parent Case,Missing PreCondition,Suite,Path,AutomationID,Automated,Ready For Release");

                        foreach (String s in FinalList)

                        { tw.WriteLine(s); }

                        tw.Close();
                        rtb_Console.AppendText(Environment.NewLine + "Successfully Exported Missing Precondition Path details to: Missing_PreCondition_Path_Details.csv");
                        MessageBox.Show("Missing PreConditions Identified!! See Console for Details!", "Completed!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                    }
                }
            }
            catch (WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    rtb_Console.AppendText(reader.ReadToEnd() + " " + "issue with endpoint: " + endpoint);

                }
            }

        }
        string GetPath(string sectionid)
        {
            string sectionID = sectionid;
            endpoint = "api/v2/get_section/" + sectionID;
            GetRequest section = new GetRequest();
            string responseFromServer5 = section.get(username, password, baseurl, endpoint);
            //rtb_Console.Text = responseFromServer5;

            JsonClassSectionName.RootObject Obj3 = JsonConvert.DeserializeObject<JsonClassSectionName.RootObject>(responseFromServer5);
            Path = " " + ">>" + Obj3.name + Path;
            if (Obj3.parent_id == null)
            {
                string finalPath = Path;
                Path = null;
                return (finalPath);

            }
            else
            {
                return (GetPath(Obj3.parent_id.ToString()));
            }
        }

    }

}
