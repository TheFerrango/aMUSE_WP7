using System;
using System.IO.IsolatedStorage;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Phone.Controls;

namespace aMUX
{
  public partial class StartPage : PhoneApplicationPage
  {
    bool isValid;

    public StartPage()
    {
      InitializeComponent();
      isValid = false;
    }

    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
      Regex r = new Regex(@"^(([^<>()[\]\\.,;:\s@\""]+"
                        + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
                        + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
                        + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
                        + @"[a-zA-Z]{2,}))$");
      if (r.IsMatch(txtBxEmail.Text))
      {
        btnConfMail.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 0, 100, 0));
        btnConfMail.Content = Languages.LangsRes.btnConfMailOK;
        isValid = true;
      }
      else
      {
        btnConfMail.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
        btnConfMail.Content = Languages.LangsRes.btnConfMailFAIL;
        isValid = false;
      }

    }

    private void btnConfMail_Click(object sender, RoutedEventArgs e)
    {
      IsolatedStorageSettings iss = IsolatedStorageSettings.ApplicationSettings;

#if DEBUG
      iss["emailAddress"] = "bill@contoso.com";
      NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));

#endif

      if (isValid)
      {
        iss["emailAddress"] = txtBxEmail.Text;
        App.NetMan = new Zel10Support.Zel10Net();
        NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
      }
    }
  }
}