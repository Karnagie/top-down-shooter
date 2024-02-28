using System;
using System.Threading.Tasks;
using CodeBase.Infrastructure.Assets;
using CodeBase.Modules.CoreModule.Creatures;
using CodeBase.Modules.CoreModule.World;
using Cysharp.Threading.Tasks;

namespace CodeBase.Modules.CoreModule
{
    public class CoreFacade : IDisposable
    {
        private WorldService _worldService;
        private CreatureService _creatureService;

        public CoreFacade(
            WorldService worldService, 
            CreatureService creatureService)
        {
            _worldService = worldService;
            _creatureService = creatureService;
        }

        public async UniTask Initialize()
        {
            await _worldService.Load();
            await _creatureService.Load();
        }

        public void Run()
        {
            _creatureService.Run();
        }

        public void Dispose()
        {
            _creatureService.Dispose();
        }
    }
}