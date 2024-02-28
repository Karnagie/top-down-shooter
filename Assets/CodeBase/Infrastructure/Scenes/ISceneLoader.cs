using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.Scenes
{
    public interface ISceneLoader
    {
        UniTask Load(SceneDefinition definition);
    }
}