using System;
using System.ComponentModel.Design;

namespace CodeBase.Infrastructure.CommandCache
{
    public class CommandFactory
    {
        private CommandCacheService _commandCacheService;

        public CommandFactory(CommandCacheService commandCacheService)
        {
            _commandCacheService = commandCacheService;
        }
        
        public T Create<T, TArgs, TServices>(TArgs args, TServices services) 
            where T : CacheCommand<TArgs, TServices>, new()
            where TServices : IServicesHolder
        {
            var command = new T();
            
            command.Init(_commandCacheService);
            command.InitArgs(args);
            command.InitServices(services);
            
            return command;
        }
        
        public ICacheCommand Create<TServices>(Type commandType, object args, TServices services)
            where TServices : IServicesHolder
        {
            var command = (ICacheCommand<TServices>)Activator.CreateInstance(commandType);
            
            command.Init(_commandCacheService);
            command.InitArgs(args);
            command.InitServices(services);
            
            return command as ICacheCommand;
        }
    }
}