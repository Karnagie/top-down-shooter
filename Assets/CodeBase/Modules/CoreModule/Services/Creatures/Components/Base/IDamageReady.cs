namespace CodeBase.Modules.CoreModule.Services.Creatures.Components.Base
{
    public interface IDamageReady : ICoreComponent
    {
        bool IsReady();
        void Reset();
    }
}