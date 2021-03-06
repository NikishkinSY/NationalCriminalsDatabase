﻿using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCD_Web.NCD_Service;

namespace NCD_Web.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTest
    {
        private ISearch _searchService;

        public HomeControllerTest()
        {
            _searchService = DependencyResolver.Current.GetService<ISearch>();
        }

        [TestMethod()]
        public void ErrorTest()
        {
            var controller = new HomeController(_searchService);
            var result = controller.Error(string.Empty) as ViewResult;
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod()]
        public void IndexTest()
        {
            var controller = new HomeController(_searchService);
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod()]
        public void IndexTest1()
        {
            //var controller = new HomeController(_searchService);
            //var task = controller.Index(new SearchParamsViewModel());
            //task.Wait();
            //var result = task.Result as ViewResult;
            //Assert.AreEqual("Index", result.ViewName);
        }
    }
}
