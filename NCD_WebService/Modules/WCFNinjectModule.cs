using NCD_Model;
using Ninject.Modules;

namespace NCD_WebService
{
    public class WCFNinjectModule : NinjectModule
    {
        public override void Load()
        {
            //Injects the constructors of all DI-ed objects 
            //with a LinqToSQL implementation of IRepository
            Bind<IContext>().To<ApplicationDbContext>();
        }
    }
}