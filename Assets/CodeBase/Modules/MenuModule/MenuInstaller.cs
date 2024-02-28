using Zenject;

namespace CodeBase.Modules.MenuModule
{
    public class MenuInstaller : Installer<MenuInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<MenuFacade>().AsSingle();

            Container.BindInterfacesTo<MenuState>().AsSingle();
        }
    }
}