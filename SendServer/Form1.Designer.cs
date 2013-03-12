namespace SendServer
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
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.btnGenerate = new System.Windows.Forms.Button();
      this.progressBar1 = new System.Windows.Forms.ProgressBar();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.btnSend = new System.Windows.Forms.Button();
      this.textBox2 = new System.Windows.Forms.TextBox();
      this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
      this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
      this.saveJSONToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
      this.statusStrip1.SuspendLayout();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
      this.statusStrip1.Location = new System.Drawing.Point(0, 469);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(499, 25);
      this.statusStrip1.TabIndex = 0;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveJSONToFileToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(499, 28);
      this.menuStrip1.TabIndex = 1;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // btnGenerate
      // 
      this.btnGenerate.Location = new System.Drawing.Point(386, 27);
      this.btnGenerate.Name = "btnGenerate";
      this.btnGenerate.Size = new System.Drawing.Size(101, 44);
      this.btnGenerate.TabIndex = 2;
      this.btnGenerate.Text = "GENERATE!";
      this.btnGenerate.UseVisualStyleBackColor = true;
      this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
      // 
      // progressBar1
      // 
      this.progressBar1.Location = new System.Drawing.Point(12, 27);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new System.Drawing.Size(368, 44);
      this.progressBar1.TabIndex = 3;
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(128, 91);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(224, 22);
      this.textBox1.TabIndex = 4;
      this.textBox1.Text = "http://";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(13, 94);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(109, 17);
      this.label1.TabIndex = 5;
      this.label1.Text = "Server address:";
      // 
      // btnSend
      // 
      this.btnSend.Location = new System.Drawing.Point(358, 77);
      this.btnSend.Name = "btnSend";
      this.btnSend.Size = new System.Drawing.Size(129, 50);
      this.btnSend.TabIndex = 6;
      this.btnSend.Text = "SEND! SEND!";
      this.btnSend.UseVisualStyleBackColor = true;
      this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
      // 
      // textBox2
      // 
      this.textBox2.Location = new System.Drawing.Point(16, 133);
      this.textBox2.Multiline = true;
      this.textBox2.Name = "textBox2";
      this.textBox2.ReadOnly = true;
      this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.textBox2.Size = new System.Drawing.Size(471, 336);
      this.textBox2.TabIndex = 7;
      // 
      // backgroundWorker1
      // 
      this.backgroundWorker1.WorkerReportsProgress = true;
      this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
      // 
      // lblStatus
      // 
      this.lblStatus.Name = "lblStatus";
      this.lblStatus.Size = new System.Drawing.Size(66, 20);
      this.lblStatus.Text = "lblStatus";
      // 
      // saveJSONToFileToolStripMenuItem
      // 
      this.saveJSONToFileToolStripMenuItem.Name = "saveJSONToFileToolStripMenuItem";
      this.saveJSONToFileToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
      this.saveJSONToFileToolStripMenuItem.Text = "Save JSON to file";
      this.saveJSONToFileToolStripMenuItem.Click += new System.EventHandler(this.saveJSONToFileToolStripMenuItem_Click);
      // 
      // saveFileDialog1
      // 
      this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(499, 494);
      this.Controls.Add(this.textBox2);
      this.Controls.Add(this.btnSend);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.progressBar1);
      this.Controls.Add(this.btnGenerate);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "Form1";
      this.Text = "Create JSON";
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.Button btnGenerate;
    private System.Windows.Forms.ProgressBar progressBar1;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnSend;
    private System.Windows.Forms.TextBox textBox2;
    private System.ComponentModel.BackgroundWorker backgroundWorker1;
    private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    private System.Windows.Forms.ToolStripMenuItem saveJSONToFileToolStripMenuItem;
    private System.Windows.Forms.SaveFileDialog saveFileDialog1;
  }
}

