namespace Assistant
{
    partial class AssistantForm
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
            this.ask = new System.Windows.Forms.Button();
            this.results = new System.Windows.Forms.TextBox();
            this.listenforanna = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ask
            // 
            this.ask.Location = new System.Drawing.Point(13, 13);
            this.ask.Name = "ask";
            this.ask.Size = new System.Drawing.Size(154, 23);
            this.ask.TabIndex = 0;
            this.ask.Text = "Ask Wolfram Something";
            this.ask.UseVisualStyleBackColor = true;
            this.ask.Click += new System.EventHandler(this.ask_Click);
            // 
            // results
            // 
            this.results.Location = new System.Drawing.Point(13, 43);
            this.results.Multiline = true;
            this.results.Name = "results";
            this.results.Size = new System.Drawing.Size(537, 460);
            this.results.TabIndex = 1;
            this.results.Text = "Your results will be displayed here, and spoken aloud.";
            // 
            // listenforanna
            // 
            this.listenforanna.Location = new System.Drawing.Point(174, 13);
            this.listenforanna.Name = "listenforanna";
            this.listenforanna.Size = new System.Drawing.Size(116, 23);
            this.listenforanna.TabIndex = 2;
            this.listenforanna.Text = "Listen for \"Anna\"";
            this.listenforanna.UseVisualStyleBackColor = true;
            this.listenforanna.Click += new System.EventHandler(this.listenforanna_Click);
            // 
            // AssistantForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 515);
            this.Controls.Add(this.listenforanna);
            this.Controls.Add(this.results);
            this.Controls.Add(this.ask);
            this.Name = "AssistantForm";
            this.Text = "AssistantForm";
            this.Load += new System.EventHandler(this.AssistantForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ask;
        private System.Windows.Forms.TextBox results;
        private System.Windows.Forms.Button listenforanna;
    }
}