using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Modules.CoreModule.Creatures
{
    public class CreatureService : ILoadableService, ICoreDisposable, IPrewarmService
    {
        private ICreatureFactory _creatureFactory;
        private List<ICreature> _creatures = new ();

        public ICreature Player { get; private set; }

        public CreatureService(ICreatureFactory creatureFactory)
        {
            _creatureFactory = creatureFactory;
        }

        public async UniTask Load()
        {
            var player = await _creatureFactory.Create(CreatureDefinition.Player);
            Player = player; 
            _creatures.Add(player);
        }

        public void Dispose()
        {
            foreach (var creature in _creatures)
            {
                creature.Dispose();
            }
            
            _creatures.Clear();
        }

        public void Prewarm()
        {
            Player.Transform.position = Vector3.zero;
        }

        public void Run()
        {
            foreach (var creature in _creatures.ToArray())
            {
                creature.Enable();
            }
        }
    }
}