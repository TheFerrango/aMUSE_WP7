using System;
using System.IO.IsolatedStorage;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Phone.Controls;
using System.Net;
using System.Collections.Generic;
using aMUXClasses;

namespace aMUX
{
  public partial class StartPage : PhoneApplicationPage
  {
    bool isValid;
    WebClient wc;
    IsolatedStorageSettings iss;
    public StartPage()
    {
      InitializeComponent();
      isValid = false;
      iss = IsolatedStorageSettings.ApplicationSettings;
      wc = new WebClient();
      wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
    }

    void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
      List<Exhibit> lista = new List<Exhibit>();
      try
      {
        lista = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Exhibit>>(e.Result);
        pickerExh.ItemsSource = lista;
        exChoose.Visibility = System.Windows.Visibility.Visible;
      }
      catch
      {
        iss["limit"] = 15;
#if DEBUG
        string test = "[{\"scan_limit\": 10, \"date_end\": \"2015-04-11\", \"date_begin\": \"2013-04-01\", \"id\": 1, \"name\": \"10 Famous Paintings of All Times\"}," +
          "{\"scan_limit\": 10, \"date_end\": \"2015-04-11\", \"date_begin\": \"2013-04-01\", \"id\": 2, \"name\": \"The History of Bongos\"}," +
        "{\"scan_limit\": 0, \"date_end\": \"2015-04-11\", \"date_begin\": \"2013-04-01\", \"id\":3, \"name\": \"Zero test\"}]";
        lista = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Exhibit>>(test);
        pickerExh.ItemsSource = lista;
        exChoose.Visibility = System.Windows.Visibility.Visible;
#endif


      }
      finally
      {
        confirmButton.Visibility = System.Windows.Visibility.Visible;
        LoadBar.IsIndeterminate = false;
      }
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
     
#if DEBUG
      iss["emailAddress"] = "bill@contoso.com";
      App.NetMan = new Zel10Support.Zel10Net();
      NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));

#endif

      if (isValid)
      {
        iss["emailAddress"] = txtBxEmail.Text;
        App.NetMan = new Zel10Support.Zel10Net();
        NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
      }
    }

    private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
    {
      while (NavigationService.CanGoBack)
        NavigationService.RemoveBackEntry();
      wc.DownloadStringAsync(new Uri(Zel10Support.NetworkAddresses.ObtainExhibitsListAddress()));
    }

    private void pickerExh_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (pickerExh.SelectedIndex >= 0)
      {
        Exhibit ex = (sender as ListPicker).SelectedItem as Exhibit;
        if(ex != null)
          iss["limit"] = ex.scan_limit;
      }
    }
  }
}