
namespace VirtualAssistant
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ListCommands = new System.Windows.Forms.ListBox();
            this.SpeakTimer = new System.Windows.Forms.Timer(this.components);
            this.SpeakBar = new System.Windows.Forms.ProgressBar();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // ListCommands
            // 
            this.ListCommands.FormattingEnabled = true;
            this.ListCommands.Location = new System.Drawing.Point(3, 42);
            this.ListCommands.Name = "ListCommands";
            this.ListCommands.Size = new System.Drawing.Size(96, 342);
            this.ListCommands.TabIndex = 0;
            this.ListCommands.Visible = false;
            // 
            // SpeakTimer
            // 
            this.SpeakTimer.Enabled = true;
            this.SpeakTimer.Interval = 1000;
            this.SpeakTimer.Tick += new System.EventHandler(this.SpeakTimer_Tick);
            // 
            // SpeakBar
            // 
            this.SpeakBar.Location = new System.Drawing.Point(156, 367);
            this.SpeakBar.Name = "SpeakBar";
            this.SpeakBar.Size = new System.Drawing.Size(368, 15);
            this.SpeakBar.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(156, 42);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(368, 319);
            this.flowLayoutPanel1.TabIndex = 4;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 419);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.SpeakBar);
            this.Controls.Add(this.ListCommands);
            this.Name = "Form1";
            this.Text = "Virtual Assistant";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ListCommands;
        private System.Windows.Forms.Timer SpeakTimer;
        private System.Windows.Forms.ProgressBar SpeakBar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}

