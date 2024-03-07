using System;
using System.Threading.Tasks;
using CodeBase.Infrastructure.Scenes;
using CodeBase.Infrastructure.StateMachines.Game;
using CodeBase.Modules.CoreModule.Creatures;
using CodeBase.Modules.CoreModule.StateMachine;
using CodeBase.Modules.CoreModule.World;
using CodeBase.Modules.InputModule;
using CodeBase.Modules.WindowsModule;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Modules.CoreModule
{
    public class CoreFacade : IDisposable
    {
        private StateHolder<IExitableCoreState> _stateHolder;
        private CoreStateMachine _coreStateMachine;
        
        private IWindowService _windowService;
        private IPanel _coreHierarchy;
        private ISceneRootProvider _rootProvider;
        private ISceneLoader _sceneLoader;
        private ServiceHandler _serviceHandler;

        public CoreFacade(
            StateHolder<IExitableCoreState> stateHolder,
            CoreStateMachine coreStateMachine, 
            IWindowService windowService,
            ISceneRootProvider rootProvider, 
            ISceneLoader sceneLoader,
            ServiceHandler serviceHandler,
            IInputService inputService)
        {
            _serviceHandler = serviceHandler;
            _rootProvider = rootProvider;
            _sceneLoader = sceneLoader;
            _coreStateMachine = coreStateMachine;
            _windowService = windowService;
            _stateHolder = stateHolder;
        }

        public async UniTask Initialize()
        {
            await _sceneLoader.Load(SceneDefinition.Core);
            _coreStateMachine.Initialize(_stateHolder);

            await _serviceHandler.LoadAll();
            
            _coreHierarchy = await _windowService.LoadDevCoreUi(_rootProvider.Root);
            _coreHierarchy.Initialize();
        }

        public void Run()
        {
            _coreStateMachine.Enter<InitializeState>();
        }

        public void Dispose()
        {
            _serviceHandler.Dispose();
        }
    }
}