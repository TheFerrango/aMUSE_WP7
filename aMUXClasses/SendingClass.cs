using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace aMUXClasses
{
  public class SendingClass
  {
    List<Personal> _exp;
    string _email, _confirm;

    public SendingClass()
    {
      _exp = new List<Personal>();
      _email = ""; _confirm = "";
    }

    public List<Personal> exp
    {
      get { return _exp; }
      set { _exp = value; }
    }

    public string confirm
    {
      get { return _confirm; }
      set { _confirm = value; }
    }

    public string email
    {
      get { return _email; }
      set { _email = value; }
    }
  }
}
