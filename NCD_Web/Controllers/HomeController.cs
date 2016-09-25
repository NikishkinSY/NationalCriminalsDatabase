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
using NLog;

namespace NCD_Web.Controllers
{
    
    [Authorize]
    public class HomeController : Controller
    {
        public const int MaxItemsPerRequest = 20;
        private static Logger logger = LogManager.GetCurrentClassLogger();
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
            return View("Index");
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

                //get MaxItemsPerRequest from config file 
                int maxItems = 0;
                if (!int.TryParse(System.Configuration.ConfigurationManager.AppSettings["MaxItemsPerRequest"], out maxItems))
                    maxItems = MaxItemsPerRequest;

                //send to wcf service
                var result = await _searchService.GetCriminalPersonsAsync(searchParams, maxItems, email);
                logger.Info("User ({0}) sent request to service", email);

                if (result.Success)
                    return View("SendEmail");
                else
                    ViewBag.Error = result.Error;
            }
            return View("Index", model);
        }

        /// <summary>
        /// Error handler
        /// </summary>
        /// <param name="message">error message</param>
        /// <returns></returns>
        public ActionResult Error(string message = null)
        {
            if (!String.IsNullOrEmpty(message))
                ViewBag.errorMessage = message;
            return View("Error");
        }
    }
}