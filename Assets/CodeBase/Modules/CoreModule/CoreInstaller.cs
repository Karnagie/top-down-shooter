using CodeBase.Modules.CoreModule.Creatures;
using CodeBase.Modules.CoreModule.World;
using UnityEngine;
using Zenject;

namespace CodeBase.Modules.CoreModule
{
    public class CoreInstaller : Installer<CoreInstaller>
    {
        private const string ConfigPath = "ModuleConfigs/CoreConfig";
        
        public override void InstallBindings()
        {
            var config = Resources.Load<CoreConfig>(ConfigPath);
            Container.Bind<CoreConfig>().FromInstance(config).AsSingle();
            
            Container.Bind<CoreFacade>().AsSingle();
            Container.Bind<WorldService>().AsSingle();
            Container.Bind<CreatureService>().AsSingle();
            Container.Bind<ICreatureFactory>().To<CreatureFactory>().AsSingle();
            
            Container.BindInterfacesTo<CoreState>().AsSingle();
        }
    }
}