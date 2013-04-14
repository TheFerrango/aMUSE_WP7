using System.Windows;
using aMUXClasses;
using Microsoft.Phone.Controls;
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