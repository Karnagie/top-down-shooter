using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.Scenes
{
    public class SceneLoader : ISceneLoader
    {
        private SceneConfig _sceneConfig;

        public SceneLoader(SceneConfig sceneConfig)
        {
            _sceneConfig = sceneConfig;
        }
        
        public async UniTask Load(SceneDefinition definition)
        {
            var sceneName = _sceneConfig.FindName(definition);
            await SceneManager.LoadSceneAsync(sceneName);
        }
    }
}