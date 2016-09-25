using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCD_EmailSend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCD_EmailSend.Tests
{
    [TestClass()]
    public class EmailSendManagerTests
    {
        [TestMethod()]
        public void EmailSendAsyncTest()
        {
            var task = EmailSendManager.EmailSendAsync("test", "NationalCriminalList@gmail.com", "test");
            task.Wait();
        }
    }
}