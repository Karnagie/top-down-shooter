using CodeBase.Infrastructure.Assets;
using CodeBase.Infrastructure.CommandCache;
using CodeBase.Infrastructure.CommandCache.SaveLoad;
using CodeBase.Infrastructure.Editor;
using CodeBase.Infrastructure.LoadingCurtains;
using CodeBase.Infrastructure.Scenes;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.AsyncOperations;
using CodeBase.Infrastructure.StateMachines;
using CodeBase.Infrastructure.StateMachines.Game;
using CodeBase.Infrastructure.StateMachines.Game.States.Types;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ILogService>().To<LogService>().AsSingle();
            Container.Bind<ILoadingCurtain>().To<LoadingCurtain>().AsSingle();
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<ISceneRootProvider>().To<SceneRootProvider>().AsSingle();
            Container.Bind<IEditorStaticDataService>().To<EditorStaticDataService>().AsSingle();
            Container.Bind<AsyncOperationsService>().AsSingle();

            BindGameStateMachine();
            
            BindInfrastructureCommandService();
        }

        private void BindGameStateMachine()
        {
            Container.Bind<IStateHolder<IExitableGameState>>().To<StateHolder<IExitableGameState>>().AsSingle();
            Container.Bind<GameStateMachine>().AsSingle();
        }

        private void BindInfrastructureCommandService()
        {
            Container.Bind<ICommandSaveLoader<InfrastructureServiceHolder>>()
                .To<PlayerPrefsCommandSaveLoader<InfrastructureServiceHolder>>().AsSingle();
            Container.Bind<CommandCacheService>().AsSingle();
            Container.Bind<CommandFactory>().AsSingle();
            Container.Bind<InfrastructureServiceHolder>().AsSingle();
            Container.Bind<ICommandService<InfrastructureServiceHolder>>()
                .To<NotSaveCommandService<InfrastructureServiceHolder>>().AsSingle();
        }
    }
}