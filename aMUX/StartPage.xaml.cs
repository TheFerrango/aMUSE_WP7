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
using System.Text.RegularExpressions;
using System.IO.IsolatedStorage;

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
      if (isValid)
      {
        NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        iss["emailAddress"] = txtBxEmail.Text;
      }
    }
  }
}