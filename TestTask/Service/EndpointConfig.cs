
using System.Transactions;
using NServiceBus.Features;

namespace Service
{
    using NServiceBus;

	/*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://particular.net/articles/the-nservicebus-host
	*/
	public class EndpointConfig : IConfigureThisEndpoint, AsA_Server
    {
	    public void Init()
	    {
            //in case i would like to send response to requestSender
            //Configure.Instance.IsolationLevel(IsolationLevel.Serializable);
	        Configure.Serialization.Xml();
	        Configure.Features.Disable<Sagas>();
	        Configure.With()
	                 .DefaultBuilder()
	                 .UseTransport<Msmq>()
	                 .MsmqSubscriptionStorage()
	                 .DisableTimeoutManager()
	                 .UnicastBus();
	    }
    }
}
