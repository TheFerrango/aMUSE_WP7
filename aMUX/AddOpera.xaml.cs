using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using aMUXClasses;
using Coding4Fun.Toolkit.Controls;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using Zel10Support;

namespace aMUX
{
  public partial class AddOpera : PhoneApplicationPage
  {
    #region Constructor and variables

    Zel10Net NetMan;

    string operaQR;
    string photoB64;
    InputPrompt ip;
    ItemInfos itemInfo;

    public AddOpera()
    {
      InitializeComponent();
      photoB64 = "";
      NetMan = new Zel10Net();
      NetMan.BatchOperationCompleted += new Zel10Net.BatchOperationCompletedHandler(NetMan_BatchOperationCompleted);
      operaQR = PhoneApplicationService.Current.State["OperaQR"] as string;
      PhoneApplicationService.Current.State.Clear();
    }

    #endregion

    #region Populating boxes on page load

    private void PhoneApplicationPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
      LoadBar.IsIndeterminate = true;
      NetMan.AddNetJob(new GetItemInformation(operaQR));
      NetMan.Execute();
      operaPicBox.Source = new BitmapImage(new Uri("http://www.independent.co.uk/incoming/article8389795.ece/ALTERNATES/w460/BerlusconiGET.jpg"));
    }

    void NetMan_BatchOperationCompleted(object sender, System.Collections.Generic.List<string> results)
    {
      LoadBar.IsIndeterminate = false;
      if (results[0] != "FAIL")
      {
        itemInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<ItemInfos>(results[0]);
        operaQR = itemInfo.id;
        operaPicBox.Source = new BitmapImage(NetworkAddresses.ObtainItemPicture(itemInfo.photo));
      }
      else
      {
        MessageBox.Show(Languages.LangsRes.ErrorFailRetrieve, Languages.LangsRes.ErrorTit, MessageBoxButton.OK);
      }
    }

    #endregion

    #region Personal comment

    private void ScrollViewer_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      ip = new InputPrompt();
      ip.Title = Languages.LangsRes.lblComment;
      ip.Value = textPrevBox.Text;
      ip.Completed += new EventHandler<PopUpEventArgs<string, PopUpResult>>(ip_Completed);
      ip.Show();
    }

    void ip_Completed(object sender, PopUpEventArgs<string, PopUpResult> e)
    {
      if (e.PopUpResult == PopUpResult.Ok)
      {
        imgAddComm.Visibility = System.Windows.Visibility.Collapsed;
        textPrevBox.Text = e.Result;
      }
    }

    #endregion

    #region Personal photo

    private void picPrevBox_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      PhotoChooserTask pct = new PhotoChooserTask() { ShowCamera = true, PixelHeight = 480, PixelWidth = 640 };
      pct.Completed += new EventHandler<PhotoResult>(pct_Completed);
      pct.Show();
    }

    void pct_Completed(object sender, PhotoResult e)
    {
      if (e.TaskResult == TaskResult.OK)
      {
        photoStackPan.Visibility = System.Windows.Visibility.Visible;
        BitmapImage bImg = new BitmapImage();
        bImg.SetSource(e.ChosenPhoto);
        picPrevBox.Source = bImg;

        byte[] b = new byte[e.ChosenPhoto.Length];
        e.ChosenPhoto.Position = 0;
        e.ChosenPhoto.Read(b, 0, b.Length);

        //Saves the picture in base64 (See implementation comments)
        //CommonTasks.SavePicture(picName, Convert.ToBase64String(b));
        photoB64 = Convert.ToBase64String(b);
      }
    }

    #endregion

    #region Other

    //When tapping on the opera preview picture, a page with opera-related values is shown
    private void operaPicBox_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
#if DEBUG
      if(itemInfo == null)
        itemInfo = new ItemInfos() { author = "Blk", description = "The greatest bongo ever", release_date = "28/10/1971", title = "BonGold" };
#endif
      if (itemInfo != null)
      {
        PhoneApplicationService.Current.State["ItemInfo"] = itemInfo;

        NavigationService.Navigate(new Uri("/OperaViewPage.xaml", UriKind.Relative));
      }
      else
        MessageBox.Show(Languages.LangsRes.noOperaData, Languages.LangsRes.ErrorTit, MessageBoxButton.OK);
    }

    private void confirmBtn_Click(object sender, EventArgs e)
    {
      PhoneApplicationService.Current.State["NewItem"] = new Scan(operaQR, textPrevBox.Text, photoB64);
      NavigationService.Navigate(new Uri("/MainPage.xaml?action=NewItem", UriKind.Relative));
    }

    private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
    {
      NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
    }

    public void LocalizeAppBar()
    {
      //This awful method is required due to the inability of the 
      //ApplicationBar to support dynamic content binding,
      //so various items have been provided with localized strings
      //manually. To share.
      ApplicationBarIconButton tmp = (ApplicationBarIconButton)ApplicationBar.Buttons[0];
      tmp.Text = Languages.LangsRes.btnAddPhoto;
      ApplicationBar.Buttons[0] = tmp;
      tmp = (ApplicationBarIconButton)ApplicationBar.Buttons[1];
      tmp.Text = Languages.LangsRes.btnCong;
    }

    #endregion   
  }
}