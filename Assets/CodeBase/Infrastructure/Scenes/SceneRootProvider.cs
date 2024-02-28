using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.Scenes
{
    public class SceneRootProvider : ISceneRootProvider
    {
        private const string ROOT = "root";
        
        public Transform Root => GetRoot();

        private Transform GetRoot()
        {
            var rootObjects = SceneManager.GetActiveScene().GetRootGameObjects();

            foreach (var rootObject in rootObjects)
            {
                if (rootObject.name.ToLower() == ROOT)
                    return rootObject.transform;
            }

            return null;
        }
    }
}