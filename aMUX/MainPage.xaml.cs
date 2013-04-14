﻿using System;
using System.IO.IsolatedStorage;
using System.Windows;
using aMUXClasses;
using Coding4Fun.Toolkit.Controls;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Newtonsoft.Json;
using Zel10Support;

namespace aMUX
{
  public partial class MainPage : PhoneApplicationPage
  {
    IsolatedStorageSettings iss;

    // Constructor
    public MainPage()
    {
      InitializeComponent();
      iss = IsolatedStorageSettings.ApplicationSettings;
      // Set the data context of the listbox control to the sample data
      DataContext = App.ViewModel;
      this.Loaded += new RoutedEventHandler(MainPage_Loaded);
    }

    // Load data for the ViewModel Items
    private void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
      if (!App.ViewModel.IsDataLoaded)
      {
        App.ViewModel.LoadData();
      }

      if (NavigationContext.QueryString.ContainsKey("action"))
      {
        aMUXClasses.Personal item = PhoneApplicationService.Current.State["NewItem"] as aMUXClasses.Personal;
        string modello = "Personal";
        if (item is aMUXClasses.Scan)
          modello = "Scan";
        App.ViewModel.Items.Add(new ItemViewModel() { ActualContent = item, OperaName = modello });
        PhoneApplicationService.Current.State.Clear();
      }

      while (NavigationService.CanGoBack)
        NavigationService.RemoveBackEntry();
    }

    private void btnRead_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      NavigationService.Navigate(new Uri("/ScanOpera.xaml", UriKind.Relative));
    }

    private void btnPhoto_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      //App.ViewModel.Items.Add(new ItemViewModel() { OperaName = "Coop", ActualContent = new aMUXClasses.Personal("banana", "base64") });
      NavigationService.Navigate(new Uri("/AddPhoto.xaml", UriKind.Relative));
    }

    private void btnComment_Tap(object sender, System.Windows.Input.GestureEventArgs e)
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
        App.ViewModel.Items.Add(new ItemViewModel() { OperaName = "Comment", ActualContent = new aMUXClasses.Personal(e.Result) });
      }
    }

    private void btnSend_Click(object sender, EventArgs e)
    {
      //MessageBox.Show(Languages.LangsRes.msgNotImpl);
      SendingClass ss = new SendingClass();
      foreach (ItemViewModel ivm in App.ViewModel.Items)
        ss.exp.Add(ivm.ActualContent);
      ss.email = iss["emailAddress"] as string;
      ss.confirm = "24e3261d7bbe24664c1babc75189cfebec04498b";
      Zel10Net z10n = new Zel10Support.Zel10Net();
      string jsonFinale = JsonConvert.SerializeObject(ss, Formatting.None);
      z10n.AddNetJob(new Zel10Support.ContentUpload(jsonFinale));
      z10n.Execute();
      App.ViewModel.Items.Clear();
      NavigationService.Navigate(new Uri("/StartPage.xaml", UriKind.Relative));
    }

    private void btnAbo_Click(object sender, EventArgs e)
    {
      NavigationService.Navigate(new Uri("/AboPage.xaml", UriKind.Relative));
    }

    private void mnItmRem_Click(object sender, RoutedEventArgs e)
    {
      ItemViewModel toRemove = (sender as MenuItem).DataContext as ItemViewModel;
      App.ViewModel.Items.Remove(toRemove);
    }
  }
}