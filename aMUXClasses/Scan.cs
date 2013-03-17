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

namespace aMUXClasses
{
  public class Scan : Personal
  {
    string _id;

    public string id
    {
      get { return _id; }
      set { _id = value; }
    }
    
    public Scan(string id) : base()
    {
      base._type = "scan";
      _id = id;
    }

    public Scan(string tag, string comment) :this(tag)
    {
      base.text = comment;
    }

    public Scan(string tag, string comment, string photo_b64)
      : this(tag, comment)
    {
      base.photo = photo_b64;
    }

    public override string ToString()
    {
      string toReturn = "scan";
      if (base.text != "")
        toReturn += ", comment";
      if (base.photo != "")
        toReturn += ", photo";
      return toReturn;
    }
  }
}
