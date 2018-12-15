using DXEventsAPP.Model;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXEventsAPP.ViewModel
{
    public class EventTableViewModel
    {
        //public ObservableCollection<dxevent> items;
        public MobileServiceCollection<dxevent, dxevent> items;
        public IMobileServiceTable<dxevent> eventTable;

        public EventTableViewModel()
        {
            try
            {
                eventTable = App.MobileService.GetTable<dxevent>();
            }
            catch
            {

            }
        }
        
        public async Task InsertEventItem(dxevent eventItem)
        {
            try
            {
        
                await eventTable.InsertAsync(eventItem);
                items.Add(eventItem);

                //await SyncAsync(); // offline sync
            }
            catch
            {

            }
            
        }

        public async Task<bool> RefreshEventItems()
        {

            MobileServiceInvalidOperationException exception = null;
            try
            {
                // This code refreshes the entries in the list view by querying the dxevent table.
                // The query excludes completed events
                items = await eventTable
                    .Where(eventItem => eventItem.complete == false)
                    .ToCollectionAsync();
            }
            catch (MobileServiceInvalidOperationException e)
            {
                exception = e;
            }

            if (exception != null)
            {
                //await new MessageDialog(exception.Message, "Error loading items").ShowAsync();
                return false;
            }
            else
            {
                return true;

            }
        }
    }
}
