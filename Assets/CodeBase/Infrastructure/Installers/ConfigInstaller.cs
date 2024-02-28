using CodeBase.Infrastructure.LoadingCurtains;
using CodeBase.Infrastructure.Scenes;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
    public class ConfigInstaller : MonoInstaller
    {
        [SerializeField] private SceneConfig _sceneConfig;
        [SerializeField] private LoadingCurtainConfig _loadingCurtainConfig;

        public override void InstallBindings()
        {
            Container.Bind<SceneConfig>().FromInstance(_sceneConfig).AsSingle();
            Container.Bind<LoadingCurtainConfig>().FromInstance(_loadingCurtainConfig).AsSingle();
        }
    }
}