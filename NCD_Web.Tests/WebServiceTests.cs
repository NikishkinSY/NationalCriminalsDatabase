using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCD_Model;
using System.Collections.Generic;

namespace NCD_WebService.Tests
{
    [TestClass()]
    public class WebServiceTests
    {
        [TestMethod()]
        public void CreateQueryTest()
        {
            var searchParams = new SearchParams()
            {
                Names = new string[] { "test" },
                StartAge = 10,
                EndAge = 20,
                Nationality = new string[] { "test" },
                StartHeight = 10,
                EndHeight = 20,
                StartWeight = 10,
                EndWeight = 20,
                Sex = 1
            };
            var result = HelperModule.CreateQuery(searchParams, 10, new List<CriminalPerson>());
        }

        [TestMethod()]
        public void ValidateInputDataTest()
        {
            var searchParams = new SearchParams()
            {
                Names = new string[] { "test" },
                StartAge = 10,
                EndAge = 20,
                Nationality = new string[] { "test" },
                StartHeight = 10,
                EndHeight = 20,
                StartWeight = 10,
                EndWeight = 20,
                Sex = 1
            };
            var result = HelperModule.ValidateInputData(searchParams, 10, "NationalCriminalList@gmail.com");
            Assert.IsTrue(result.Success);
        }

        [TestMethod()]
        public void MakePdfTest()
        {
            var result = PdfSharpModule.MakePdf(new CriminalPerson());
            result.Dispose();
        }

        [TestMethod()]
        public void GetItemsAndSendEmailAsyncTest()
        {
            var criminalPersons = new List<CriminalPerson>() { new CriminalPerson(), new CriminalPerson() };
            var task = HelperModule.GetItemsAndSendEmailAsync(criminalPersons, "NationalCriminalList@gmail.com");
            task.Wait();
        }
    }
}