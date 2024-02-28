using UnityEngine;

namespace CodeBase.Modules.CoreModule.Creatures
{
    public class Creature : MonoBehaviour, ICreature
    {
        public void Enable()
        {
            //todo enable all IEnableable components
        }

        public void Dispose()
        {
            Object.Destroy(gameObject);
        }
    }
}