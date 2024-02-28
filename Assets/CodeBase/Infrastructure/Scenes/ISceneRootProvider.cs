using UnityEngine;

namespace CodeBase.Infrastructure.Scenes
{
    public interface ISceneRootProvider
    {
        Transform Root { get; }
    }
}