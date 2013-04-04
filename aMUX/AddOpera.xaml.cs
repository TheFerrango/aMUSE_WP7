using System;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using aMUXClasses;
using Coding4Fun.Toolkit.Controls;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace aMUX
{
  public partial class AddOpera : PhoneApplicationPage
  {
    string operaQR;
    string photoB64;
    InputPrompt ip;

    public AddOpera()
    {
      InitializeComponent();
      photoB64 = "";
      operaQR = PhoneApplicationService.Current.State["OperaQR"] as string;
      PhoneApplicationService.Current.State.Clear();
      qrTxtCode.Text = operaQR;
      //NavigationService.RemoveBackEntry();
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
       ip = new InputPrompt();
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


    private void confirmBtn_Click(object sender, EventArgs e)
    {
      PhoneApplicationService.Current.State["NewItem"] = new Scan(operaQR, textPrevBox.Text, photoB64); 
      NavigationService.Navigate(new Uri("/MainPage.xaml?action=NewItem", UriKind.Relative));
    }
  }
}