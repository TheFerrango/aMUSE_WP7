using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using aMUXClasses;
using Newtonsoft.Json;

namespace aMUX
{
  public class Networking
  {
    WebClient wc;

    public Networking()
    {

    }     

    public void SendaSenda(SendingClass ss)
    {
      wc = new WebClient();
      wc.Headers["Content-Type"] = "application/json";
      string jsonFinale = JsonConvert.SerializeObject(ss, Formatting.None);
      //wc.UploadStringAsync(new Uri(""), jsonFinale);
    }
  }
}
