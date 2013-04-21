using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Threading;
using com.google.zxing;
using com.google.zxing.common;
using com.google.zxing.qrcode;
using Microsoft.Devices;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace aMUX
{
  public partial class ScanQRCode : PhoneApplicationPage
  {
    bool isInitialized;

    private readonly DispatcherTimer _timer;
    private string stringQR;
    private string targetPage;

    private PhotoCameraLuminanceSource _luminance;
    private QRCodeReader _reader;
    private PhotoCamera _photoCamera;

    public ScanQRCode()
    {
      InitializeComponent();
      stringQR = "";
      _timer = new DispatcherTimer();
      _timer.Interval = TimeSpan.FromMilliseconds(250);
      _timer.Tick += (o, arg) => ScanPreviewBuffer();

#if DEBUG
      btnAccept.IsEnabled = true;
      stringQR = "DebugOverride";
#endif
    }

    private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
    {
      targetPage = NavigationContext.QueryString["TargetPage"] as string;
      NavigationContext.QueryString.Clear();
      isInitialized = true;
    }
    
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
      _photoCamera = new PhotoCamera();
      _photoCamera.Initialized += OnPhotoCameraInitialized;
      _previewVideo.SetSource(_photoCamera);

      CameraButtons.ShutterKeyHalfPressed += (o, arg) => _photoCamera.Focus();

      base.OnNavigatedTo(e);
    }

    private void OnPhotoCameraInitialized(object sender, CameraOperationCompletedEventArgs e)
    {
      int width = Convert.ToInt32(_photoCamera.PreviewResolution.Width);
      int height = Convert.ToInt32(_photoCamera.PreviewResolution.Height);

      _luminance = new PhotoCameraLuminanceSource(width, height);
      _reader = new QRCodeReader();

      Dispatcher.BeginInvoke(() =>
      {
        _previewTransform.Rotation = _photoCamera.Orientation;
        _timer.Start();
      });
    }

    private void ScanPreviewBuffer()
    {
      try
      {
        _photoCamera.GetPreviewBufferY(_luminance.PreviewBufferY);
        var binarizer = new HybridBinarizer(_luminance);
        var binBitmap = new BinaryBitmap(binarizer);
        var result = _reader.decode(binBitmap);
        Dispatcher.BeginInvoke(() => DisplayResult(result.Text));
      }
      catch
      {
      }
    }

    private void DisplayResult(string text)
    {
      if (stringQR == "")
      {
        _timer.Stop();
        stringQR = text;
        _previewRect.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 100, 0));
        btnAccept.IsEnabled = true;
        btnRefuse.IsEnabled = true;
      }
    }

    private void btnAccept_Click(object sender, RoutedEventArgs e)
    {
      PhoneApplicationService.Current.State["StringQR"] = stringQR;
      NavigationService.Navigate(new Uri("/" + targetPage, UriKind.Relative));
    }

    private void btnRefuse_Click(object sender, RoutedEventArgs e)
    {
      btnAccept.IsEnabled = false;
      btnRefuse.IsEnabled = false;
      _timer.Start();
      stringQR = "";
    }

    private void PhoneApplicationPage_Unloaded(object sender, RoutedEventArgs e)
    {
      _timer.Stop();
    }

    private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
    {
      if (!isInitialized)
        e.Cancel = true;
    }

  }
}