﻿using CodeBase.Infrastructure.CommandCache;
using CodeBase.Infrastructure.StateMachines.Game;
using CodeBase.Modules.CoreModule.Services.Camera;
using CodeBase.Modules.CoreModule.Services.CommandService;
using CodeBase.Modules.CoreModule.Services.Creatures;
using CodeBase.Modules.CoreModule.Services.Creatures.Components.Base;
using CodeBase.Modules.CoreModule.Services.Physic;
using CodeBase.Modules.CoreModule.Services.Ticking;
using CodeBase.Modules.CoreModule.Services.World;
using CodeBase.Modules.CoreModule.StateMachine;
using CodeBase.Modules.MenuModule;
using UnityEngine;
using Zenject;

namespace CodeBase.Modules.CoreModule
{
    public class CoreInstaller : Installer<CoreInstaller>
    {
        private const string CoreConfigPath = "ModuleConfigs/CoreConfig";
        private const string CameraConfigPath = "ModuleConfigs/CameraConfig";
        
        public override void InstallBindings()
        {
            var coreConfig = Resources.Load<CoreConfig>(CoreConfigPath);
            var cameraConfig = Resources.Load<CameraConfig>(CameraConfigPath);
            
            Container.Bind<CoreConfig>().FromInstance(coreConfig).AsSingle();
            Container.Bind<CameraConfig>().FromInstance(cameraConfig).AsSingle();

            Container.BindInterfacesAndSelfTo<WorldService>().AsSingle();
            Container.BindInterfacesAndSelfTo<CameraService>().AsSingle();
            Container.BindInterfacesAndSelfTo<CreatureService>().AsSingle();

            Container.Bind<CoreFacade>().AsSingle();
            Container.Bind<ICreatureFactory>().To<CreatureFactory>().AsSingle();
            Container.Bind<CoreStateMachine>().AsSingle();
            Container.Bind<StateHolder<IExitableCoreState>>().AsSingle();
            Container.Bind<ServiceHandler>().AsSingle();
            Container.Bind<CoreServiceHolder>().AsSingle();
            Container.Bind<ICommandService<CoreServiceHolder>>()
                .To<NotSaveCommandService<CoreServiceHolder>>().AsSingle();
            Container.BindInterfacesTo<TickService>().AsSingle();
            Container.Bind<LinkService>().AsSingle();
            Container.Bind<PhysicService>().AsSingle();
            
            Container.BindInterfacesTo<InitializeState>().AsSingle();
            Container.BindInterfacesTo<RunState>().AsSingle();
            
            Container.BindInterfacesTo<CoreState>().AsSingle();
            Container.BindInterfacesTo<FinalizeState<MenuState>>().AsSingle();
        }
    }
}