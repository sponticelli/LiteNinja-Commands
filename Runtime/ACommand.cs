namespace LiteNinja.Commands
{
    /// <summary>
    /// Represents an abstract base class for commands in the application.
    /// </summary>
    /// <remarks>
    /// This class extends ABaseCommand and provides a method for executing the command.
    /// The actual command logic is defined in the Run method, which must be implemented in derived classes.
    /// </remarks>
    public abstract class ACommand : ABaseCommand
    {
        /// <summary>
        /// Executes the command by calling the Run method.
        /// </summary>
        public void Execute()
        {
            Run();
        }

        protected abstract void Run();
    }
}