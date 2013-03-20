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
using System.Globalization;

namespace aMUXClasses
{
  public class Personal
  {
    string _photo;
    string _text;
    string _date;
    protected string _type;

    public string date
    {
      get { return _date; }
      set { _date = value; }
    }

    public string photo
    {
      get { return _photo; }
      set { _photo = value; }
    }

    public string text
    {
      get { return _text; }
      set { _text = value; }
    }
    
    public string type
    {
      get { return _type; }
    }

    public Personal()
    {
      _type = "personal";
      _date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
      _text = "";
      _photo = "";
    }

    public Personal(string comment) : this()
    {
      _text = comment;
    }

    public Personal(string comment, string photo_b64)
      : this(comment)
    {
      _photo = photo_b64;
    }

    public override string ToString()
    {
      string toReturn = "";
      if (text != "")
      {
        toReturn = "comment";
        if (photo != "")
          toReturn += ", photo";
      }
      else
        toReturn += "photo";
      return toReturn;
    }

  }
}
