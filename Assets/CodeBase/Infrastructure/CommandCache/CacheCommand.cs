using System;
using UnityEngine;

namespace CodeBase.Infrastructure.CommandCache
{
    public abstract class CacheCommand<TArgs, TServices> : ICacheCommand, ICacheCommand<TServices>
        where TServices : IServicesHolder
    {
        private CommandCacheService _commandCacheService;
        private TArgs _args;

        public Type ArgsType => _args.GetType();

        public void Init(CommandCacheService commandCacheService)
        {
            _commandCacheService = commandCacheService;
            _commandCacheService.Add(this);
        }

        public void Perform()
        {
            PerformInternal();
            _commandCacheService.TryRemove(this);
        }

        public void InitArgs(TArgs args)
        {
            _args = args;
            JsonUtility.ToJson(_args);
            InitArgsInternal(_args);
        }

        public void InitArgs(object args) => InitArgs((TArgs)args);

        public string JsonArgs() => JsonUtility.ToJson(_args);

        public abstract void InitServices(TServices services);

        protected abstract void InitArgsInternal(TArgs args);
        protected abstract void PerformInternal();
    }
}