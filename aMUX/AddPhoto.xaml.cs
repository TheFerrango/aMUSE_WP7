using System;
using System.Windows;
using System.Windows.Media.Imaging;
using aMUXClasses;
using Coding4Fun.Toolkit.Controls;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace aMUX
{
  public partial class AddPhoto : PhoneApplicationPage
  {
    InputPrompt ip;
    PhotoChooserTask pct;
    string photoB64;

    public AddPhoto()
    {
      InitializeComponent();
    }

    void pct_Completed(object sender, PhotoResult e)
    {
      if (e.TaskResult == TaskResult.OK)
      {
        BitmapImage bImg = new BitmapImage();
        bImg.SetSource(e.ChosenPhoto);
        imgBox.Source = bImg;

        byte[] b = new byte[e.ChosenPhoto.Length];
        e.ChosenPhoto.Position = 0;
        e.ChosenPhoto.Read(b, 0, b.Length);

        //Saves the picture in base64 (See implementation comments)
        //CommonTasks.SavePicture(picName, Convert.ToBase64String(b));
        photoB64 = Convert.ToBase64String(b);
      }
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
      if (photoB64 != "")
      {
        PhoneApplicationService.Current.State["NewItem"] = new Personal(textPrevBox.Text, photoB64);
        NavigationService.Navigate(new Uri("/MainPage.xaml?action=NewItem", UriKind.Relative));
      }
    }

    private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
    {
      pct = new PhotoChooserTask() { ShowCamera = true, PixelWidth = 640, PixelHeight = 480 };
      pct.Completed += new EventHandler<PhotoResult>(pct_Completed);
      pct.Show();
    }

    private void ScrollViewer_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      ip = new InputPrompt();
      ip.Title = Languages.LangsRes.lblComment;

      ip.Completed += new EventHandler<PopUpEventArgs<string, PopUpResult>>(ip_Completed);
      ip.Show();
    }

    private void imgBox_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      pct.Show();
    }
  }
}