using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Test_Owin.Models;
using Test_Owin.Models.Custom;

namespace Test_Owin.Services.Custom
{
    public class CustomUserStore : IUserStore<CustomUser>
    {
        private nemo_freshEntities database;

        public CustomUserStore()
        {
            this.database = new nemo_freshEntities();
        }

        public void Dispose()
        {
            this.database.Dispose();
        }

        public Task CreateAsync(CustomUser user)
        {
            // TODO
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CustomUser user)
        {
            // TODO
            throw new NotImplementedException();
        }

        public Task DeleteAsync(CustomUser user)
        {
            // TODO
            throw new NotImplementedException();
        }

        public async Task<CustomUser> FindByIdAsync(string userId)
        {
            int numUserId = 0;
            if (int.TryParse(userId, out numUserId))
            {
                var query = await this.database.Users.Where(x => x.id_User == numUserId).FirstOrDefaultAsync();
                if (query != null)
                {
                    CustomUser user = new CustomUser
                    {
                        Id = query.id_User.ToString(),
                        UserName = query.Username
                    };
                    return user;
                }
            }
            
            return new CustomUser();
        }

        public async Task<CustomUser> FindByNameAsync(string userName)
        {
            var query = await this.database.Users.Where(c => c.Username == userName).FirstOrDefaultAsync();
            if (query != null) {
                CustomUser user = new CustomUser
                {
                    Id = query.id_User.ToString(),
                    UserName = query.Username
                };
                return user;
            }

            return new CustomUser();
        }
    }
}