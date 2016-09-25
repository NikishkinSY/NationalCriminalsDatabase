using Microsoft.VisualStudio.TestTools.UnitTesting;

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