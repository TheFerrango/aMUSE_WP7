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

namespace aMUX
{
  public partial class OperaViewPage : PhoneApplicationPage
  {
    ItemInfos iis;

    public OperaViewPage()
    {
      InitializeComponent();
      iis = new ItemInfos() { author = "Blk", description="The greatest bongo ever", release_date="28/10/1971", title="BonGold" };
    }

    private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
    {
      //TODO: add image loading

      listAbout.Items.Add(iis.title);
      listAbout.Items.Add(iis.release_date);
      listAbout.Items.Add(iis.author);
      listAbout.Items.Add(iis.description);
    }

    
  }
}