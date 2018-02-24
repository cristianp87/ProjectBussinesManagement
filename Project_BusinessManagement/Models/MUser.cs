using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Project_BusinessManagement.Models
{
    public class MUser : IUser
    {
        public DateTime LCreateDate { get; set; }
        public DateTime LModificationDate { get; set; }
        public DateTime LBirthDate { get; set; }
        public string LPasswordHash { get; set; }
        public string Id { get; set; }
        public string LFirstName { get; set; }
        public string LSecondName { get; set; }
        public string LLastName { get; set; }
        public string LsLastName { get; set; }
        public int LIdTypeIdentification { get; set; }
        public string LNoIdentification { get; set; }
        public int LIdObject { get; set; }
        public string LUser { get; set; }
        public string UserName { get; set; }
        public string LIdStatus { get; set; }
        public IList<string> LRoles { get; set; }
        public string LEmail { get; set; }
        public MUser()
        {
            this.LModificationDate = DateTime.Now;
        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(
    UserManager<MUser> manager)
        {
            var lUserIdentity =
                await manager.CreateIdentityAsync(this,
                    DefaultAuthenticationTypes.ApplicationCookie);
            return lUserIdentity;
        }
    }
}