namespace CodeBase.Infrastructure.CommandCache
{
    public class NotSaveCommandService<TServices> : ICommandService<TServices> where TServices : IServicesHolder
    {
        private CommandFactory _factory;
        private CommandCacheService _service;
        private TServices _serviceHolder;

        public NotSaveCommandService(
            CommandFactory factory,
            CommandCacheService service, 
            TServices serviceHolder)
        {
            _serviceHolder = serviceHolder;
            _service = service;
            _factory = factory;
        }

        public void Initialize()
        {
            
        }

        public T Create<T, TArgs>(TArgs args) where T : CacheCommand<TArgs, TServices>, new()
        {
            var cacheCommand = _factory.Create<T, TArgs, TServices>(args, _serviceHolder);
            
            return cacheCommand;
        }

        public void TryRemove(ICacheCommand command)
            => _service.TryRemove(command);

        public void Dispose()
        {
            
        }
    }
}