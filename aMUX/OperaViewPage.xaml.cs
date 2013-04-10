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
using aMUXClasses;
using Microsoft.Phone.Shell;

namespace aMUX
{
  public partial class OperaViewPage : PhoneApplicationPage
  {
    ItemInfos iis;

    public OperaViewPage()
    {
      InitializeComponent();
      iis = PhoneApplicationService.Current.State["ItemInfo"] as ItemInfos;
      PhoneApplicationService.Current.State.Clear();
    }

    private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
    {
      //TODO: add image loading
      listAbout.Items.Add(string.Format("{0}: {1}", Languages.LangsRes.ovpTitle, iis.title));
      listAbout.Items.Add(string.Format("{0}: {1}", Languages.LangsRes.pvtData, iis.release_date));
      listAbout.Items.Add(string.Format("{0}: {1}", Languages.LangsRes.ovpAuth, iis.author));
      listAbout.Items.Add(string.Format("{0}: {1}", Languages.LangsRes.ovpDesc, iis.description));
    }

    
  }
}