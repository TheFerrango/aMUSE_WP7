
namespace aMUXClasses
{
  public class Exhibit
  {
    string exhibitName;
    int scanLimit;

    public string name
    {
      get { return exhibitName; }
      set { exhibitName = value; }
    }

    public int scan_limit
    {
      get { return scanLimit; }
      set { scanLimit = value; }
    }
  }
}
