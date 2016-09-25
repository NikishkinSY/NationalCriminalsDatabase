using NLog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Web;

namespace NCD_WebService
{
    /// <summary>
    /// Global error handler
    /// </summary>
    class GlobalErrorHandler : IErrorHandler
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public bool HandleError(Exception error)
        {
            logger.Error(error);
            return true;
        }

        public void ProvideFault(Exception error, MessageVersion version,
                                                                      ref Message fault)
        {
            //Nothing here - exception will go up as usual
        }
    }

    public class GlobalErrorBehaviorAttribute : Attribute, IServiceBehavior
    {
        Type errorHandlerType;

        public GlobalErrorBehaviorAttribute(Type errorHandlerType)
        {
            this.errorHandlerType = errorHandlerType;
        }

        public void Validate(ServiceDescription description, ServiceHostBase serviceHostBase)
        {
        }

        public void AddBindingParameters(ServiceDescription description, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection parameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription description, ServiceHostBase serviceHostBase)
        {
            var errorHandler = (IErrorHandler)Activator.CreateInstance(typeof(GlobalErrorHandler));
            foreach (ChannelDispatcherBase channelDispatcherBase in serviceHostBase.ChannelDispatchers)
            {
                ChannelDispatcher channelDispatcher = channelDispatcherBase as ChannelDispatcher;
                channelDispatcher.ErrorHandlers.Add(errorHandler);
            }
        }
    }
}