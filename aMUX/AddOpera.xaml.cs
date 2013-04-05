using System;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using aMUXClasses;
using Coding4Fun.Toolkit.Controls;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using System.Windows;

namespace aMUX
{
  public partial class AddOpera : PhoneApplicationPage
  {
    Zel10Support.Zel10Net NetMan;

    string operaQR;
    string photoB64;
    InputPrompt ip;

    public AddOpera()
    {
      InitializeComponent();
      photoB64 = "";
      NetMan = new Zel10Support.Zel10Net();
      NetMan.BatchOperationCompleted += new Zel10Support.Zel10Net.BatchOperationCompletedHandler(NetMan_BatchOperationCompleted);
      operaQR = PhoneApplicationService.Current.State["OperaQR"] as string;
      PhoneApplicationService.Current.State.Clear();
      //qrTxtCode.Text = operaQR;

      

      //NavigationService.RemoveBackEntry();
    }

    void NetMan_BatchOperationCompleted(object sender, System.Collections.Generic.List<string> results)
    {
      LoadBar.IsIndeterminate = false;
      //MessageBox.Show(results[0]);

      //check ifs
      ItemInfos itemInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<ItemInfos>(results[0]);
      operaQR = itemInfo.id;
      operaPicBox.Source = new BitmapImage(Zel10Support.NetworkAddresses.ObtainItemPicture(itemInfo.photo));

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
      tmp.Text = Languages.LangsRes.btnAddComment;
    }

    private void addPhotoBtn_Click(object sender, EventArgs e)
    {
      



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

    private void addCommentBtn_Click(object sender, EventArgs e)
    {
      

    }

    void ip_Completed(object sender, PopUpEventArgs<string, PopUpResult> e)
    {
      if (e.PopUpResult == PopUpResult.Ok)
      {
        imgAddComm.Visibility = System.Windows.Visibility.Collapsed;

        textPrevBox.Text = e.Result;
      }
    }


    private void confirmBtn_Click(object sender, EventArgs e)
    {
      PhoneApplicationService.Current.State["NewItem"] = new Scan(operaQR, textPrevBox.Text, photoB64); 
      NavigationService.Navigate(new Uri("/MainPage.xaml?action=NewItem", UriKind.Relative));
    }

    private void ScrollViewer_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      ip = new InputPrompt();
      ip.Title = Languages.LangsRes.lblComment;
      ip.Value = textPrevBox.Text;
      ip.Completed += new EventHandler<PopUpEventArgs<string, PopUpResult>>(ip_Completed);
      ip.Show();
    }

    private void PhoneApplicationPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
      LoadBar.IsIndeterminate = true;
      NetMan.AddNetJob(new Zel10Support.GetItemInformation(operaQR));
      NetMan.Execute();
      operaPicBox.Source = new BitmapImage(new Uri("http://www.independent.co.uk/incoming/article8389795.ece/ALTERNATES/w460/BerlusconiGET.jpg"));
    }

    private void picPrevBox_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      PhotoChooserTask pct = new PhotoChooserTask() { ShowCamera = true, PixelHeight = 480, PixelWidth = 640 };
      pct.Completed += new EventHandler<PhotoResult>(pct_Completed);
      pct.Show();
    }
  }
}