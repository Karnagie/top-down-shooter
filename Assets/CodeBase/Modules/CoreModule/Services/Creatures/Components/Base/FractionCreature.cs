using CodeBase.Modules.CoreModule.Creatures;
using CodeBase.Modules.CoreModule.Creatures.Components;
using UnityEngine;

namespace CodeBase.Modules.CoreModule.Services.Creatures.Components.Base
{
    public class FractionCreature : CoreComponent, IFractionCreature
    {
        [SerializeField] private CreatureDefinition _fraction;
        
        public CreatureDefinition Fraction => _fraction;
    }
}