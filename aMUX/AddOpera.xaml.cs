using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using com.google.zxing.qrcode;
using Microsoft.Devices;
using com.google.zxing.common;
using com.google.zxing;
using System.Windows.Navigation;
using Microsoft.Phone.Shell;

namespace aMUX
{
  public partial class AddOpera : PhoneApplicationPage
  {
    string operaQR;
    
    public AddOpera()
    {
      InitializeComponent();
      operaQR = PhoneApplicationService.Current.State["OperaQR"] as string;
      PhoneApplicationService.Current.State["OperaQR"] = null;
      qrTxtCode.Text = operaQR;
    }

  }
}