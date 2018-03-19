using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IBusiness.Common;
using IBusiness.Management;
using Microsoft.AspNet.Identity;
using Project_BusinessManagement.Models;

namespace Project_BusinessManagement.Security
{
    public class CustoMUserStore : IUserStore<MUser>, IUserRoleStore<MUser>
    {
        #region Variables and Constants
        public IBusinessRole LRoleFacade =
        FacadeProvider.Resolv<IBusinessRole>();

        public IBusinessUser LiUser =
        FacadeProvider.Resolv<IBusinessUser>();
        #endregion

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
            int lIdUser;
            if (int.TryParse(userId, out lIdUser))
            {
                var lUser = this.LiUser.bll_GetUserById(Convert.ToInt32(userId));
                if (string.IsNullOrEmpty(lUser.LException))
                {

                    var lUserapp = new MUser
                    {
                        Id = lUser.LIdUser.ToString(),
                        LBirthDate = DateTime.Now,
                        LCreateDate = DateTime.Now,
                        LPasswordHash = lUser.LPassword,
                        LUser = lUser.LUser,
                        UserName = lUser.LfNameUser + " " + lUser.LfLastName,
                        LEmail = lUser.LEmail

                    };

                    return Task.Run(() => lUserapp); //System.Threading.Tasks.Task.FromResult(lUserapp);
                }
                return null;
            }
            return null;
        }


        public Task<MUser> FindByNameAsync(string userName)
        {
            var lUser = this.LiUser.bll_GetUserByUser(userName);
            if (string.IsNullOrEmpty(lUser.LException))
            {

                var lUserapp = new MUser
                {
                    Id = lUser.LIdUser.ToString(),
                    LBirthDate = DateTime.Now,
                    LCreateDate = DateTime.Now,
                    LPasswordHash = lUser.LPassword,
                    LUser = lUser.LUser,
                    UserName = lUser.LfNameUser + " " + lUser.LfLastName,
                    LEmail = lUser.LEmail

                };

                return Task.Run(() => lUserapp); //System.Threading.Tasks.Task.FromResult(lUserapp);
            }
            return null;
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
            var lRole = this.LRoleFacade.GetRolesByUser(Convert.ToInt32(user.Id));
            IList<string> lListApprole = new List<string>();

            if (string.IsNullOrEmpty(lRole.First().LException))
            {
                lRole.ToList().ForEach(item =>
                {
                    lListApprole.Add(item.LNameRole);
                });

                return Task.Run(() => lListApprole); //System.Threading.Tasks.Task.FromResult(lUserapp);
            }
            return null;
        }
    }
}