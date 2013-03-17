using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using aMUXClasses;


namespace aMUX
{
  public class ItemViewModel : INotifyPropertyChanged
  {
    private string _operaName;
    /// <summary>
    /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
    /// </summary>
    /// <returns></returns>
    public string OperaName
    {
      get
      {
        return _operaName;
      }
      set
      {
        if (value != _operaName)
        {
          _operaName = value;
          NotifyPropertyChanged("LineOne");
        }
      }
    }

    private Personal _actualContent;

    public Personal ActualContent
    {
      get { return _actualContent; }
      set
      {
        if (value != _actualContent)
        {
          
          _actualContent = value;
          NotifyPropertyChanged("Content");
        }
      }
    }


    public string WhatContains
    {
      get { return _actualContent.ToString(); }
    }

    public string ContentImage
    {
      get {
        if (WhatContains.Contains("scan"))
          return "Images/opera.png";
        if(WhatContains.Contains("photo"))
          return "Images/picture.png";
        return "Images/Text.png";
      }
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