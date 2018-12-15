using DXEventsAPP.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DXEventsAPP
{
    

  
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        


       
        public MainPage()
        {
            this.InitializeComponent();

            App.MyStaticFrame = this.myFrame;
            App.dispatcher = Windows.UI.Core.CoreWindow.GetForCurrentThread().Dispatcher;
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Splitter.IsPaneOpen = !Splitter.IsPaneOpen;
        }

        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.myFrame.Navigate(typeof(View.Home_Page));
            //Splitter.DisplayMode = SplitViewDisplayMode.Overlay;
            Splitter.IsPaneOpen = false;
            Header.Text = "Home";


        }

       //public static void NavigateMyFrameToMainPage()
       // {

       //     myFrame.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
       //         () =>
       //         {

       //             myFrame.Navigate(typeof(MainPage));
       //         });
       // }
        private void SplitTogleBtn_Click(object sender, RoutedEventArgs e)
        {
            Splitter.IsPaneOpen = !Splitter.IsPaneOpen;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;
            if (button != null)
            {
                switch (button.Content.ToString())
                {
                    case "Home":
                        this.myFrame.Navigate(typeof(View.Home_Page));
                        break;
                    case "Events":
                        this.myFrame.Navigate(typeof(View.Events_Page));
                        break;
                    case "Mingler":
                        this.myFrame.Navigate(typeof(View.Mingler_Page));
                        break;
                    case "Notes":
                        this.myFrame.Navigate(typeof(View.Notes_Page));
                        break;
                    case "About":
                        this.myFrame.Navigate(typeof(View.About));
                        break;
                    case "Social Channels":
                        this.myFrame.Navigate(typeof(View.Social_Channels_Page));
                        break;
                    case "Logout":
                        //this.myFrame.Navigate(typeof(View.Login_Page));
                        Frame.Navigate(typeof(View.Login_Page));
                        break;


                }
                Header.Text = button.Content.ToString();
            }
        }
       
    }
    
}
