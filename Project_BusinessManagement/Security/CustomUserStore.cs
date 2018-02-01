using Bll_Business;
using BO_BusinessManagement;
using Microsoft.AspNet.Identity;
using Project_BusinessManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_BusinessManagement.Security
{
    public class CustoMUserStore : IUserStore<MUser>, IUserRoleStore<MUser>
    {
        public Task CreateAsync(MUser user)
        {
            //Create /Register New User 
            throw new NotImplementedException();
        }

        public Task DeleteAsync(MUser user)
        {
            //Delete User 
            throw new NotImplementedException();
        }

        public Task<MUser> FindByIdAsync(string userId)
        {
            Bo_User lUser = new Bo_User();
            var lIdUser = 0;
            if (int.TryParse(userId, out lIdUser))
            {
                lUser = Bll_User.bll_GetUserById(Convert.ToInt32(userId));
                if (string.IsNullOrEmpty(lUser.LException))
                {

                    var lUserapp = new MUser
                    {
                        Id = lUser.LIdUser.ToString(),
                        LBirthDate = DateTime.Now,
                        LCreateDate = DateTime.Now,
                        LPasswordHash = lUser.LPassword,
                        LUser = lUser.LUser,
                        UserName = lUser.LFNameUser + " " + lUser.LFLastName,
                        LEmail = lUser.LEmail

                    };

                    return Task.Run(() => { return lUserapp; }); //System.Threading.Tasks.Task.FromResult(lUserapp);
                }
                else
                {
                    return null;
                }
            }
            else { return null; }
        }


        public Task<MUser> FindByNameAsync(string userName)
        {
            Bo_User lUser = new Bo_User();
            lUser = Bll_User.bll_GetUserByUser(userName);
            if (string.IsNullOrEmpty(lUser.LException))
            {

                var lUserapp = new MUser
                {
                    Id = lUser.LIdUser.ToString(),
                    LBirthDate = DateTime.Now,
                    LCreateDate = DateTime.Now,
                    LPasswordHash = lUser.LPassword,
                    LUser = lUser.LUser,
                    UserName = lUser.LFNameUser + " " + lUser.LFLastName,
                    LEmail = lUser.LEmail

                };

                return Task.Run(() => { return lUserapp; }); //System.Threading.Tasks.Task.FromResult(lUserapp);
            }
            else
            {
                return null;
            }
        }

        public Task UpdateAsync(MUser user)
        {
            //Update User Profile 
            throw new NotImplementedException();
        }


        void IDisposable.Dispose()
        {
            // throw new NotImplementedException(); 

        }

        public Task AddToRoleAsync(MUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(MUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(MUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(MUser user)
        {
            IList<Bo_Role> lRole;
            lRole = Bll_Role.GetRolesByUser(Convert.ToInt32(user.Id));
            IList<string> lListApprole = new List<string>();

            if (string.IsNullOrEmpty(lRole.First().LException))
            {
                lRole.ToList().ForEach(item =>
                {
                    lListApprole.Add(item.LNameRole);
                });

                return Task.Run(() => { return lListApprole; }); //System.Threading.Tasks.Task.FromResult(lUserapp);
            }
            else
            {
                return null;
            }
        }
    }
}