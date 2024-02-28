using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace CodeBase.Modules.CoreModule.Creatures
{
    public class CreatureService : IDisposable
    {
        private ICreatureFactory _creatureFactory;
        private List<ICreature> _creatures = new ();

        public CreatureService(ICreatureFactory creatureFactory)
        {
            _creatureFactory = creatureFactory;
        }
        
        public async UniTask Load()
        {
            var player = await _creatureFactory.Create(CreatureDefinition.Player);
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

        public void Run()
        {
            foreach (var creature in _creatures.ToArray())
            {
                creature.Enable();
            }
        }
    }
}