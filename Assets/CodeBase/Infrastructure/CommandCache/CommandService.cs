using CodeBase.Infrastructure.CommandCache.SaveLoad;

namespace CodeBase.Infrastructure.CommandCache
{
    public class CommandService<TServices> : ICommandService<TServices> where TServices : IServicesHolder
    {
        private CommandFactory _factory;
        private CommandCacheService _service;
        private TServices _serviceHolder;
        private ICommandSaveLoader<TServices> _saveLoader;

        public CommandService(
            CommandFactory factory,
            CommandCacheService service, 
            TServices serviceHolder,
            ICommandSaveLoader<TServices> saveLoader)
        {
            _serviceHolder = serviceHolder;
            _saveLoader = saveLoader;
            _service = service;
            _factory = factory;
        }

        public void Initialize()
        {
            ICacheCommand[] commands = _saveLoader.LoadAll();
            
            foreach (var command in commands)
            {
                command.Perform();
            }
            
            _service.Removed += OnRemovedCommand;
        }

        public T Create<T, TArgs>(TArgs args) where T : CacheCommand<TArgs, TServices>, new()
        {
            var cacheCommand = _factory.Create<T, TArgs, TServices>(args, _serviceHolder);
            _saveLoader.Save(cacheCommand);
            
            return cacheCommand;
        }
        
        public T Create<T, TArgs>() where T : CacheCommand<TArgs, TServices>, new() where TArgs : new()
        {
            var cacheCommand = _factory.Create<T, TArgs, TServices>(new TArgs(), _serviceHolder);
            _saveLoader.Save(cacheCommand);
            
            return cacheCommand;
        }

        public void TryRemove(ICacheCommand command)
            => _service.TryRemove(command);

        private void OnRemovedCommand(ICacheCommand command)
        {
            _saveLoader.Unload(command);
        }

        public void Dispose()
        {
            _service.Removed -= OnRemovedCommand;
        }
    }
}