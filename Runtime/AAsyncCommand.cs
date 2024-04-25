using System.Threading;
using Cysharp.Threading.Tasks;

namespace LiteNinja.Commands
{
    /// <summary>
    /// The base class for all asynchronous commands in the application.
    /// </summary>
    /// <remarks>
    /// This class extends ABaseCommand and provides an asynchronous execution method, ExecuteAsync, 
    /// which accepts a CancellationToken as an optional parameter. 
    /// The Run method is abstract and must be implemented in derived classes to define the command's behavior.
    /// </remarks>
    public abstract class AAsyncCommand : ABaseCommand
    {
        public UniTask ExecuteAsync(CancellationToken cancellationToken = default)
        {
            return Run(cancellationToken);
        }

        protected abstract UniTask Run(CancellationToken cancellationToken);
    }
}