using System.Windows;
using aMUXClasses;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Zel10Support;
using System.Windows.Media.Imaging;
using System;

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
      operaTitle.Text = iis.title;
      operaTitleAdv.Text = iis.title;
      operaData.Text = iis.release_date;
      operaAuth.Text = iis.author;
      operaDesc.Text = iis.description;
      imgOperaBig.Source = new BitmapImage(NetworkAddresses.ObtainItemPicture(iis.photo));
    }
  }
}