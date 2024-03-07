namespace CodeBase.Modules.CoreModule.Services.Ticking
{
    public interface ITickService
    {
        void Add(ITickHandler tickHandler);
        void Remove(ITickHandler tickHandler);
    }
}