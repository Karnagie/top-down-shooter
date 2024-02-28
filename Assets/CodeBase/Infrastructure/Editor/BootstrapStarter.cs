using CodeBase.Infrastructure.Scenes;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Editor
{
    public class BootstrapStarter : MonoBehaviour
    {
#if UNITY_EDITOR
        private IEditorStaticDataService _editorStaticDataService;
        private ISceneLoader _sceneLoader;

        [Inject]
        private void Construct(IEditorStaticDataService editorStaticDataService, ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
            _editorStaticDataService = editorStaticDataService;
        }
        
        private void Awake()
        {
            if (_editorStaticDataService.StartedFromBootstrap == false)
                _sceneLoader.Load(SceneDefinition.Bootstrap).Forget(); 
        }
#endif
    }
}