using DXEventsAPP.Model;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXEventsAPP.ViewModel
{
    public class UserTableViewModel
    {
        IMobileServiceTable<user> userTable;
        public MobileServiceCollection<user, user> items;


        public UserTableViewModel()
        {
            try
            {
                this.userTable = App.MobileService.GetTable<user>();
            }
            catch
            {

            }
        }

        public async Task<bool> InsertUser(user _user)
        {
            try
            {
                // This code inserts a new user into the database.
                bool userExisting = await CheckForExistingUser(_user.email);
                if (!userExisting)
                {
                    await userTable.InsertAsync(_user);
                    return false;
                }
                else
                {
                    // TODO: Handle the exsisting user message
                    return true;

                }


                //await SyncAsync(); // offline sync
            }
            catch
            {
                return true;
            }
            
        }

        public async Task<bool> CheckForExistingUser(string newMail)
        {
            bool result = false;
            try
            {
                
                items = await userTable.
                    Where(userItem => userItem.email == newMail).ToCollectionAsync();

                if (items.Count > 0)
                {
                    result = true;
                    App.USERID = items[0].id;
                }

                else
                    result = false;

                return result;
            }
            catch
            {
                return result;
            }
            
        }



    }
}
