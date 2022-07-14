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
using System.Reflection;

namespace VirtualAssistant
{
    public partial class Form1 : Form
    {
        // underscore means its global
        SpeechRecognitionEngine _recognizer = new SpeechRecognitionEngine();
        SpeechSynthesizer VoiceAssistant = new SpeechSynthesizer();
        // this is optional, only to be able to start and stop the speech recognition
        SpeechRecognitionEngine startListening = new SpeechRecognitionEngine();

        // so the assistant will be able to respond to a new speech after a period of time
        int RecTimeOut = 0;

        DateTime CurrentTime = DateTime.Now;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.Paint += new PaintEventHandler(this.tableLayoutPanel1_Paint);
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

            AssistantSpeechBubble("Is this the start?");
            UserSpeechBubble("Maybe");
            AssistantSpeechBubble("I don't think so");
            UserSpeechBubble("ye");
            AssistantSpeechBubble("What the fuck are you talking about?");
            UserSpeechBubble("You dumb");
        }

        private void Default_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
            UserSpeechBubble(speech);
            string[] GratitudeResponses = { "Your Welcome.", "No Problem." };
            string[] StoppedResponses = { "Ok.", "Yes?" };
            Random random = new Random();
            switch (speech)
            {
                case "hello":
                case "hi":
                case "greetings":
                    AssistantSpeechBubble("Hello, I am your Virtual Assistant. \nHow can I help you?");
                    break;
                case "how are you":
                    AssistantSpeechBubble("I am working fine, thank you for asking.");
                    break;
                case "what time is it":
                case "what is the current time":
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
                    AssistantSpeechBubble(voice);
                    break;
                case "thanks":
                case "thank you":
                    int resForGratitude = random.Next(GratitudeResponses.Length);
                    AssistantSpeechBubble(GratitudeResponses[resForGratitude]);
                    break;
                case "stop talking":
                    // abruptly stop the voice from speaking
                    VoiceAssistant.SpeakAsyncCancelAll();
                    int resForStop = random.Next(StoppedResponses.Length);
                    AssistantSpeechBubble(StoppedResponses[resForStop]);
                    break;
                case "stop listening":
                    // temporarily stop to recognize speeches
                    AssistantSpeechBubble("I will shut my ears now. Just say \"Start\" and I will hear you again.");
                    _recognizer.RecognizeAsyncCancel();
                    startListening.RecognizeAsync(RecognizeMode.Multiple);
                    break;
                case "show speeches":
                case "show available speeches":
                case "what are the available speeches":
                    AssistantSpeechBubble("Showing all the available speeches..");
                    string[] speeches = (File.ReadAllLines(@"Speeches.txt"));
                    ListCommands.Items.Clear();
                    ListCommands.SelectionMode = SelectionMode.None;
                    ListCommands.Visible = true;
                    foreach (string items in speeches)
                    {
                        ListCommands.Items.Add(items);
                    }
                    break;
                case "what are the available courses":
                case "show available courses":
                case "available courses":
                case "courses":
                case "course":
                    AssistantSpeechBubble("COURSES AVAILABLE IN DHVSU PORAC CAMPUS\n" +
                        "Bachelor of Elementary Education Major in General Education\n" +
                        "Bachelor of Science in Business Administration Major in Marketing\n" +
                        "Bachelor of Science in Information Technology\n" +
                        "Bachelor of Science in Social Work");
                    break;
                case "hide speeches":
                case "hide it":
                    ListCommands.Visible = false;
                    AssistantSpeechBubble("Speeches has been hidden.");
                    break;
            }
        }

        public static class MessagePosition
        {
            public static int AssistantRow = 0;
            public static int UserRow = 1;
        }
        private void UserSpeechBubble(string words)
        {
            Label Bubble = new Label();
            Bubble.Text = words;

            Bubble.Margin = new Padding(5);
            Bubble.Padding = new Padding(5, 15, 5, 15);
            Bubble.Anchor = AnchorStyles.Left;
            Bubble.BackColor = Color.DodgerBlue;
            Bubble.Size = new Size(135, 33);
            Bubble.ForeColor = SystemColors.Control;
            Bubble.AutoSize = true;
            Bubble.Font = new Font("Candara", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            tableLayoutPanel1.Controls.Add(Bubble, 1, MessagePosition.AssistantRow);
            Controls.Add(tableLayoutPanel1);
            Console.WriteLine("User said: " + words);
            MessagePosition.AssistantRow = MessagePosition.AssistantRow + 1;

            tableLayoutPanel1.ScrollControlIntoView(Bubble);
        }
        private void AssistantSpeechBubble(string words)
        {
            Label Bubble = new Label();
            Bubble.Text = words;

            Bubble.Margin = new Padding(5);
            Bubble.Padding = new Padding(5, 15, 5, 15);
            Bubble.Anchor = AnchorStyles.Right;
            Bubble.BackColor = Color.LightSeaGreen;
            Bubble.Size = new Size(135, 33);
            Bubble.ForeColor = SystemColors.Control;
            Bubble.AutoSize = true;
            Bubble.Font = new Font("Candara", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            tableLayoutPanel1.Controls.Add(Bubble, 1, MessagePosition.AssistantRow);
            Controls.Add(tableLayoutPanel1);
            VoiceAssistant.SpeakAsync(words);
            Console.WriteLine("Assistant said: " + words);
            MessagePosition.AssistantRow = MessagePosition.AssistantRow + 1;

            tableLayoutPanel1.ScrollControlIntoView(Bubble);
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

            Color color = Color.Orange;
            ButtonBorderStyle bbs = ButtonBorderStyle.Solid;
            int thiccness = 4;
            ControlPaint.DrawBorder(e.Graphics, this.tableLayoutPanel1.ClientRectangle,
                color, thiccness, bbs, color, thiccness, bbs, color, thiccness, bbs, color, thiccness, bbs);
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
                AssistantSpeechBubble("Greetings, I am back. What can I do for you?");
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

        private void DevModeButton_Click(object sender, EventArgs e)
        {
            if (SpeakBar.Visible == true && ListCommands.Visible == true)
            {
                SpeakBar.Visible = false;
                ListCommands.Visible = false;
            } else
            {
                SpeakBar.Visible = true;
                string[] speeches = (File.ReadAllLines(@"Speeches.txt"));
                ListCommands.Items.Clear();
                ListCommands.SelectionMode = SelectionMode.None;
                ListCommands.Visible = true;
                foreach (string items in speeches)
                {
                    ListCommands.Items.Add(items);
                }
            }
        }

        private void SpeakBar_Click(object sender, EventArgs e)
        {

        }
    }
}
