using CodeBase.Modules.BootstrapModule;
using CodeBase.Modules.CoreModule;
using CodeBase.Modules.InputModule;
using CodeBase.Modules.MenuModule;
using CodeBase.Modules.WindowsModule;
using Zenject;

namespace CodeBase.ModuleControl
{
    public class ModuleInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BootstrapInstaller.Install(Container);

            WindowInstaller.Install(Container);
            MenuInstaller.Install(Container);
            CoreInstaller.Install(Container);
            InputInstaller.Install(Container);
        }
    }
}