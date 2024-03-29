﻿using System;

namespace CodeBase.Infrastructure.CommandCache
{
    public interface ICommandService<TServices> : IDisposable where TServices : IServicesHolder
    {
        void Initialize();
        
        T Create<T, TArgs>(TArgs args) where T : CacheCommand<TArgs, TServices>, new();
        T Create<T, TArgs>() where T : CacheCommand<TArgs, TServices>, new() where TArgs : new();

        void TryRemove(ICacheCommand command);
    }
}