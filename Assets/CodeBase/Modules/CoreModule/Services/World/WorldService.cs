using CodeBase.Infrastructure.Assets;
using CodeBase.Infrastructure.Scenes;
using CodeBase.Modules.CoreModule.Services.Camera;
using Cysharp.Threading.Tasks;

namespace CodeBase.Modules.CoreModule.Services.World
{
    public class WorldService : ILoadableService
    {
        private IAssetProvider _assetProvider;
        private CoreConfig _coreConfig;
        private ISceneRootProvider _sceneRootProvider;

        public WorldService(
            IAssetProvider assetProvider, 
            CoreConfig coreConfig, 
            ISceneRootProvider sceneRootProvider)
        {
            _sceneRootProvider = sceneRootProvider;
            _coreConfig = coreConfig;
            _assetProvider = assetProvider;
        }
        
        public async UniTask Load()
        {
            await _assetProvider.Instantiate(_coreConfig.Room, _sceneRootProvider.Root);
        }
    }
}