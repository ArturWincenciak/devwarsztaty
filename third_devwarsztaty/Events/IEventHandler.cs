using System.Threading.Tasks;

namespace third_devwarsztaty.Events
{
    public interface IEventHandler<in T> where T : IEvent
    {
        Task HandleAsync(T @event);
    }
}