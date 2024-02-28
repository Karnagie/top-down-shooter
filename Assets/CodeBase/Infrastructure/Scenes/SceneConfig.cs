using NaughtyAttributes;
using UnityEngine;

namespace CodeBase.Infrastructure.Scenes
{
    [CreateAssetMenu(fileName = "New Scene Config", menuName = "Configs/SceneConfig", order = 0)]
    public class SceneConfig : ScriptableObject
    {
        [SerializeField] private Scene[] _scenes;
        
        [Scene]
        [SerializeField] private string _notFoundScene;

        public string FindName(SceneDefinition definition)
        {
            foreach (var scene in _scenes)
            {
                if (scene.Definition == definition)
                    return scene.SceneName;
            }

            return _notFoundScene;
        }
    }
}