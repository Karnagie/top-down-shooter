using System;
using System.Collections.Generic;
using CodeBase.Modules.CoreModule.Services.Creatures.Components.Base;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Modules.CoreModule.Creatures
{
    public class CreatureService : ILoadableService, ICoreDisposable, IRunService, IPrewarmService
    {
        private ICreatureFactory _creatureFactory;
        private List<ICreature> _creatures = new ();
        private LinkService _linkService;

        public ICreature Player { get; private set; }

        public CreatureService(ICreatureFactory creatureFactory, LinkService linkService)
        {
            _linkService = linkService;
            _creatureFactory = creatureFactory;
        }

        public async UniTask Load()
        {
            var player = await _creatureFactory.Create(CreatureDefinition.Player);
            Player = player; 
            _creatures.Add(player);
            
            var enemy = await _creatureFactory.Create(CreatureDefinition.Enemy);
            enemy.Transform.position = new Vector3(5, 5, 0);
            _creatures.Add(enemy);
        }

        public void Dispose()
        {
            foreach (var creature in _creatures)
            {
                creature?.Dispose();
            }
            
            _creatures.Clear();
        }

        public void Prewarm()
        {
            foreach (var creature in _creatures.ToArray())
            {
                creature.Reset();
            }
        }

        public void Run()
        {
            foreach (var creature in _creatures.ToArray())
            {
                creature.Enable();
            }
        }

        public void Disable()
        {
            foreach (var creature in _creatures.ToArray())
            {
                creature.Disable();
            }
        }

        public List<ICreature> FindAll(CreatureDefinition creatureDefinition)
        {
            List<ICreature> creatures = new List<ICreature>();
                
            foreach (var creature in _creatures)
            {
                if (_linkService.TryGet(creature, out IFractionCreature fractionCreature) == false)
                    continue;
                
                if(fractionCreature.Fraction != creatureDefinition)
                    continue;
                
                creatures.Add(creature);
            }

            return creatures;
        }
    }
}