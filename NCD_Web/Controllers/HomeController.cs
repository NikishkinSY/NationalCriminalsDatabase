using NCD_Web.Models;
using NCD_Web.NCD_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NCD_Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        ISearch _searchService;
        public HomeController(ISearch searchService)
        {
            _searchService = searchService;
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
                SearchParams searchParams = new SearchParams()
                {
                    Names = model.Names.Split(',').Where(x => !string.IsNullOrEmpty(x.Trim())).ToArray()
                };

                await _searchService.GetCriminalPersonsAsync(new GetCriminalPersonsRequest(searchParams));
            }
            return View(model);

            
        }
    }
}