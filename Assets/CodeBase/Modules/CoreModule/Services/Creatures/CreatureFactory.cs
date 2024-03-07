using System;
using CodeBase.Infrastructure.Assets;
using CodeBase.Infrastructure.Scenes;
using Cysharp.Threading.Tasks;

namespace CodeBase.Modules.CoreModule.Services.Creatures
{
    public class CreatureFactory : ICreatureFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly CoreConfig _config;
        private readonly ISceneRootProvider _sceneRootProvider;

        public CreatureFactory(
            IAssetProvider assetProvider,
            CoreConfig config,
            ISceneRootProvider sceneRootProvider)
        {
            _config = config;
            _sceneRootProvider = sceneRootProvider;
            _assetProvider = assetProvider;
        }
        
        public async UniTask<ICreature> Create(CreatureDefinition definition)
        {
            switch (definition)
            {
                case CreatureDefinition.Player:
                    return await _assetProvider.Instantiate(_config.Player, _sceneRootProvider.Root);
                case CreatureDefinition.Enemy:
                    return await _assetProvider.Instantiate(_config.Enemy, _sceneRootProvider.Root);
                default:
                    throw new ArgumentOutOfRangeException(nameof(definition), definition, null);
            }
        }
    }
}