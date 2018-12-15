using DXEventsAPP.Model;
using DXEventsAPP.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class Register_User_Page : Page
    {
        private UserTableViewModel _userTableViewModel { get; set; }
        private user newUser;
        private DateTime userDobFromDatePicker;

        public Register_User_Page()
        {
            this.InitializeComponent();
            newUser = new user();
            _userTableViewModel = new UserTableViewModel();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (App.IsInternet())
            {

            }
            else
            {
                var messageDialog = new MessageDialog("This app requiries you to be connected to the internet, Please connect to the internet");
                await messageDialog.ShowAsync();
                this.Frame.Navigate(typeof(Login_Page));
            }
        }

        private async void AcceptAppBarBtn_Click(object sender, RoutedEventArgs e)
        {
            
            AcceptAppBarBtn.IsEnabled = false;
           if (await ValidateAndInsert())
            {
                Frame.Navigate(typeof(MainPage));

            }
            AcceptAppBarBtn.IsEnabled = true;

        }

        private async Task<bool> ValidateAndInsert()
        {
            bool result = true;
            LoadingProgressBar.IsIndeterminate = true;
            LoadingProgressBar.Visibility = Visibility.Visible;

            // Sorry for the boor Validation, Will be updated in the upcoming updates.


            if (userName.Text != string.Empty)
                newUser.name = userName.Text;
            else
            {
                // TODO


                var messageDialog = new MessageDialog("Please enter your name");
                await messageDialog.ShowAsync();
                result = false;
            }

            if (RadioBtnMale.IsChecked == true)
            {
                newUser.gender = "Male";
            }
            else if (RadioBtnFemale.IsChecked == true)
            {
                newUser.gender = "Female";

            }
            else
            {
                // TODO
                var messageDialog = new MessageDialog("Please chose your gender");
                await messageDialog.ShowAsync();
                result = false;
            }

            if (userEmail.Text != string.Empty)
                newUser.email = userEmail.Text;
            else
            {
                var messageDialog = new MessageDialog("Please enter your email");
                await messageDialog.ShowAsync();
                result = false;
            }

            if (userDobFromDatePicker != null)
                newUser.dob = userDobFromDatePicker;
            else
            {
                // TODO
                var messageDialog = new MessageDialog("Please enter your date of birth");
                await messageDialog.ShowAsync();
                result = false;
            }

            if (userCompany.Text != string.Empty)
                newUser.companyname = userEmail.Text;
            else
            {
                // TODO
                var messageDialog = new MessageDialog("Please enter your company/school");
                await messageDialog.ShowAsync();
                result = false;
            }

            if(await _userTableViewModel.InsertUser(newUser))
            {
                var messageDialog = new MessageDialog("There's an existing user with this email, Please log in.");
                await messageDialog.ShowAsync();
                result = false;
            }
            else
            {
                var messageDialog = new MessageDialog("User registered");
                await messageDialog.ShowAsync();
            }

            //App.MobileService.GetTable<user>().InsertAsync(newUser);


            
            LoadingProgressBar.IsIndeterminate = false;
            LoadingProgressBar.Visibility = Visibility.Collapsed;
            return result;
        }

        private void userDatePicker_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            userDobFromDatePicker = e.NewDate.DateTime;
        }
    }
}
