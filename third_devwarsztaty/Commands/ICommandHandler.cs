using System.Threading.Tasks;

namespace third_devwarsztaty.Commands
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}