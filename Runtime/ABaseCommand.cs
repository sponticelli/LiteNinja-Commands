namespace LiteNinja.Commands
{
    /// <summary>
    /// The base class for all commands in the application.
    /// </summary>
    /// <remarks>
    /// This class provides a property for accessing the CommandFactory, which is responsible for creating and
    /// injecting dependencies into command instances.
    /// The CommandFactory property is protected for setting, meaning it can only be set from within this class or
    /// derived classes.
    /// </remarks>
    public class ABaseCommand
    {
        /// <summary>
        /// Gets or sets the CommandFactory that is used to create and inject dependencies into command instances.
        /// </summary>
        public CommandFactory CommandFactory { protected get; set; }
    }
}