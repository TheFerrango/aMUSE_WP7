using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;


namespace aMUX
{
  public class MainViewModel : INotifyPropertyChanged
  {
    public MainViewModel()
    {
      this.Items = new ObservableCollection<ItemViewModel>();
    }

    /// <summary>
    /// A collection for ItemViewModel objects.
    /// </summary>
    public ObservableCollection<ItemViewModel> Items { get; private set; }

    private string _sampleProperty = "Sample Runtime Property Value";
    /// <summary>
    /// Sample ViewModel property; this property is used in the view to display its value using a Binding
    /// </summary>
    /// <returns></returns>
    public string SampleProperty
    {
      get
      {
        return _sampleProperty;
      }
      set
      {
        if (value != _sampleProperty)
        {
          _sampleProperty = value;
          NotifyPropertyChanged("SampleProperty");
        }
      }
    }

    public bool IsDataLoaded
    {
      get;
      private set;
    }

    /// <summary>
    /// Creates and adds a few ItemViewModel objects into the Items collection.
    /// </summary>
    public void LoadData()
    {
      // Sample data; replace with real data
      this.Items.Add(new ItemViewModel() { OperaName = "Adolf mustache", ContentLine = "tag, comment", LineThree = "Facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat pulvinar sagittis senectus sociosqu" });
      this.Items.Add(new ItemViewModel() { OperaName = "MP-40", ContentLine = "tag", LineThree = "Suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus" });
      this.Items.Add(new ItemViewModel() { OperaName = "WP_013846", ContentLine = "photo", LineThree = "Habitant inceptos interdum lobortis nascetur pharetra placerat pulvinar sagittis senectus sociosqu suscipit torquent" });
      this.Items.Add(new ItemViewModel() { OperaName = "text", ContentLine = "comment", LineThree = "Ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos" });
      this.Items.Add(new ItemViewModel() { OperaName = "Jerks", ContentLine = "photo, comment", LineThree = "Maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur" });
      this.Items.Add(new ItemViewModel() { OperaName = "runtime six", ContentLine = "Dictumst eleifend facilisi faucibus", LineThree = "Pharetra placerat pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent" });
      this.Items.Add(new ItemViewModel() { OperaName = "runtime seven", ContentLine = "Habitant inceptos interdum lobortis", LineThree = "Accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat" });
      this.Items.Add(new ItemViewModel() { OperaName = "runtime eight", ContentLine = "Nascetur pharetra placerat pulvinar", LineThree = "Pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum" });
      this.Items.Add(new ItemViewModel() { OperaName = "runtime nine", ContentLine = "Maecenas praesent accumsan bibendum", LineThree = "Facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat pulvinar sagittis senectus sociosqu" });
      this.Items.Add(new ItemViewModel() { OperaName = "runtime ten", ContentLine = "Dictumst eleifend facilisi faucibus", LineThree = "Suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus" });
      this.Items.Add(new ItemViewModel() { OperaName = "runtime eleven", ContentLine = "Habitant inceptos interdum lobortis", LineThree = "Habitant inceptos interdum lobortis nascetur pharetra placerat pulvinar sagittis senectus sociosqu suscipit torquent" });
      this.Items.Add(new ItemViewModel() { OperaName = "runtime twelve", ContentLine = "Nascetur pharetra placerat pulvinar", LineThree = "Ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos" });
      this.Items.Add(new ItemViewModel() { OperaName = "runtime thirteen", ContentLine = "Maecenas praesent accumsan bibendum", LineThree = "Maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur" });
      this.Items.Add(new ItemViewModel() { OperaName = "runtime fourteen", ContentLine = "Dictumst eleifend facilisi faucibus", LineThree = "Pharetra placerat pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent" });
      this.Items.Add(new ItemViewModel() { OperaName = "runtime fifteen", ContentLine = "Habitant inceptos interdum lobortis", LineThree = "Accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat" });
      this.Items.Add(new ItemViewModel() { OperaName = "runtime sixteen", ContentLine = "Nascetur pharetra placerat pulvinar", LineThree = "Pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum" });

      this.IsDataLoaded = true;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private void NotifyPropertyChanged(String propertyName)
    {
      PropertyChangedEventHandler handler = PropertyChanged;
      if (null != handler)
      {
        handler(this, new PropertyChangedEventArgs(propertyName));
      }
    }
  }
}