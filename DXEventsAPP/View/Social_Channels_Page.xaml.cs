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
    public sealed partial class Social_Channels_Page : Page
    {
        public Social_Channels_Page()
        {
            this.InitializeComponent();
        }

        private async void FPImage_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var uri = new Uri("https://www.facebook.com/MicrosoftDeveloper.Egypt");
            await Windows.System.Launcher.LaunchUriAsync(uri);
        }


        private async void TWImage_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var uri = new Uri("https://twitter.com/EgTechTalk");
            await Windows.System.Launcher.LaunchUriAsync(uri);
        }
    }
}
