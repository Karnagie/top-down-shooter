using CodeBase.Infrastructure.Assets;
using CodeBase.Infrastructure.Scenes;
using CodeBase.Infrastructure.Services.AsyncOperations;
using CodeBase.Modules.CoreModule.Services.Creatures;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Modules.CoreModule.Services.Camera
{
    public class CameraService : ICameraService, ILoadableService, IPrewarmService
    {
        private readonly AsyncOperationsService _asyncOperationsService;
        private readonly IAssetProvider _assetProvider;
        private readonly ISceneRootProvider _rootProvider;
        private readonly CameraConfig _cameraConfig;

        private UnityEngine.Camera _camera;

        public CameraService(
            AsyncOperationsService asyncOperationsService, 
            IAssetProvider assetProvider,
            ISceneRootProvider rootProvider,
            CameraConfig cameraConfig)
        {
            _cameraConfig = cameraConfig;
            _rootProvider = rootProvider;
            _asyncOperationsService = asyncOperationsService;
            _assetProvider = assetProvider;
        }
        
        public async UniTask FollowTo(ICreature creature)
        {
            using var token = _asyncOperationsService.CreateCancellationToken(CancellationDefinition.Core);
            
            await _camera.transform.DOMove(new Vector3(
                    creature.Transform.position.x,
                    creature.Transform.position.y, 
                    _camera.transform.position.z), _cameraConfig.StartShowTime)
                .CompleteWithCancellation(token.Token);
            _camera.transform.SetParent(creature.Transform);
        }

        public async UniTask Load()
        {
            if(_camera == null)
                _camera = await _assetProvider.Instantiate(_cameraConfig.Camera, _rootProvider.Root);
            ResetPosition();
        }

        public void Prewarm()
        {
            ResetPosition();
        }

        private void ResetPosition()
        {
            _camera.transform.SetParent(_rootProvider.Root);
            _camera.transform.position =
                new Vector3(_cameraConfig.StartOffset.x, _cameraConfig.StartOffset.y, _camera.transform.position.z);
        }
    }
}