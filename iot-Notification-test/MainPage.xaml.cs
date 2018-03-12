using Microsoft.Azure.NotificationHubs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace iot_Notification_test
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = "iot-Notification";
            SendNotificationasync(str);
        }

        private static async void SendNotificationasync(string str)
        {
            NotificationHubClient hub = NotificationHubClient
                .CreateClientFromConnectionString(
                    "Endpoint=sb://rpi-notification.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=ab0WkZXESky6bjp8CI+1XtlYTQFxWNQOPOoTd1Uks7A="
                    , "Windows-iot");
            var toast = $@"<toast><visual><binding template=""ToastText01""><text id=""1"">{str}</text></binding></visual></toast>";
            await hub.SendWindowsNativeNotificationAsync(toast);
        }

    }
}
