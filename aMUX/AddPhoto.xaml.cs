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
using Coding4Fun.Toolkit.Controls;
using Microsoft.Phone.Tasks;
using System.Windows.Media.Imaging;
using aMUXClasses;
using Microsoft.Phone.Shell;

namespace aMUX
{
  public partial class AddPhoto : PhoneApplicationPage
  {
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

    private void addCommentBtn_Click(object sender, EventArgs e)
    {
      InputPrompt ip = new InputPrompt();
      ip.Title = Languages.LangsRes.lblComment;

      ip.Completed += new EventHandler<PopUpEventArgs<string, PopUpResult>>(ip_Completed);
      ip.Show();
    }

    void ip_Completed(object sender, PopUpEventArgs<string, PopUpResult> e)
    {
      if (e.PopUpResult == PopUpResult.Ok)
      {
        textPrevBox.Text = e.Result;
        commentStackPan.Visibility = System.Windows.Visibility.Visible;
      }
    }

    private void addPhotoBtn_Click(object sender, EventArgs e)
    {
      pct.Show();
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
  }
}