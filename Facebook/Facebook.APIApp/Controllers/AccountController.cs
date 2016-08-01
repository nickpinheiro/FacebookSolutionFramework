using System.Collections.Generic;
using System.Web.Http;
using Facebook.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Owin;
using Microsoft.AspNet.Identity.Owin;

namespace Facebook.APIApp
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        //private MembershipCreateStatus status;

        // GET: api/Account
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Account/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Account
        [HttpPost]
        [Route("CreateUser")]
        public void CreateUser([FromBody]Facebook.Models.ApplicationUser facebookUser)
        {
            using (var context = new ApplicationDbContext())
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var user = new ApplicationUser { UserName = facebookUser.Email, FacebookId = facebookUser.FacebookId, Email = facebookUser.Email, First_Name = facebookUser.First_Name, Last_Name = facebookUser.Last_Name, Link = facebookUser.Link, Gender = facebookUser.Gender, Locale = facebookUser.Locale };
                IdentityResult result = userManager.Create(user);

                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Users");
                }
            }
        }

        // PUT: api/Account/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Account/5
        public void Delete(int id)
        {
        }
    }
}
