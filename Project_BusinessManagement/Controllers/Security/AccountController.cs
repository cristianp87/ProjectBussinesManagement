using IBusiness.Common;
using IBusiness.Management;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Project_BusinessManagement.Models;
using Project_BusinessManagement.Security;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Project_BusinessManagement.Controllers.Security
{
    [Authorize]
    public class AccountController : Controller
    {
        #region Variables and Constants

        public static IBusinessUser LiUser =
        FacadeProvider.Resolver<IBusinessUser>();
        #endregion
        #region Propierties
        public CustomUserManager PCustomUserManager { get; private set; }
        #endregion
        public AccountController() : this(new CustomUserManager())
        {
        }

        public AccountController(CustomUserManager customUserManager)
        {
            PCustomUserManager = customUserManager;
        }

        public ActionResult Index()
        {
            return View();
        }


        // 
        // GET: /Account/Login 
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // 
        // POST: /Account/Login 
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(MLogin model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await PCustomUserManager.FindUserAsync(model.UserName, model.Password);
                if (user != null)
                {
                    await SignInAsync(user, model.RememberMe);
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }
            // If we got this far, something failed, redisplay form 
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(MUser pUser)
        {
            var bo_Object = new BO_BusinessManagement.Bo_Object()
            {
                LIdObject = 3011
            };
            var bo_Status = new BO_BusinessManagement.Bo_Status()
            {
                LIdStatus = "APPRO"
            };
            var bo_TypeIdentification = new BO_BusinessManagement.Bo_TypeIdentification()
            {
                LIdTypeIdentification = 2
            };
            var bo_Role = new BO_BusinessManagement.Bo_Role()
            {
                LIdRole = 1
            };
            PasswordHasher lPass = new PasswordHasher();
            pUser.LPasswordHash = lPass.HashPassword(pUser.LPasswordHash); ;
            var bo_User = new BO_BusinessManagement.Bo_User()
            {
                LBirthDate = pUser.LBirthDate,
                LEmail = "",
                LFLastName = pUser.LLastName,
                LException = "",
                LFNameUser = pUser.LFirstName,
                LIdUser = 0,
                LInnerException = "",
                LMessageDao = "",
                LNoIdentification = pUser.LNoIdentification,
                LObject = bo_Object,
                LPassword = pUser.LPasswordHash,
                LSLastName = pUser.LsLastName,
                LSNameUser = pUser.LSecondName,
                LStatus = bo_Status,
                LTypeIdentification = bo_TypeIdentification,
                LUser = pUser.LUser,
                LRole = bo_Role
            };

            var lResult = LiUser.bll_InsertUser(bo_User);
            if (string.IsNullOrEmpty(lResult))
            {
                return View("Login");
            }
            return View();
        }



        // POST: /Account/LogOff 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing && PCustomUserManager != null)
            {
                PCustomUserManager.Dispose();
                PCustomUserManager = null;
            }
            base.Dispose(disposing);
        }

        #region Helpers 
        // Used for XSRF protection when adding external logins 
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private async Task SignInAsync(MUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            var identity = await PCustomUserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }


        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri) : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties() { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}