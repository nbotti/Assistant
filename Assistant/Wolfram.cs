using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolframAlphaNET;
using WolframAlphaNET.Misc;
using WolframAlphaNET.Objects;


namespace Assistant
{
    class Wolfram
    {
        private WolframAlpha wolfram;

        public Wolfram()
        {
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "wolframapikey.txt");
                wolfram = new WolframAlpha(sr.ReadLine());
            }
            catch
            {
                throw new Exception("API Key not found or not valid at: " + AppDomain.CurrentDomain.BaseDirectory + "wolframapikey.txt");
            }
            finally
            {
                sr.Close();
            }
        }

        public string simpleQuery(string query)
        {
            //Then you simply query Wolfram|Alpha like this
            //Note that the spelling error will be correct by Wolfram|Alpha
            QueryResult results = wolfram.Query(query);

            StringBuilder sb = new StringBuilder();
            //The QueryResult object contains the parsed XML from Wolfram|Alpha. Lets look at it.
            //The results from wolfram is split into "pods". We just print them.
            if (results != null)
            {
                foreach (Pod pod in results.Pods)
                {
                    sb.AppendLine(pod.Title);
                    if (pod.SubPods != null)
                    {
                        foreach (SubPod subPod in pod.SubPods)
                        {
                            sb.AppendLine(subPod.Title);
                            sb.AppendLine(subPod.Plaintext);
                        }
                    }
                }
            }
            return sb.ToString();
        }
    }
}
