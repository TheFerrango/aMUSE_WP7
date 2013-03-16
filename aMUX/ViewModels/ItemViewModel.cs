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

    private string _contentLine;
    /// <summary>
    /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
    /// </summary>
    /// <returns></returns>
    public string ContentLine
    {
      get
      {
        return _contentLine;
      }
      set
      {
        if (value != _contentLine)
        {
          _contentLine = value;
          NotifyPropertyChanged("LineTwo");
        }
      }
    }

    private string _lineThree;
    /// <summary>
    /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
    /// </summary>
    /// <returns></returns>
    public string LineThree
    {
      get
      {
        return _lineThree;
      }
      set
      {
        if (value != _lineThree)
        {
          _lineThree = value;
          NotifyPropertyChanged("LineThree");
        }
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