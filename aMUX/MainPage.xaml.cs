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
using Microsoft.Phone.Shell;
using aMUXClasses;
using System.IO.IsolatedStorage;

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
        App.ViewModel.Items.Add(new ItemViewModel() { ActualContent=item, OperaName = modello });
        PhoneApplicationService.Current.State.Clear();
      }

      while (NavigationService.CanGoBack)
        NavigationService.RemoveBackEntry();
    }

    private void btnRead_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      //App.ViewModel.Items.Add(new ItemViewModel() { OperaName = "Coop", ActualContent = new aMUXClasses.Scan("-1", "banana", "base64") });
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
      foreach(ItemViewModel ivm in App.ViewModel.Items)
        ss.exp.Add(ivm.ActualContent);
      ss.email = iss["emailAddress"] as string;
      ss.confirm = "bambaQR";
      new Networking().SendaSenda(ss);
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