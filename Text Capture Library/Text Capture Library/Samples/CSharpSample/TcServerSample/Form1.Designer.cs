namespace TcServerSample
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAbout = new System.Windows.Forms.Button();
            this.txtHandle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCapture = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAbout);
            this.panel1.Controls.Add(this.txtHandle);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnCapture);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 194);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(509, 72);
            this.panel1.TabIndex = 0;
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(324, 23);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(182, 23);
            this.btnAbout.TabIndex = 3;
            this.btnAbout.Text = "About TextCapatureLib";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // txtHandle
            // 
            this.txtHandle.Location = new System.Drawing.Point(103, 25);
            this.txtHandle.Name = "txtHandle";
            this.txtHandle.Size = new System.Drawing.Size(100, 21);
            this.txtHandle.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Window Handle";
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(209, 24);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(109, 23);
            this.btnCapture.TabIndex = 0;
            this.btnCapture.Text = "Capture It!";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(509, 194);
            this.textBox1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 266);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "TextCapture COM Library Sample for C#";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.TextBox txtHandle;
        private System.Windows.Forms.Label label1;
    }
}

