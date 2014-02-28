using NServiceBus;

namespace Message
{
    public class ObjectToSend : ICommand
    {
        public Student Student { get; set; }
    }
}
