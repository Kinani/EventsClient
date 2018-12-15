using DXEventsAPP.Model;
using DXEventsAPP.ViewModel;
using Microsoft.WindowsAzure.MobileServices;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DXEventsAPP.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Events_Page : Page
    {
        //private MobileServiceCollection<dxevent, dxevent> items;
        //private IMobileServiceTable<dxevent> eventTable = App.MobileService.GetTable<dxevent>();
        private EventTableViewModel _eventTableViewModel;

        
        public Events_Page()
        {
            this.InitializeComponent();
            this._eventTableViewModel = new EventTableViewModel();
        }

        


        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {

            //await _eventTableViewModel.InsertEventItem(new dxevent()
            //{
            //    eventname = "DevCamp!",
            //    complete = false,
            //    eventdate = DateTime.Today.ToString(),
            //    eventplace = "Microsoft Egypt",
            //    registerationlink = "http://microsoft.com",
            //    description = "Some awesome decription" 
            //});
            //await _eventTableViewModel.InsertEventItem(new dxevent()
            //{
            //    eventname = "Cloud Day!",
            //    complete = false,
            //    eventdate = DateTime.Today.ToString(),
            //    eventplace = "AUC - Tharir",
            //    registerationlink = "http://bing.com",
            //    description = "Yet another awesome decription"
            //});
            // check for the boolean to set the listView to the new List from Azure
            try
            {
                LoadingProgressBar.IsIndeterminate = true;
                LoadingProgressBar.Visibility = Visibility.Visible;

                if (await _eventTableViewModel.RefreshEventItems())
                {
                    myListView.ItemsSource = _eventTableViewModel.items;
                    LoadingProgressBar.IsIndeterminate = false;
                    LoadingProgressBar.Visibility = Visibility.Collapsed;
                }
            }
            catch
            {

            }
        }

        private void myListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            dxevent _clickedEvent = e.ClickedItem as dxevent;
            App._chosenSessionDescript = _clickedEvent.description;
            Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
                    () =>
                    {   
                        App.MyStaticFrame.Navigate(typeof(Events_Details_Page),_clickedEvent);
                        Window.Current.Activate();
                    });
        }

    }

    #region Converters
    public class EventNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string myString = (string)value;
            return string.Format("Name: {0}", myString);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

    }

    public class EventPlaceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string myString = (string)value;
            return string.Format("Place: {0}", myString);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

    }

    public class EventDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string myString = (string)value;
            return string.Format("Date: {0}", myString);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

    }

    #endregion
}
