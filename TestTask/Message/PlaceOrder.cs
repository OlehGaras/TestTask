using NServiceBus;

namespace Message
{
    public class PlaceOrder : ICommand
    {
        public Student Student { get; set; }
    }
}
