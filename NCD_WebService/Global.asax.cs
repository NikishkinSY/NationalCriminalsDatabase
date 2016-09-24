using Ninject;
using Ninject.Web.Common;

namespace NCD_WebService
{
    public class Global : NinjectHttpApplication
    {
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<NCD_Model.IContext>().To<NCD_Model.ApplicationDbContext>();
            return kernel;
        }
    }
}