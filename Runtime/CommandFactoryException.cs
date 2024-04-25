using System;

namespace LiteNinja.Commands
{
    public class CommandFactoryException : Exception
    {
        public Type CommandType { get; }
        
        public CommandFactoryException(string message, Type commandType) : base(message)
        {
            CommandType = commandType;
        }

    }
}