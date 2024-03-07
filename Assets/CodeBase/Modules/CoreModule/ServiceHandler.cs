using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeBase.Modules.CoreModule.Services.Creatures.Components.Base;
using CodeBase.Modules.InputModule;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Modules.CoreModule
{
    public class ServiceHandler : IDisposable
    {
        private IEnumerable<ILoadableService> _loadableServices;
        private IEnumerable<ICoreDisposable> _coreDisposable;
        private IEnumerable<IPrewarmService> _prewarmServices;
        private IEnumerable<IRunService> _runServices;

        public ServiceHandler(
            IEnumerable<ILoadableService> loadableServices,
            IEnumerable<ICoreDisposable> coreDisposable,
            IEnumerable<IPrewarmService> prewarmServices,
            IEnumerable<IRunService> runServices)
        {
            _runServices = runServices;
            _prewarmServices = prewarmServices;
            _coreDisposable = coreDisposable;
            _loadableServices = loadableServices;
        }

        public async UniTask LoadAll()
        {
            foreach (var loadableService in _loadableServices)
            {
                await loadableService.Load();
            }
        }
        
        public void Run()
        {
            foreach (var runService in _runServices)
            {
                runService.Run();
            }
        }

        public void End()
        {
            foreach (var runService in _runServices)
            {
                runService.Disable();
            }
        }

        public void Dispose()
        {
            foreach (var coreDisposable in _coreDisposable)
            {
                coreDisposable.Dispose();
            }
        }

        public UniTask PrewarmAll()
        {
            foreach (var prewarmService in _prewarmServices)
            {
                prewarmService.Prewarm();
            }

            return UniTask.CompletedTask;
        }
    }
}