using DXEventsAPP.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Syndication;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DXEventsAPP.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Home_Page : Page
    {

        public Home_Page()
        {
            this.InitializeComponent();
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            LoadingProgressBar.IsEnabled = true;
            LoadingProgressBar.Visibility = Visibility.Visible;
            LoadingProgressBar.IsIndeterminate = true;

            await GetRSSFeed();

            LoadingProgressBar.IsEnabled = false;
            LoadingProgressBar.Visibility = Visibility.Collapsed;
            LoadingProgressBar.IsIndeterminate = false;
        }

        private async Task GetRSSFeed()
        {
            SyndicationClient client = new SyndicationClient();
            Uri feedUri = new Uri("http://blogs.msdn.com/b/egtechtalk/rss.aspx");
            SyndicationFeed feed = await client.RetrieveFeedAsync(feedUri);
            FeedData feedData = new FeedData();
            foreach (SyndicationItem item in feed.Items)
            {

                FeedItem feedItem = new FeedItem();

                feedItem.Title = item.Title.Text;

                feedItem.PubDate = item.PublishedDate.DateTime;

                feedItem.Author = item.Authors[0].Name;

                // Handle the differences between RSS and Atom feeds.

                if (feed.SourceFormat == SyndicationFormat.Atom10)

                {

                    feedItem.Content = item.Content.Text;

                    feedItem.Link = new Uri("http://blogs.msdn.com/b/egtechtalk/" + item.Id);

                }

                else if (feed.SourceFormat == SyndicationFormat.Rss20)

                {

                    feedItem.Content = item.Summary.Text;

                    feedItem.Link = item.Links[0].Uri;

                }

                feedData.Items.Add(feedItem);

            }

            ItemListView.DataContext = feedData.Items;
        }

        private async void ItemListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Selector Links = sender as Selector;
            FeedItem selectedItem = Links.SelectedItem as FeedItem;
           
            await Launcher.LaunchUriAsync(selectedItem.Link);

        }
    }   
}
