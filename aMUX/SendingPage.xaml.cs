﻿using System;
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
using Zel10Support;
using Newtonsoft.Json;
using Microsoft.Phone.Shell;
using aMUXClasses;

namespace aMUX
{
  public partial class SendingPage : PhoneApplicationPage
  {
    Zel10Net z10n;
    string jsonFinale;
    public SendingPage()
    {
      InitializeComponent();
      jsonFinale = "";
      z10n = new Zel10Support.Zel10Net();
      z10n.BatchOperationCompleted += new Zel10Net.BatchOperationCompletedHandler(z10n_BatchOperationCompleted);
    }

    void z10n_BatchOperationCompleted(object sender, List<string> results)
    {
      if (results[0] != "FAIL")
      {
        NavigationService.Navigate(new Uri("/StartPage.xaml", UriKind.Relative));
      }
      else
      {
        stkUpld.Visibility = System.Windows.Visibility.Collapsed;
        stkFail.Visibility = System.Windows.Visibility.Visible;
      }
    }

    private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
    {
      SendingClass ss = PhoneApplicationService.Current.State["ss"] as SendingClass;
      ss.confirm = PhoneApplicationService.Current.State["StringQR"] as string;
      PhoneApplicationService.Current.State.Clear();
      jsonFinale = JsonConvert.SerializeObject(ss, Formatting.None);
      z10n.AddNetJob(new Zel10Support.ContentUpload(jsonFinale));
      z10n.Execute();
      //System.Threading.Thread.Sleep(5000);
      //NavigationService.Navigate(new Uri("/StartPage.xaml", UriKind.Relative));
    }

    private void btnTryAg_Click(object sender, RoutedEventArgs e)
    {
      stkUpld.Visibility = System.Windows.Visibility.Visible;
      stkFail.Visibility = System.Windows.Visibility.Collapsed;
      z10n.AddNetJob(new Zel10Support.ContentUpload(jsonFinale));
      z10n.Execute();
    }

    private void btnCanc_Click(object sender, RoutedEventArgs e)
    {
      NavigationService.Navigate(new Uri("/StartPage.xaml", UriKind.Relative));
    }
  }
}