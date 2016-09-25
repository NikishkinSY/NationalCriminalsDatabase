using NCD_Web.Models;
using NCD_Web.NCD_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace NCD_Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ISearch _searchService;
        private ApplicationUserManager _userManager;

        public HomeController(ISearch searchService)
        {
            _searchService = searchService;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(SearchParamsViewModel model)
        {
            if (ModelState.IsValid)
            {
                //get user email
                string userId = User.Identity.GetUserId();
                string email = await UserManager.GetEmailAsync(userId);
                 
                //get search params
                SearchParams searchParams = Mapper.Map<SearchParams>(model);

                //send to wcf service
                await _searchService.GetCriminalPersonsAsync(new GetCriminalPersonsRequest(searchParams, email));
            }
            return View(model);

            
        }
    }
}