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
  public class ItemInfos
  {
    string Description, ReleaseDate, Author, Photo, Title, ID;

    public ItemInfos()
    {
      Description = ReleaseDate = Author = Photo = Title = ID = "";
    }

    public string id
    {
      get { return ID; }
      set { ID = value; }
    }

    public string title
    {
      get { return Title; }
      set { Title = value; }
    }

    public string photo
    {
      get { return Photo; }
      set { Photo = value; }
    }

    public string author
    {
      get { return Author; }
      set { Author = value; }
    }

    public string release_date
    {
      get { return ReleaseDate; }
      set { ReleaseDate = value; }
    }

    public string description
    {
      get { return Description; }
      set { Description = value; }
    }

  }
}
