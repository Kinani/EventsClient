using DXEventsAPP.Model;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DXEventsAPP.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Register_User_Event : Page
    {
        private dxevent _chosenEvent;
        public Register_User_Event()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _chosenEvent = e.Parameter as dxevent;
            myWebView.Source = new Uri(_chosenEvent.registerationlink);
        }

        private async void GoBackAppBarBtn_Click(object sender, RoutedEventArgs e)
        {
            Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
                    () =>
                    {
                        Frame rootFrame = Window.Current.Content as Frame;
                        rootFrame = new Frame();
                        Window.Current.Content = rootFrame;
                        //App.MyStaticFrame.Navigate(typeof(MainPage));
                        rootFrame.Navigate(typeof(MainPage));
                        Window.Current.Activate();
                    });
        }
    }
}
