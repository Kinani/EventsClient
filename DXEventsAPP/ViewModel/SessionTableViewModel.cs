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
    public class SessionTableViewModel
    {
        //public ObservableCollection<session> items;
        public MobileServiceCollection<session, session> items;
        public IMobileServiceTable<session> sessionTable;
        

        public SessionTableViewModel()
        {
            try
            {
                sessionTable = App.MobileService.GetTable<session>();
            }
            catch
            {

            }
            
        }

        public async Task InsertSessionItem(session sessionItem)
        {
            try
            {
               
                await sessionTable.InsertAsync(sessionItem);
                items.Add(sessionItem);

                //await SyncAsync(); // offline sync
            }
            catch
            {

            }
            
        }

        public async Task<bool> RefreshSessionItems(dxevent _chosenSession)
        {
            MobileServiceInvalidOperationException exception = null;
            try
            {
                // This code refreshes the entries in the list view by querying the session table.
                items = await sessionTable
                    .Where(sessionItem => sessionItem.eventid == _chosenSession.id)
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
