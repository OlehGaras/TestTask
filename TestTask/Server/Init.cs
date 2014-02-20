using NServiceBus;

namespace Server
{
    class CustomInit : INeedInitialization
{
    public void Init()
    {
        //NHibernatePersistence.UseAsDefault();
    }
}
}
