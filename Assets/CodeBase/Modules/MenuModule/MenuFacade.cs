﻿using System;
using CodeBase.Infrastructure.Scenes;
using CodeBase.Infrastructure.Services;
using CodeBase.Modules.WindowsModule;
using Cysharp.Threading.Tasks;

namespace CodeBase.Modules.MenuModule
{
    public class MenuFacade : IDisposable
    {
        private readonly ILogService _log;
        private readonly ISceneLoader _sceneLoader;
        private readonly IWindowService _windowService;
        private readonly ISceneRootProvider _rootProvider;

        private IPanel _menuHierarchy;

        public MenuFacade(
            ILogService log,
            ISceneLoader sceneLoader,
            IWindowService windowService,
            ISceneRootProvider rootProvider)
        {
            _windowService = windowService;
            _rootProvider = rootProvider;
            _sceneLoader = sceneLoader;
            _log = log;
        }

        public async UniTask Initialize()
        {
            _log.Log($"Initializing menu", LogDefinition.GameState);
            await _sceneLoader.Load(SceneDefinition.MainMenu);
            _menuHierarchy = await _windowService.LoadMainUi(_rootProvider.Root);
            _menuHierarchy.Initialize();
        }

        public void Run()
        {
            _log.Log($"Start menu", LogDefinition.GameState);
            _menuHierarchy.Show();
        }

        public void Dispose()
        {
            _menuHierarchy.Dispose();
        }
    }
}