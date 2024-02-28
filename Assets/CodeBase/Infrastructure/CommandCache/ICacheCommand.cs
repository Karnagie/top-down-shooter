using System;

namespace CodeBase.Infrastructure.CommandCache
{
    public interface ICacheCommand
    {
        Type ArgsType { get; }
        
        void Perform();
        string JsonArgs();
    }
    
    public interface ICacheCommand<in TServices> where TServices : IServicesHolder
    {
        void Init(CommandCacheService commandCacheService);
        void InitServices(TServices services);
        void InitArgs(object args);
    }
}