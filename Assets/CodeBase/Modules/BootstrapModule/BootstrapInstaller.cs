using Zenject;

namespace CodeBase.Modules.BootstrapModule
{
    public class BootstrapInstaller : Installer<BootstrapInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<BootstrapState>().AsSingle();
        }
    }
}