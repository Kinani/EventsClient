using DXEventsAPP.Model;
using DXEventsAPP.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class Login_Page : Page
    {
        private user _user;
        private UserTableViewModel _userTableVM;
        

        public Login_Page()
        {
            this.InitializeComponent();
            try
            {
                _user = new user();
                _userTableVM = new UserTableViewModel();
            }
            catch
            {

            }



        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            //SignIn();

        }

        private async void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if(App.IsInternet())
            {
                progress.Visibility = Visibility.Visible;
                progress.IsActive = true;

                // TODO
                if (UserEmail.Text != string.Empty)
                {
                    _user.email = UserEmail.Text;
                    if (await _userTableVM.CheckForExistingUser(_user.email))
                    {
                        // User is Exsisiting
                        Frame.Navigate(typeof(MainPage));



                    }
                    else
                    {
                        var messageDialog = new MessageDialog("The Email you entred is not registered, Please register.");
                        await messageDialog.ShowAsync();

                        progress.Visibility = Visibility.Collapsed;
                        progress.IsActive = false;


                    }
                }
                else
                {
                    var messageDialog = new MessageDialog("Please enter your Email");
                    await messageDialog.ShowAsync();

                    progress.Visibility = Visibility.Collapsed;
                    progress.IsActive = false;
                }

            }
            else
            {
                var messageDialog = new MessageDialog("This app requiries you to be connected to the internet, Please connect to the internet");
                await messageDialog.ShowAsync();
            }

            
            

        }


        private void CreatNewAccBtn_Click(object sender, RoutedEventArgs e)
        {
            // TODO
            Frame.Navigate(typeof(Register_User_Page));

        }

    }
}

