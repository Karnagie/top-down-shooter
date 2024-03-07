namespace CodeBase.Modules.CoreModule.Services.Creatures.Components.Base
{
    public interface IRunService
    {
        void Run();
        void Disable();
    }

    public interface IEnableable
    {
        void Enable();
        void Disable();
    }
}