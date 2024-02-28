namespace CodeBase.Infrastructure.CommandCache.SaveLoad
{
    public interface ICommandSaveLoader<TServices> where TServices : IServicesHolder
    {
        ICacheCommand[] LoadAll();
        void Save(ICacheCommand command);
        void Unload(ICacheCommand command);
    }
}