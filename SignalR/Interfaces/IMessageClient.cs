namespace SignalR.Interfaces
{
    public interface IMessageClient
    {
        //Strongly Typed Hubs
        Task Clients(List<string> clients);
        Task UserJoined(string connectionId);
        Task UserLeaved(string connectionId);
    }



}
