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
  public partial class MainPage : PhoneApplicationPage
  {
    // Constructor
    public MainPage()
    {
      InitializeComponent();

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
      while (NavigationService.CanGoBack)
        NavigationService.RemoveBackEntry();
    }

    private void btnRead_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      App.ViewModel.Items.Add(new ItemViewModel() { OperaName = "Coop", ActualContent = new aMUXClasses.Scan("-1", "banana", "base64") });
      NavigationService.Navigate(new Uri("/ScanOpera.xaml", UriKind.Relative));
    }

    private void btnPhoto_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      App.ViewModel.Items.Add(new ItemViewModel() { OperaName = "Coop", ActualContent = new aMUXClasses.Personal("banana", "base64") });
    }

    private void btnComment_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      App.ViewModel.Items.Add(new ItemViewModel() { OperaName = "Coop", ActualContent = new aMUXClasses.Personal("banana") });
    }

    private void btnSend_Click(object sender, EventArgs e)
    {
      MessageBox.Show(Languages.LangsRes.msgNotImpl);
    }
  }
}