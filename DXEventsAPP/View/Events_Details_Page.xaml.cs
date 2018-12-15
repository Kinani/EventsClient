using DXEventsAPP.Model;
using DXEventsAPP.ViewModel;
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
    public sealed partial class Events_Details_Page : Page
    {
        private SessionTableViewModel _sessionTableViewModel;
        private dxevent _eventToPassForRegisteration;
        public Events_Details_Page()
        {
            this.InitializeComponent();
            this._sessionTableViewModel = new SessionTableViewModel();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
           
            try
            {
                dxevent _chosenEvent = e.Parameter as dxevent;
                _eventToPassForRegisteration = _chosenEvent;
                EventDescriptionTxtBlock.Text = _chosenEvent.description;

                if (await _sessionTableViewModel.RefreshSessionItems(_chosenEvent))
                {
                    //myDescriptionListView.ItemsSource = _sessionTableViewModel.items;
                    myAgendaListView.ItemsSource = _sessionTableViewModel.items;
                    mySpeakersListView.ItemsSource = _sessionTableViewModel.items;

                }
            }
            catch
            {

            }
            

        }

        private void RegisterAppBarBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Register_User_Event),_eventToPassForRegisteration);


            // TODO : When retrieving the azure access
            // Add field on the user table to indicate that user registered for this event
        }
    }

    #region Converters
    public class SessionNameConverter : IValueConverter
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

    public class SessionStartTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string myString = (string)value;
            return string.Format("From: {0}", myString);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

    }

    public class SessionEndTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string myString = (string)value;
            return string.Format("To: {0}", myString);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

    }
    public class SessionSpeakerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string myString = (string)value;
            return string.Format("Speaker: {0}", myString);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

    }

    #endregion
}
