using Zenject;

namespace CodeBase.Modules.InputModule
{
    public class InputInstaller : Installer<InputInstaller>
    {
        public override void InstallBindings()
        {
#if PLATFORM_STANDALONE
            Container.Bind<IInputService>().To<PcInputService>().AsSingle();
#endif
        }
    }
}