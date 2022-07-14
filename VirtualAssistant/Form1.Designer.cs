
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ListCommands = new System.Windows.Forms.ListBox();
            this.SpeakTimer = new System.Windows.Forms.Timer(this.components);
            this.SpeakBar = new System.Windows.Forms.ProgressBar();
            this.DevModeButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MicButton = new System.Windows.Forms.Button();
            this.MessageBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListCommands
            // 
            this.ListCommands.FormattingEnabled = true;
            this.ListCommands.HorizontalScrollbar = true;
            this.ListCommands.Location = new System.Drawing.Point(12, 100);
            this.ListCommands.Name = "ListCommands";
            this.ListCommands.Size = new System.Drawing.Size(128, 394);
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
            this.SpeakBar.Location = new System.Drawing.Point(12, 87);
            this.SpeakBar.Name = "SpeakBar";
            this.SpeakBar.Size = new System.Drawing.Size(128, 15);
            this.SpeakBar.TabIndex = 1;
            this.SpeakBar.Visible = false;
            this.SpeakBar.Click += new System.EventHandler(this.SpeakBar_Click);
            // 
            // DevModeButton
            // 
            this.DevModeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DevModeButton.BackgroundImage")));
            this.DevModeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DevModeButton.Location = new System.Drawing.Point(12, 12);
            this.DevModeButton.Name = "DevModeButton";
            this.DevModeButton.Size = new System.Drawing.Size(24, 21);
            this.DevModeButton.TabIndex = 5;
            this.DevModeButton.UseVisualStyleBackColor = true;
            this.DevModeButton.Click += new System.EventHandler(this.DevModeButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(137, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(596, 81);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.MicButton);
            this.panel1.Controls.Add(this.MessageBox);
            this.panel1.Location = new System.Drawing.Point(156, 446);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(563, 48);
            this.panel1.TabIndex = 7;
            // 
            // MicButton
            // 
            this.MicButton.Location = new System.Drawing.Point(3, 3);
            this.MicButton.Name = "MicButton";
            this.MicButton.Size = new System.Drawing.Size(56, 43);
            this.MicButton.TabIndex = 1;
            this.MicButton.UseVisualStyleBackColor = true;
            // 
            // MessageBox
            // 
            this.MessageBox.BackColor = System.Drawing.SystemColors.Window;
            this.MessageBox.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageBox.Location = new System.Drawing.Point(62, 3);
            this.MessageBox.Multiline = true;
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MessageBox.Size = new System.Drawing.Size(498, 43);
            this.MessageBox.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 443F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(156, 87);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(563, 356);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(829, 507);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DevModeButton);
            this.Controls.Add(this.SpeakBar);
            this.Controls.Add(this.ListCommands);
            this.Name = "Form1";
            this.Text = "Virtual Assistant";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ListCommands;
        private System.Windows.Forms.Timer SpeakTimer;
        private System.Windows.Forms.ProgressBar SpeakBar;
        private System.Windows.Forms.Button DevModeButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button MicButton;
        private System.Windows.Forms.TextBox MessageBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

