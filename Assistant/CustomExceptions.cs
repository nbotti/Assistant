using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assistant
{

    [Serializable]
    public class AmbiguousQueryException : Exception
    {
        public AmbiguousQueryException(string message, WolframAlphaNET.Objects.DidYouMean[] didYouMeans)
            : base(message)
        {
            DidYouMeans = didYouMeans;
        }

        public WolframAlphaNET.Objects.DidYouMean[] DidYouMeans { get; private set; }
    }


}
