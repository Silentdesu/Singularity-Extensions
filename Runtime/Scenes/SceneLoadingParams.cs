using UnityEngine.SceneManagement;

namespace SingularityLab.Runtime.Scenes
{
    public class SceneLoadingParams
    {
        public string SceneName;
        public LoadSceneMode LoadSceneMode = LoadSceneMode.Additive;
    }
}