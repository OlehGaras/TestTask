
using System.Transactions;
using NServiceBus.Features;
using NServiceBus.Saga;

namespace TestTask
{
    using NServiceBus;

    /*
        This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
        can be found here: http://particular.net/articles/the-nservicebus-host
    */
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Client, IWantCustomInitialization
    {
        public void Init()
        {
            //Configure.Instance.IsolationLevel(IsolationLevel.Serializable);
            Configure.Serialization.Xml();
            Configure.Features.Disable<MsmqTransport>().Enable<Sagas>();
            Configure.With().DefaultBuilder().UseRavenTimeoutPersister().UseRavenGatewayPersister().DisableTimeoutManager().UnicastBus();
        }
    }
}
