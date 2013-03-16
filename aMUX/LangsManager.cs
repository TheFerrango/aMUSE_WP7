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

namespace aMUX
{
  public class LangsManager
  {
    public Languages.LangsRes LangsRes { get {return _langRes;} }

    private static Languages.LangsRes _langRes = new Languages.LangsRes();

    public LangsManager()
    {

    }
  }
}
