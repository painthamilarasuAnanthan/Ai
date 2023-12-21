
using myfirstAiassistant;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Collections.Generic;


namespace myfirstAiassistant
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer s = new SpeechSynthesizer();
        Choices list = new Choices();
        public Form1()
        {
            SpeechRecognitionEngine rec = new SpeechRecognitionEngine();
            list.Add(new string[] {"hello" , "how are you" ,"open my chat gpt"});
            Grammar gr = new Grammar(new GrammarBuilder(list));

            try
            {
                rec.RequestRecognizerUpdate();
                rec.LoadGrammar(gr);
                rec.SpeechRecognized += Rec_SpeechRecognized;
                rec.SetInputToDefaultAudioDevice();
                rec.RecognizeAsync(RecognizeMode.Multiple);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }



            s.SelectVoiceByHints(VoiceGender.Female);

            //s.Speak("hello tamil i am dharane your lovely wife");
            s.Speak("hello tamil i am your first AI personal assistant");
            InitializeComponent();
        }


        public void says(string h)
        {
            s.Speak(h);
        }

        private void Rec_SpeechRecognized(object? sender, SpeechRecognizedEventArgs e)
        {
            string r = e.Result.Text;

            if(r == "hello")
            {
                says("hii tamil");

            }
            if (r == "how are you ")
            {
                says(" i am fine you");

            }
            if (r == "open my chat gpt")
                says(" what kind of help you need?");


        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

