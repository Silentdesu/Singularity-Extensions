using UnityEngine.SceneManagement;

namespace SingularityLab.Runtime.Scenes
{
    public sealed class SceneLoadingParams
    {
        public string SceneName;
        public LoadSceneMode LoadSceneMode = LoadSceneMode.Additive;
    }
}