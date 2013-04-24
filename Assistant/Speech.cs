using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace Assistant
{
    class Speech
    {
        private SpeechRecognitionEngine sr;
        private SpeechSynthesizer ss;
        private string temp;

        public Speech()
        {
            sr = new SpeechRecognitionEngine();
            ss = new SpeechSynthesizer();
            sr.SetInputToDefaultAudioDevice();
            ss.SelectVoice("Microsoft Anna");
            ss.SetOutputToDefaultAudioDevice();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gram"></param>
        /// <returns></returns>
        public string recognizeOneWordFromGrammer(String[] gram)
        {
            // Create a simple grammar
            Choices colors = new Choices();
            colors.Add(gram);

            // Create a GrammarBuilder object and append the Choices object.
            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(colors);

            // Create the Grammar instance and load it into the speech recognition engine.
            Grammar g = new Grammar(gb);
            sr.UnloadAllGrammars();
            sr.LoadGrammar(g);

            // Register a handler for the SpeechRecognized event.
            sr.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(rec_SpeechRecognized);
            sr.RecognizeAsync();

            return temp;
        }

        public string recognizeDictation()
        {
            // Use the dictationgrammer, which allows free text
            Grammar g = new DictationGrammar();
            sr.UnloadAllGrammars();
            sr.LoadGrammar(g);

            // Register a handler for the SpeechRecognized event.
            sr.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(rec_SpeechRecognized);
            sr.Recognize();

            return temp;
        }

        public void listenForWord(string word)
        {
            // Create a simple grammar
            Choices colors = new Choices();
            colors.Add(word);

            // Create a GrammarBuilder object and append the Choices object.
            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(colors);

            // Create the Grammar instance and load it into the speech recognition engine.
            Grammar g = new Grammar(gb);
            sr.UnloadAllGrammars();
            sr.LoadGrammar(g);
            sr.Recognize();
        }

        public void talk(string text)
        {
            ss.Speak(text);
        }

        void rec_SpeechRecognized(object sender, RecognitionEventArgs e)
        {
            temp = e.Result.Text;
            sr.SpeechRecognized -= this.rec_SpeechRecognized;
        }
    }
}
