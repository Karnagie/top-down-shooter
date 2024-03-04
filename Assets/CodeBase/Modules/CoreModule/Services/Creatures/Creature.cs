using UnityEngine;

namespace CodeBase.Modules.CoreModule.Creatures
{
    public class Creature : MonoBehaviour, ICreature
    {
        public void Enable()
        {
            //todo enable all IEnableable components
        }

        public Transform Transform => transform;

        public void Dispose()
        {
            if(gameObject != null)
                Object.Destroy(gameObject);
        }
    }
}