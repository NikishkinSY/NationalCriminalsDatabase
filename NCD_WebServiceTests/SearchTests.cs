﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCD_Model;
using NCD_WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCD_WebService.Tests
{
    [TestClass()]
    public class SearchTests
    {
        private IContext _dbContext;
        public SearchTests()
        {
            _dbContext = DependencyResolver.Current.GetService<IContext>();
        }
        
        [TestMethod()]
        public void GetCriminalPersonsTest()
        {

            Assert.Fail();
        }
    }
}