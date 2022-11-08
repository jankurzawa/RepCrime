namespace RepCrime.Crime.API.QueuesServices.Interfaces
{
    public interface IPublisher
    {
        void SendMessage<T>(T message);
    }
}
