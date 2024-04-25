using System;
using LiteNinja.Injection;

namespace LiteNinja.Commands
{
    /// <summary>
    /// Factory class for creating command instances and injecting dependencies into them.
    /// </summary>
    /// <remarks>
    /// This class uses an instance of the Injector class to inject dependencies into the created command instances.
    /// It provides methods to get a new command instance either by type or by generic type parameter.
    /// </remarks>
    public class CommandFactory
    {
        private readonly Injector _injector;

        public CommandFactory(Injector injector)
        {
            _injector = injector;
        }

        /// <summary>
        /// Creates a new instance of the specified command type, injects its dependencies, and sets its CommandFactory.
        /// </summary>
        /// <typeparam name="T">The type of the command to create. This type must derive from ABaseCommand and
        /// have a parameterless constructor.</typeparam>
        /// <returns>A new instance of the specified command type, with dependencies injected and CommandFactory set.</returns>
        public virtual T Get<T>() where T : ABaseCommand, new()
        {
            var val = new T();
            _injector.Inject(val);
            val.CommandFactory = this;
            return val;
        }

        /// <summary>
        /// Creates a new instance of the specified command type, injects its dependencies, and sets its CommandFactory.
        /// </summary>
        /// <param name="type">The type of the command to create. This type must derive from ABaseCommand.</param>
        /// <returns>A new instance of the specified command type, with dependencies injected and CommandFactory set.</returns>
        /// <exception cref="CommandFactoryException">Thrown when the provided type does not derive from ABaseCommand.</exception>
        public virtual ABaseCommand Get(Type type)
        {
            if (!typeof(ABaseCommand).IsAssignableFrom(type))
                throw new CommandFactoryException(string.Concat("Trying to get ", type,
                    " from CommandFactory and it's not a BaseCommand!"), type);

            var obj = Activator.CreateInstance(type);
            _injector.Inject(obj);
            var baseCommand = obj as ABaseCommand;
            baseCommand.CommandFactory = this;
            return baseCommand;
        }
    }
}