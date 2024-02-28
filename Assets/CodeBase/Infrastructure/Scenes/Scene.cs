using System;
using NaughtyAttributes;

namespace CodeBase.Infrastructure.Scenes
{
    [Serializable]
    public struct Scene
    {
        public SceneDefinition Definition;

        [Scene] 
        public string SceneName;
    }
}