using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using aMUXClasses;
using System.IO;
using Newtonsoft.Json;
using System.Net;

namespace SendServer
{
  public partial class Form1 : Form
  {
    string jsonFinale;

    public Form1()
    {
      InitializeComponent();
      backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
      backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
    }

    void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      lblStatus.Text = "JSON generation completed.";
      textBox2.Text = jsonFinale;
    }

    void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      progressBar1.Value=e.ProgressPercentage;
    }

    private void btnSend_Click(object sender, EventArgs e)
    {
    //http://10.23.3.102:8000/api/save/
  
        WebClient wc = new WebClient();
        wc.UploadStringCompleted += new UploadStringCompletedEventHandler(wc_UploadStringCompleted);
        wc.Headers["Content-Type"] = "application/json";
        lblStatus.Text = "Now attempting to send JSON.";

        try
        {
          wc.UploadStringAsync(new Uri(textBox1.Text), jsonFinale);
        }
        catch {
          lblStatus.Text = "Failed miserably.";
        }
     
    }

    void wc_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
    {
      if (e.Error != null)
        lblStatus.Text = "Failed miserably";
      else
        lblStatus.Text = "Huge success!";

    }

    private void btnGenerate_Click(object sender, EventArgs e)
    {
      jsonFinale = "";
      progressBar1.Maximum = 100;
      progressBar1.Value = 0;
      lblStatus.Text = "Now generating JSON.";
      backgroundWorker1.RunWorkerAsync();
    }

    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
      SendingClass sc = new SendingClass();
      backgroundWorker1.ReportProgress(Convert.ToInt32((1.0/11)*100));
      List<Personal> lp = new List<Personal>();
      backgroundWorker1.ReportProgress(Convert.ToInt32((2.0 / 11) * 100));
      lp.Add(new Personal("bingo bongo"));
      backgroundWorker1.ReportProgress(Convert.ToInt32((3.0 / 11) * 100));
      string foto_conv = Convert.ToBase64String(File.ReadAllBytes("Images/testImg.jpg"));
      backgroundWorker1.ReportProgress(Convert.ToInt32((4.0 / 11) * 100));
      lp.Add(new Scan("55", "woow"));
      backgroundWorker1.ReportProgress(Convert.ToInt32((5.0 / 11) * 100));
      lp.Add(new Scan("42"));
      backgroundWorker1.ReportProgress(Convert.ToInt32((6.0 / 11) * 100));
      lp.Add(new Personal("vermi!", foto_conv));
      backgroundWorker1.ReportProgress(Convert.ToInt32((7.0 / 11) * 100));
      sc.confirm = "44221100";
      backgroundWorker1.ReportProgress(Convert.ToInt32((8.0 / 11) * 100));
      sc.email = "gpinelli@excite.it";
      backgroundWorker1.ReportProgress(Convert.ToInt32((9.0 / 11) * 100));
      sc.exp = lp;
      backgroundWorker1.ReportProgress(Convert.ToInt32((10.0 / 11) * 100));
      jsonFinale = JsonConvert.SerializeObject(sc, Formatting.None);
      backgroundWorker1.ReportProgress(Convert.ToInt32((11.0 / 11) * 100));
    }

    private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
    {
      File.WriteAllText(saveFileDialog1.FileName, jsonFinale);
    }

    private void saveJSONToFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
      saveFileDialog1.ShowDialog();
    }
  }
}
