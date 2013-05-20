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
    //static string _ServerAddress = "http://10.23.3.201:8000/";
    static string _ServerAddress = "http://10.23.24.198:8000/";
    public static string ServerAddress
    {
      get { return NetworkAddresses._ServerAddress; }
      set { NetworkAddresses._ServerAddress = value; }
    }

    static string uploadPath = "api/exp/s/";
    static string itemInfo = "api/i/";
    static string exhibitsList = "e/list/";

    public static Uri ObtainItemPicture(string path)
    {
      return new Uri(new Uri(_ServerAddress), path);
    }

    public static string ObtainItemInfoAddress(string id)
    {
      return _ServerAddress + itemInfo + id + "/";
    }

    public static string ObtainExhibitsListAddress()
    {
      return _ServerAddress + exhibitsList;
    }

    public static string ObtainExperienceUploadAddress()
    {
      return _ServerAddress + uploadPath;
    }
  }
}
