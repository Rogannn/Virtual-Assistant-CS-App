using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;

namespace VirtualAssistant
{
    public partial class Form1 : Form
    {
        // underscore means its global
        SpeechRecognitionEngine _recognizer = new SpeechRecognitionEngine();
        SpeechSynthesizer VoiceAssistant = new SpeechSynthesizer();
        // this is optional, only to be able to start and stop the speech recognition
        SpeechRecognitionEngine startListening = new SpeechRecognitionEngine();

        Random rand = new Random();
        // so the assistant will be able to respond to a new speech after a period of time
        int RecTimeOut = 0;

        DateTime CurrentTime = DateTime.Now;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _recognizer.SetInputToDefaultAudioDevice();
            _recognizer.LoadGrammarAsync(
                new Grammar(
                    new GrammarBuilder(
                        new Choices(File.ReadAllLines(@"Speeches.txt")))));
            _recognizer.SpeechRecognized += new EventHandler
                <SpeechRecognizedEventArgs>(Default_SpeechRecognized);
            _recognizer.SpeechDetected += new EventHandler
                <SpeechDetectedEventArgs>(_recognizer_SpeechRecognized);
            _recognizer.RecognizeAsync(RecognizeMode.Multiple);
            _recognizer.AudioLevelUpdated += new EventHandler
                <AudioLevelUpdatedEventArgs>(_recognizer_AudioLevelUpdated);

            startListening.SetInputToDefaultAudioDevice();
            startListening.LoadGrammarAsync(
                new Grammar(
                    new GrammarBuilder(
                        new Choices(File.ReadAllLines(@"Speeches.txt")))));
            startListening.SpeechRecognized += new EventHandler
                <SpeechRecognizedEventArgs>(startListening_SpeechRecognized);
        }

        private void Default_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            int randNum;
            string speech = e.Result.Text;
            UserSpeechBubble(speech);

            if (speech == "hello" || speech == "hi" || speech == "greetings")
            {
                string voice = "Hello, I am your Virtual Assistant. \nHow can I help you?";
                AssistantSpeechBubble(voice, true);
            }
            if (speech == "how are you")
            {
                string voice = "I am working fine, thank you for asking.";
                AssistantSpeechBubble(voice, true);
            }
            if (speech == "what time is it" || speech == "what is the current time")
            {
                // string getTime = DateTime.Now.ToString("h: mm tt");
                string getTime = DateTime.Now.ToString("h: mm tt");
                string est = "";
                if (getTime.Contains("pm"))
                {
                    est = " in the evening.";
                }
                if (getTime.Contains("am"))
                {
                    est = " in the morning.";
                }
                string voice = "It is currently " + getTime + est;
                AssistantSpeechBubble(voice, true);
            }
            // to abruptly stop the voice from speaking
            if (speech == "stop talking")
            {
                VoiceAssistant.SpeakAsyncCancelAll();
                // randomly choose which voice to respond
                randNum = rand.Next(1, 2);
                if (randNum == 1)
                {
                    string voice = "Ok.";
                    AssistantSpeechBubble(voice, true);
                }
                if (randNum == 2)
                {
                    string voice = "Yes?";
                    AssistantSpeechBubble(voice, true);
                }
            }
            if (speech == "stop listening")
            {
                string voice = "I will shut my ears now. Just say \"Start\" and I will hear you again.";
                AssistantSpeechBubble(voice, true);
                _recognizer.RecognizeAsyncCancel();
                startListening.RecognizeAsync(RecognizeMode.Multiple);
            }
            if (speech == "show speeches" || speech == "show available speeches" || speech == "what are the available speeches")
            {
                string voice = "Showing all the available speeches..";
                AssistantSpeechBubble(voice, true);
                string[] speeches = (File.ReadAllLines(@"Speeches.txt"));
                ListCommands.Items.Clear();
                ListCommands.SelectionMode = SelectionMode.None;
                ListCommands.Visible = true;
                foreach (string items in speeches)
                {
                    ListCommands.Items.Add(items);
                }
            }
            if (speech == "hide speeches" || speech == "hide it")
            {
                ListCommands.Visible = false;
                string voice = "Speeches has been hidden.";
                AssistantSpeechBubble(voice, true);
            }
        }

        private void UserSpeechBubble(string words)
        {
            Label Bubble = new Label();
            Bubble.Text = words;

            Bubble.Margin = new Padding(13, 13, 150, 13);
            Bubble.Padding = new Padding(8, 15, 8, 15);
            Bubble.Anchor = AnchorStyles.Left;
            Bubble.BackColor = Color.DodgerBlue;
            Bubble.Size = new Size(135, 33);
            Bubble.ForeColor = SystemColors.Control;
            Bubble.AutoSize = true;
            Bubble.Font = new Font("Elephant", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            flowLayoutPanel1.Controls.Add(Bubble);
            Console.WriteLine("User said: " + words);
        }
        private void AssistantSpeechBubble(string words, bool show)
        {
            Label Bubble = new Label();
            Bubble.Text = words;

            Bubble.Margin = new Padding(150, 13, 13, 13);
            Bubble.Padding = new Padding(8, 15, 8, 15);
            Bubble.Anchor = AnchorStyles.Right;
            Bubble.BackColor = Color.SteelBlue;
            Bubble.Size = new Size(135, 33);
            Bubble.ForeColor = SystemColors.Control;
            Bubble.AutoSize = true;
            Bubble.Font = new Font("Elephant", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            flowLayoutPanel1.Controls.Add(Bubble);
            VoiceAssistant.SpeakAsync(words);
            Console.WriteLine("Voice Assistant said: " + words);
        }

        private void _recognizer_SpeechRecognized(object sender, SpeechDetectedEventArgs e)
        {
            RecTimeOut = 0;
        }
        private void startListening_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
            if (speech == "start")
            {
                startListening.RecognizeAsyncCancel();
                VoiceAssistant.SpeakAsync("Greetings, I am back. What can I do for you?");
                _recognizer.RecognizeAsync(RecognizeMode.Multiple);
            }
        }

        private void SpeakTimer_Tick(object sender, EventArgs e)
        {
            if (RecTimeOut == 10)
            {
                _recognizer.RecognizeAsyncCancel();
            }
            else if (RecTimeOut > 10) 
            {
                SpeakTimer.Stop();
                // restart the timer after hearing another speech
                startListening.RecognizeAsync(RecognizeMode.Multiple);
                RecTimeOut = 0;
            }
        }
        private void _recognizer_AudioLevelUpdated(object sender, AudioLevelUpdatedEventArgs e)
        {
            SpeakBar.Value = e.AudioLevel;
        }

    }
}
