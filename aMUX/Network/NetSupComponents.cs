using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zel10Support
{
  public interface INetWork
  {
    void ExecuteJob(CookieAwareWebClient cawc, string address);
  }

  public static class NetworkAddresses
  {
    //static string _ServerAddress = "http://panizza1.dyndns.org:2401/";
    //static string _ServerAddress = "http://192.168.1.5:8000/";
    static string _ServerAddress = "http://10.23.4.109:8000/";

    public static string ServerAddress
    {
      get { return NetworkAddresses._ServerAddress; }
      set { NetworkAddresses._ServerAddress = value; }
    }

    static string _UploadPath = "api/exp/s/";
    static string _ItemInfo = "api/i/";

    public static Uri ObtainItemPicture(string path)
    {
      return new Uri(new Uri(_ServerAddress), path);
    }

    public static string ObtainItemInfoAddress(string id)
    {
      return _ServerAddress + _ItemInfo + id + "/";
    }

    public static string ObtainExperienceUploadAddress()
    {
      return _ServerAddress + _UploadPath;
    }
  }
}
