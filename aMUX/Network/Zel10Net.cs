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

namespace Zel10Support
{
  /*
   * Zel10Net networking class works in this awesome way:
   * Every networking-needing task is divided into smaller tasks, such as login, logout,
   * file upload, file download and so on.
   * 
   * A Zel10Net type object exposes a method named AddNetJob, which requires an object that implements i INetWork
   * interface. this way, the class iterates through all the 'jobs' added to the list, waiting for each job to finish
   * before starting the next one. This way, a fake syncronous-like experience can be provided, and when all jobs
   * in the queue have been completed, a 'BatchOperationCompleted' event is thrown.
   * 
   * This way, to add functionalities to the class, you just have to implement your class using the INetWork interface
   * and implementing the ExecuteNetworkOperation() method.
   * Yay!
   */
  public class Zel10Net
  {
    public delegate void BatchOperationCompletedHandler(object sender, List<string> results);
    public event BatchOperationCompletedHandler BatchOperationCompleted;
    //string _server;
    List<string> _results;
    Queue<INetWork> _jobs;
    CookieAwareWebClient _zel10Client;

    public Zel10Net()
    {
      _zel10Client = new CookieAwareWebClient();
      _jobs = new Queue<INetWork>();
      _results = new List<string>();
      _zel10Client.UploadStringCompleted += new UploadStringCompletedEventHandler(_zel10Client_UploadStringCompleted);
      _zel10Client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(_zel10Client_DownloadStringCompleted);
    }
    
    void _zel10Client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
      try
      {
        _results.Add(e.Result);
        if (_jobs.Count > 0)
        {
          INetWork inw = _jobs.Dequeue();
          inw.ExecuteJob(_zel10Client, NetworkAddresses.ServerAddress);
        }
        else
        {
          BatchOperationCompleted(sender, _results);
        }
      }
      catch { _results.Add("FAIL");
      BatchOperationCompleted(sender, _results);
      }
    }

    void _zel10Client_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
    {
      try
      {
        _results.Add(e.Result);
      }
      catch { _results.Add("FAIL");
      BatchOperationCompleted(sender, _results);
      }
      if (_jobs.Count > 0)
      {
        INetWork inw = _jobs.Dequeue();
        inw.ExecuteJob(_zel10Client, NetworkAddresses.ServerAddress);
      }
      else
      {
        BatchOperationCompleted(sender, _results);
      }
    }

    public void AddNetJob(INetWork job)
    {
      _jobs.Enqueue(job);
    }

    public bool Execute()
    {
      if (_jobs.Count > 0)
      {
        INetWork inw = _jobs.Dequeue();
        inw.ExecuteJob(_zel10Client, NetworkAddresses.ServerAddress);
        return true;
      }
      return false;
    }
  }

  public class ContentUpload : INetWork
  {
    string _data;

    public ContentUpload(string data)
    {
      _data = data;
    }

    public void ExecuteJob(CookieAwareWebClient cawc, string address)
    {
      cawc.Headers["Content-Type"] = "application/json";
      cawc.UploadStringAsync(new Uri(NetworkAddresses.ObtainExperienceUploadAddress(), UriKind.Absolute), _data);
    }
  }

  public class FakeUpload : INetWork
  {
    string _data;

    public FakeUpload()
    {
      _data = "{\"exp\":[{\"id\":\"356a192b7913b04c54574d18c28d46e6395428ab\",\"date\":\"2013-04-05 15:20:24\",\"photo\":\"\",\"text\":\"\",\"type\":\"scan\"}],\"confirm\":\"24e3261d7bbe24664c1babc75189cfebec04498b\",\"email\":\"bill@contoso.com\"}";
    }

    public void ExecuteJob(CookieAwareWebClient cawc, string address)
    {
      cawc.Headers["Content-Type"] = "application/json";
      cawc.UploadStringAsync(new Uri(NetworkAddresses.ObtainExperienceUploadAddress()), _data);
    }
  }

  public class GetItemInformation : INetWork
  {
    string itemQR;

    public GetItemInformation(string QRContent)
    {
      itemQR = QRContent;
    }

    public void ExecuteJob(CookieAwareWebClient cawc, string address)
    {
      MessageBox.Show(NetworkAddresses.ObtainItemInfoAddress(itemQR));
      cawc.DownloadStringAsync(new Uri(NetworkAddresses.ObtainItemInfoAddress(itemQR), UriKind.Absolute));
    }
  }

  //I didn't wrote this, took from stackoverflow.com
  public class CookieAwareWebClient : WebClient
  {
    [System.Security.SecuritySafeCritical]
    public CookieAwareWebClient()
      : base()
    {
    }
    private CookieContainer m_container = new CookieContainer();
    protected override WebRequest GetWebRequest(Uri address)
    {
      WebRequest request = base.GetWebRequest(address);
      if (request is HttpWebRequest)
      {
        (request as HttpWebRequest).CookieContainer = m_container;
      }
      return request;
    }
  }
}
