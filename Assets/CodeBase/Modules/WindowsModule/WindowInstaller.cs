using UnityEngine;
using Zenject;

namespace CodeBase.Modules.WindowsModule
{
    public class WindowInstaller : Installer<WindowInstaller>
    {
        private const string ConfigPath = "ModuleConfigs/WindowConfig";
        
        public override void InstallBindings()
        {
            var config = Resources.Load<WindowConfig>(ConfigPath);
            Container.Bind<WindowConfig>().FromInstance(config).AsSingle();
            
            Container.Bind<IWindowService>().To<WindowService>().AsSingle();
        }
    }
}