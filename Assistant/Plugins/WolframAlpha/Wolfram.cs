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

        public string[] simpleQuery(string query)
        {
            //Then you simply query Wolfram|Alpha like this
            //Note that the spelling error will be correct by Wolfram|Alpha
            QueryResult results = wolfram.Query(query);
            string[] ret = new string[2];

            StringBuilder sb = new StringBuilder();
            //The QueryResult object contains the parsed XML from Wolfram|Alpha. Lets look at it.
            //The results from wolfram is split into "pods". We just print them.
            if (results != null)
            {
                if (results.DidYouMean != null)
                    throw new AmbiguousQueryException("Intended meaning of query ambiguous.", results.DidYouMean.ToArray<WolframAlphaNET.Objects.DidYouMean>());

                // Get the summary, to speak
                Pod inputinterp = results.Pods.ElementAt(0);
                ret[0] = inputinterp.Title + ":\n";
                foreach (SubPod sp in inputinterp.SubPods)
                {
                    ret[0] += sp.Title + "\n";
                    ret[0] += sp.Plaintext + "\n";
                }
                ret[0] += "\n";
                Pod res = results.Pods.ElementAt(1);
                ret[0] += res.Title + ":\n";
                foreach (SubPod sp in res.SubPods)
                {
                    ret[0] += sp.Title + "\n";
                    ret[0] += sp.Plaintext + "\n";
                }
                
                // get all results
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
            ret[1] = sb.ToString();
            return ret;
        }
    }
}
