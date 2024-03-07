using UnityEngine;

namespace CodeBase.Modules.CoreModule.Services.Creatures.Components.Base
{
    public class FractionCreature : CoreComponent, IFractionCreature
    {
        [SerializeField] private CreatureDefinition _fraction;
        
        public CreatureDefinition Fraction => _fraction;
    }
}