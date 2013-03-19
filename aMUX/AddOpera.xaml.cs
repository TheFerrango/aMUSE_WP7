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
using Microsoft.Phone.Tasks;
using Coding4Fun.Toolkit.Controls;
using System.Windows.Media.Imaging;

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
      PhotoChooserTask pct = new PhotoChooserTask() { ShowCamera = true, PixelHeight = 480, PixelWidth=640 };
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
      }
    }

    private void addCommentBtn_Click(object sender, EventArgs e)
    {
      InputPrompt ip = new InputPrompt();
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
  }
}