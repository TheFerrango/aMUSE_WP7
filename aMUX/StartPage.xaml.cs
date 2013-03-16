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

namespace aMUX
{
  public partial class StartPage : PhoneApplicationPage
  {
    public StartPage()
    {
      InitializeComponent();
    }

    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
      if (txtBxEmail.Text.Contains('@'))
      {
        btnConfMail.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 0, 100, 0));
        btnConfMail.Content = Languages.LangsRes.btnConfMailOK;
      }
      else
      {
        btnConfMail.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
        btnConfMail.Content = Languages.LangsRes.btnConfMailFAIL;
      }

    }

    private void btnConfMail_Click(object sender, RoutedEventArgs e)
    {
      NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
    }
  }
}